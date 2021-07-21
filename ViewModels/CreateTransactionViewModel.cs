using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankProject.Models;

namespace BankProject.ViewModels
{
    public class CreateTransactionViewModel
    {
        public AllTransactions AllTransactions { get; set; }
        public Customer Customers { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}