using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models.ViewModels
{
    public class RevenueFormViewModel
    {
        public Revenue Revenue { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
