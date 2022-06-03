using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The length of {0} must be between {2} and {1} characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Fill in the field {0}")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fill in the field {0}")]
        public string Password { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();

        public User()
        {
        }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public double TotalExpenses(DateTime initial, DateTime final)
        {
            return Accounts.Sum(account => account.TotalExpenses(initial, final));
        }

        public double TotalRevenues(DateTime initial, DateTime final)
        {
            return Accounts.Sum(account => account.TotalRevenues(initial, final));
        }
        
    }
}
