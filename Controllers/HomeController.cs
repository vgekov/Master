using System.Diagnostics;
using System.Threading.Tasks;
using BankWebApplication.Data;
using BankWebApplication.Extensions;
using BankWebApplication.Models;
using BankWebApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApplication.Controllers
{
    using System.Linq;
    using static WebHelper;
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;
        private readonly ITransactionService transactionService;

        public HomeController(UserManager<User> userManager, ITransactionService transactionService, IUserService userService)
        {
            this.userManager = userManager;
            this.transactionService = transactionService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Transaction()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var isSetAccount = await userService.IsSetAccount(user.Id);
            if (!isSetAccount)
            {
                TempData.AddErrorMessage(SetYourAccount());
                return RedirectToAction("SetAccount"); ;
            }
            else
            {
                var model = new TransactionViewModel();
                // transactionService.CreateTransaction(model);
                model.User = user;

                return View(model);
            }

            //   var res = transactionService.UserTransactions(user);
        }

        [HttpPost]
        public async Task<IActionResult> Transaction(TransactionViewModel model)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            model.User = user;

            transactionService.CreateTransaction(model);

            var res = transactionService.UserTransactions(user.Id);


            return RedirectToAction("AllTransactions", model);
        }

        public async Task<IActionResult> AllTransactions()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var id = user.Id;

            var res = transactionService.UserTransactions(id);


            return View(res);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetAccount()
        {
            var user = userManager.GetUserAsync(HttpContext.User);
            var id = user.Id;

            var uRegModel = new UserRegisterViewModel();

            return View(uRegModel);
        }
        [HttpPost]
        public async Task<IActionResult> SetAccount(UserRegisterViewModel m)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var id = user.Id;
            userService.SetAccountService(m.IBAN, m.IdentificationNumber, m.Address, m.BIC, m.FirstName, m.LastName, id);

            return RedirectToAction("Transaction");
        }
        
       
    }



}
