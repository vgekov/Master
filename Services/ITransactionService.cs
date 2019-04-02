using System.Collections.Generic;
using BankWebApplication.Data;
using BankWebApplication.Models;

namespace BankWebApplication.Services
{
    public interface ITransactionService
    {
        string CreateTransaction(TransactionViewModel model);
        List<TransactionViewModel> UserTransactions(string id);
    }
}
