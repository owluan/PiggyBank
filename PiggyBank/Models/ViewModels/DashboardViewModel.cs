using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models.ViewModels
{
    public class DashboardViewModel
    {
        public ICollection<Revenue> Revenues { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
