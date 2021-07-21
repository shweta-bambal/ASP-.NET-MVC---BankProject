using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using BankProject.Models;

namespace BankProject.Models
{
    public class BankProjectContext : DbContext
    {
        public BankProjectContext() : base("BankContext") { }

        public DbSet<FilterTransaction> FilterTransactions { get; set; }
        public DbSet<AllTransactions> AllTransactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}