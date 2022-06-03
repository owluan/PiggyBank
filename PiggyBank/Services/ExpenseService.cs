using PiggyBank.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Services.Exceptions;
using PiggyBank.Models.ViewModels;

namespace PiggyBank.Services
{
    public class ExpenseService
    {
        private readonly PiggyBankContext _context;
        IHttpContextAccessor HttpContextAccessor;

        public ExpenseService(PiggyBankContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Expense>> FindAllAsync(int id)
        {
            return await _context.Expense.Where(x => x.Account.UserId == id).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Expense obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Expense> FindByIdAsync(int id)
        {
            return await _context.Expense.Include(x => x.Account).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Expense.FindAsync(id);
            _context.Expense.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense obj)
        {
            bool hasAny = await _context.Expense.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Expense>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var result = from obj in _context.Expense select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value && x.Account.UserId == int.Parse(idUser));
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value && x.Account.UserId == int.Parse(idUser));
            }
            return await result
            .Include(x => x.Account)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
        }
        
        public async Task<Double> DashAsync(int id)
        {
            return await _context.Expense.Where(x => x.Account.UserId == id).SumAsync(x => x.Value);
        }
       
    }
}
