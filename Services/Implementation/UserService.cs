using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApplication.Data;
using BankWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankWebApplication.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;

        public UserService(ApplicationDbContext db, UserManager<User> userManage)
        {
            this.db = db;
          
        }

        public void SetAccountService(string iBAN, int identificationNumber, string address, string bic, string firstName, string lastName, string id)
        {
            var us = this.db.Users.Where(u => u.Id == id).SingleOrDefault();
            us.IBAN = iBAN;
            us.IdentificationNumber = identificationNumber;
            us.Address = address;
            us.BIC = bic;
            us.FirstName = firstName;
            us.LastName = lastName;
            db.Attach(us).State = EntityState.Modified;
            db.SaveChanges();

        }

        public async Task<bool> IsSetAccount(string id)
        {
            var us = await this.db.Users.FindAsync(id);

            if (us.IdentificationNumber == 0
                || us.IBAN == null
                || us.FirstName == null
                || us.LastName == null
                || us.Address == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<TransactionViewModel>> GetAllTransactions(User user)
        {
            var id = user.Id;
            var res = db.Users.Where(u => u.Id == id).SelectMany(f=>f.Transactions).ToList();
            
            var lest = new List<TransactionViewModel>();

         foreach (var trans in res)
            {
                var r =  new TransactionViewModel();
                    r.Cash = trans.Cash;
                r.Data = trans.Date;
                r.Id = trans.Id;
                r.ReasonForPaymont = trans.ReasonForPayment;
                r.TakerCompany = trans.TakerCompany;
                r.User = user;
              lest.Add(r);
            }
            return lest;


        }

    }
}
