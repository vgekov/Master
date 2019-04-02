using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApplication.Data;

namespace BankWebApplication.Models
{
    public abstract class BaseViewModel
    {
        public List<TransactionViewModel>Transactions { get; set; }
    }
}
