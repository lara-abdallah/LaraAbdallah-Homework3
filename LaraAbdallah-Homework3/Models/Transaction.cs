﻿using System;
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

        [DataType(DataType.DateTime)]
        public string TransactionDate { get; set; }
        [Required]
        public string TansactionSource { get; set; }
    }
} 