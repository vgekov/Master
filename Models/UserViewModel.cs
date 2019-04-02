using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Models
{
    public class UserViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string IBAN { get; set; }

        public string Address { get; set; }

        public string BIC { get; set; }

        public int IdentificationNumber { get; set; }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }

    }
}
