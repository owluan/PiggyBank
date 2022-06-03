using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models
{
    public class PiggyBankContext : DbContext
    {
        public PiggyBankContext (DbContextOptions<PiggyBankContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Revenue> Revenue { get; set; }
    }
}
