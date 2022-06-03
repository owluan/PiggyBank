using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models.ViewModels
{
    public class ExpenseFormViewModel
    {
        public Expense Expense { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
