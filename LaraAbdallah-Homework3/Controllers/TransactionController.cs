using LaraAbdallah_Homework3.Models;
using LaraAbdallah_Homework3.Services;
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
                t.Amount = 100;
                t.TransactionDate = DateTime.Now.ToString();
                t.TansactionSource = "Own Account";
                db.Transactions.Add(t);
                db.SaveChanges();
                ViewBag.Message = "Quick Cash is Successful, 100$ is reduced from your balance";
            }
            return View();
            }

        public ActionResult BalanceInquiry() {
            var Id = User.Identity.GetUserId();
            var CheckingAccount = db.CheckingAccounts.Where(x => x.ApplicationUserId == Id).First();
            ViewBag.Message = "Account #: " + CheckingAccount.AccountNumber;
            ViewBag.Message1 = "Name: " + CheckingAccount.Name;
            ViewBag.Message2 = "Your Balance is: $" + CheckingAccount.Balance;
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
            model.TransactionDate = DateTime.Now.ToString();
            model.TansactionSource = "Own Account";
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
                model.TransactionDate = DateTime.Now.ToString();
                model.TansactionSource = "Own Account";
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult print()
        {
            return View(db.Transactions.ToList());
        }

        public ActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel transfer)
        {
            var sourceCheckingAccount = db.CheckingAccounts.Find(transfer.CheckingAccountId);
            if (sourceCheckingAccount.Balance < transfer.Amount)
            {
                ModelState.AddModelError("Amount", "You have insufficient funds!");
            }

            var destinationCheckingAccount = db.CheckingAccounts.Where(c => c.AccountNumber == transfer.FromAccount).FirstOrDefault();
            if (destinationCheckingAccount == null)
            {
                ModelState.AddModelError("TransactionSource", "Invalid destination account number.");
            }

            if (ModelState.IsValid)
            {
                db.Transactions.Add(new Transaction { CheckingAccountId = transfer.CheckingAccountId, Amount = -transfer.Amount });
                db.Transactions.Add(new Transaction { CheckingAccountId = destinationCheckingAccount.Id, Amount = transfer.Amount });
                db.SaveChanges();

                var service = new CheckingAccountServices(db);
                service.UpdateBalance(transfer.CheckingAccountId);
                service.UpdateBalance(destinationCheckingAccount.Id);

                return PartialView("_TransferSuccess", transfer);
            }
            return PartialView("_TransferForm");
        }


    }
}