using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BankWebApplication.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string IBAN { get; set; }

        public string Address { get; set; }

        public string BIC { get; set; }

        [StringLength(10, ErrorMessage = "Identification Number must be 10 numbers")]
        public int IdentificationNumber { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }


    }
}
