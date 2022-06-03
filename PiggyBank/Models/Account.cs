using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();        
        public ICollection<Revenue> Revenues { get; set; } = new List<Revenue>();
        

        public Account()
        {
        }

        public Account(int id, string name, double balance, User user)
        {
            Id = id;
            Name = name;
            Balance = balance;
            User = user;
        }

        public void AddExpenses(Expense vd)
        {
            Expenses.Add(vd);
        }

        public void RemoveExpenses(Expense vd)
        {
            Expenses.Remove(vd);
        }

        public double TotalExpenses(DateTime initial, DateTime final)
        {
            return Expenses.Where(vd => vd.Date >= initial && vd.Date <= final).Sum(vd => vd.Value);
        }

        public void AddRevenues(Revenue cp)
        {
            Revenues.Add(cp);
        }

        public void RemoveRevenues(Revenue cp)
        {
            Revenues.Remove(cp);
        }

        public double TotalRevenues(DateTime initial, DateTime final)
        {
            return Revenues.Where(cp => cp.Date >= initial && cp.Date <= final).Sum(cp => cp.Value);
        }
    }
}
