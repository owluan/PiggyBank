using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The length of {0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Fill in the field {0}")]
        [Range(1.0, 5000.0, ErrorMessage = "The {0} must be between {1} and {2}")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]        
        public double Value { get; set; }

        public Account Account { get; set; }

        [Display(Name = "Linked Account")]
        public int AccountId { get; set; }

        public Expense()
        {
        }

        public Expense(int id, string name, DateTime date, double value, Account account)
        {
            Id = id;
            Name = name;
            Date = date;
            Value = value;
            Account = account;
        }


    }
}
