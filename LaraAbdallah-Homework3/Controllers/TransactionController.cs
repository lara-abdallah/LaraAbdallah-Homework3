using LaraAbdallah_Homework3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaraAbdallah_Homework3.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
    
       

        public ActionResult Quickcash()
        {
            var Id = User.Identity.GetUserId();
            var CheckingAccount = db.CheckingAccounts.Where(x => x.ApplicationUserId == Id).First();
            if (CheckingAccount.Balance < 100)
                ViewBag.Message = "You have no enough balance to withdraw 100$";
            else
            {
                CheckingAccount.Balance -= 100;
                Transaction t = new Transaction();
                t.CheckingAccountId = CheckingAccount.Id;
                t.Amount = -100;
                db.Transactions.Add(t);
                db.SaveChanges();
                ViewBag.Message = "Quick Cash is Successful, 100$ is reduced from your balance";
            }
            return View();
            }

        public ActionResult BalanceInquiry() {
            var Id = User.Identity.GetUserId();
            var CheckingAccount = db.CheckingAccounts.Where(x => x.ApplicationUserId == Id).First();
            ViewBag.Message = "Your Balance is $" + CheckingAccount.Balance;
             return View();
        }

        public ActionResult Deposit()
        {
            return View();
        }


        [HttpPost]
         public ActionResult Deposit(Transaction model)
        {
            var Id = User.Identity.GetUserId();
            var CheckingAccount = db.CheckingAccounts.Where(x => x.ApplicationUserId == Id).First();

            model.CheckingAccountId = CheckingAccount.Id;

            db.Transactions.Add(model);
            CheckingAccount.Balance += model.Amount;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Withdrawal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdrawal(Transaction model)
        {

            var Id = User.Identity.GetUserId();
            var CheckingAccount = db.CheckingAccounts.Where(x => x.ApplicationUserId == Id).First();
            if (CheckingAccount.Balance < model.Amount)
            {
                ViewBag.Message = "You have no enough balance to withdraw Your amount! Check you balance.";
                
            }
            else
            {
                model.CheckingAccountId = CheckingAccount.Id;

                db.Transactions.Add(model);
                CheckingAccount.Balance -= model.Amount;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult print()
        {
            var list = db.Transactions.ToList();
            return View();
        }

    }
}