﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaraAbdallah_Homework3.Models
{
    public class TransferViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "To Account #")]
        public string ToAccount { get; set; }
        [Required]
        [Display(Name = " Account #")]
        public string FromAccount { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        [Required]
        public int CheckingAccountId { get; set; }
    }
}