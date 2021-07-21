using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BankProject.Models;
using BankProject.ViewModels;
using System.Web.Mvc;
using System.Dynamic;

namespace BankProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        BankProjectContext context = new BankProjectContext();
        public ActionResult Index()
        {
            var customers = context.AllTransactions.Include(x => x.Transactions).Include(x => x.Customers).ToList();

            return View(customers);
        }

        [HttpGet]
        public ActionResult Select(Customer customers)
        {
            var i = Session["Id"].ToString();
            int id = Convert.ToInt32(i);
            var allt = context.AllTransactions.Where(x => x.CustomerId == id).FirstOrDefault();

            if (customers == null)
                return HttpNotFound();

            var ttypes = context.Transactions.ToList();
            var viewmodel = new CreateTransactionViewModel()
            {
                Transactions = ttypes
            };
            
            
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Select(CreateTransactionViewModel viewmodel)
        {
            //var i = Session["Id"].ToString();
            //int id = Convert.ToInt32(i);
           // var customerInDb = context.Customers.Where(x => x.Id == id).FirstOrDefault();
        
            if (viewmodel.AllTransactions.TransactionId == 1)
            {

                return View("Deposit");
            }
            else
                return View("Withdraw");
        }

        [HttpGet]
        public ActionResult Deposit()
        {
            var i = Session["Id"].ToString();
            int id = Convert.ToInt32(i);
            var customerInDb = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            
            return View(customerInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(Customer customer)
        {
            var i = Session["Id"].ToString();
            int id = Convert.ToInt32(i);
            var customerInDb = context.Customers.Where(x => x.Id == id).FirstOrDefault();

            string amount = customer.Balance.ToString();

            customerInDb.Balance = (customerInDb.Balance + Int32.Parse(amount));
            context.Entry(customerInDb).State = EntityState.Modified;

            var allt = new AllTransactions()
            {
                TransactionDate = DateTime.Now,
                CustomerId = customerInDb.Id,
                TransactionId = 1
            };

            context.AllTransactions.Add(allt);
          
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        //*************************************************************************
        [HttpGet]
        public ActionResult Withdraw()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult WithDraw(Customer customer)
        {
            var i = Session["Id"].ToString();
            int id = Int32.Parse(i);
            var customerInDb = context.Customers.Single(x => x.Id == id);
            string amount = customer.Balance.ToString();

            customerInDb.Balance = (customerInDb.Balance - Int32.Parse(amount));
            if (customerInDb.Balance < 1000)
            {
                ViewBag.Message = "Transaction Failed!!\nMinimum Balance should be 1000Rs.";
                return View("Withdraw");
            }

            context.Entry(customerInDb).State = EntityState.Modified;

            var allt = new AllTransactions()
            {
                TransactionDate = DateTime.Now,
                TransactionId = 2,
                Customers = customerInDb,

                CustomerId = id
            };

            
            context.AllTransactions.Add(allt);

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //*********************************************************
        [HttpGet]
        public ActionResult SearchByDate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SearchByDate(FilterTransaction ft)
        {

            var transactions = context.AllTransactions.Where(x => x.TransactionDate >= ft.FromDate && x.TransactionDate <= ft.ToDate).ToList();
            return RedirectToAction("Index", transactions);            
        }


        
        public ActionResult CheckBalance()
        {
            var i = Session["Id"].ToString();
            int id = Convert.ToInt32(i);
            var customerInDb = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Amount = "Your Balance is Rs." + customerInDb.Balance;

            return View();
        }

    }
}


//Int32.Parse(varcount) < Int32.Parse(vmax)