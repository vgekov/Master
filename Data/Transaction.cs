using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Data
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public User UsersTransaction { get; set; }
        [Required]
        public string TakerCompany { get; set; }

        public decimal Cash { get; set; }
        [Required]
        public string ReasonForPayment { get; set; }
    }
}
