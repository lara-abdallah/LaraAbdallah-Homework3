using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using LaraAbdallah_Homework3.Models;

namespace LaraAbdallah_Homework3.Services
{
    public class CheckingAccountServices
    {
        private ApplicationDbContext db;
        public CheckingAccountServices(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public void CreateCheckingAccount(string firstName,string lastName,string userId,decimal initialBalance)
        {
            var accountNumber = (12345 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');
            var checkingAccount = new CheckingAccount { FirstName = firstName, LastName = lastName, AccountNumber = accountNumber, Balance = initialBalance, ApplicationUserId = userId };
            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();
        }
    }
}