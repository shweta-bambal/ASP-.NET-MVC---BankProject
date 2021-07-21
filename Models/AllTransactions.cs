using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankProject.Models
{
    public class AllTransactions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime? TransactionDate { get; set; }
        public Customer Customers { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Transaction Transactions { get; set; }

        [Required]
        [Display(Name ="Transation")]
        public int TransactionId { get; set; }
    }
}