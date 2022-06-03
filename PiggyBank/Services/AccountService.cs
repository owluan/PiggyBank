using PiggyBank.Models;
using PiggyBank.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Services
{
    public class AccountService
    {
        private readonly PiggyBankContext _context;
        IHttpContextAccessor HttpContextAccessor;

        public AccountService(PiggyBankContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
        }
                
        public async Task<List<Account>> FindAllAsync(int id)
        {        
            return await _context.Account.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task InsertAsync(Account obj)
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            obj.UserId = int.Parse(idUser);
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _context.Account.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Account.FindAsync(id);
            _context.Account.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task AddCostAsync(Expense expense)
        {
            var id = expense.AccountId;
            var obj = await _context.Account.FindAsync(id);
            obj.Balance = obj.Balance - expense.Value;
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCostAsync(int id)
        {
            var desp = await _context.Expense.FindAsync(id);
            var obj = await _context.Account.FindAsync(desp.AccountId);
            obj.Balance = obj.Balance + desp.Value;
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task AddRevenueAsync(Revenue revenue)
        {
            var id = revenue.AccountId;
            var obj = await _context.Account.FindAsync(id);
            obj.Balance = obj.Balance + revenue.Value;
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRevenueAsync(int id)
        {
            var revenue = await _context.Revenue.FindAsync(id);
            var obj = await _context.Account.FindAsync(revenue.AccountId);
            obj.Balance = obj.Balance - revenue.Value;
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account obj)
        {
            bool hasAny = await _context.Account.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
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
    }
}
