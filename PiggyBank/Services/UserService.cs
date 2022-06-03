using PiggyBank.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Services
{
    public class UserService
    {
        private readonly PiggyBankContext _context;

        public UserService(PiggyBankContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(User obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ValidarLoginAsync(User obj)
        {
            return await _context.User.Where(x => x.Email == obj.Email && x.Password == obj.Password).SingleOrDefaultAsync();
        }

    }
}
