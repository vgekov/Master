using System.Collections.Generic;
using System.Threading.Tasks;
using BankWebApplication.Data;
using BankWebApplication.Models;

namespace BankWebApplication.Services
{
    public interface IUserService
    {
        void SetAccountService(string iBAN,
            int identificationNumber,
            string address,
            string bic,
            string firstName,
            string lastName,
            string id);

        Task<bool> IsSetAccount(string id);
        Task<List<TransactionViewModel>> GetAllTransactions(User user);
    }

}
