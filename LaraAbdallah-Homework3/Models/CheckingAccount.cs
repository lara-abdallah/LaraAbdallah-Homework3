using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaraAbdallah_Homework3.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^[0-9]*$")]
        [Display(Name="Account #")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name="FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public string Name { get
            {
                return String.Format("{0} {1}", this.FirstName, this.LastName); 
            } }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public virtual ApplicationUser user { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }


    }
}