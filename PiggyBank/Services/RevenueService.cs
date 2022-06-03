using PiggyBank.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Services.Exceptions;

namespace PiggyBank.Services
{
    public class RevenueService
    {
        private readonly PiggyBankContext _context;
        IHttpContextAccessor HttpContextAccessor;

        public RevenueService(PiggyBankContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Revenue>> FindAllAsync(int id)
        {
            return await _context.Revenue.Where(x => x.Account.UserId == id).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Revenue obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Revenue> FindByIdAsync(int id)
        {
            return await _context.Revenue.Include(x => x.Account).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Revenue.FindAsync(id);
            _context.Revenue.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Revenue obj)
        {
            bool hasAny = await _context.Revenue.AnyAsync(x => x.Id == obj.Id);
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

        public async Task<List<Revenue>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var result = from obj in _context.Revenue select obj;
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
            return await _context.Revenue.Where(x => x.Account.UserId == id).SumAsync(x => x.Value);
        }
    }
}
