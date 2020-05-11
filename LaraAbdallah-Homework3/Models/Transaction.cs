using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaraAbdallah_Homework3.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        [Required]
        public int CheckingAccountId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
           ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }
    }
} 