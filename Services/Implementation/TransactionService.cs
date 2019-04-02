using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankWebApplication.Data;
using BankWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BankWebApplication.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;
        private readonly IMapper _mapper;
        public TransactionService(ApplicationDbContext db,UserManager<User> userManager,IMapper _mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this._mapper = _mapper;
        }

        public string CreateTransaction(TransactionViewModel model)
        {
         
                var newTrans = new Transaction()
                {
                    UsersTransaction = model.User,
                    TakerCompany = model.TakerCompany,
                    ReasonForPayment = model.ReasonForPaymont,
                    Date = model.Data,
                    Cash = model.Cash

                };
                db.Transactions.Add(newTrans);
                db.SaveChanges();
            return ("You successful pay ");
        }

        public List<TransactionViewModel> UserTransactions(string id)
        {
            //var r = db.Transactions.Where(u => u
            //.UsersTransaction == user).ToList();
          var res=  db.Transactions.Where(i=>i.UsersTransaction.Id==id);

            
           
            var help = new List<TransactionViewModel>();
           // var list = new TrViewModel();
           // var res = transactionService.UserTransactions(user);
            foreach (var item in res)
            {
                var tr = new TransactionViewModel();
                tr.Id = item.Id;
                tr.Cash = item.Cash;
                tr.Data = item.Date;
                tr.ReasonForPaymont = item.ReasonForPayment;
                tr.TakerCompany = item.TakerCompany;
                tr.User = item.UsersTransaction;
                help.Add(tr);
            }
            //var r = new UserViewModel();
            //r.Transactions  = transactionService.UserTransactions(user);


            //      List<PersonView> personViews =
            //Mapper.Map<List<Person>, List<PersonView>>(people);

            return help; 
        }
    }
}
