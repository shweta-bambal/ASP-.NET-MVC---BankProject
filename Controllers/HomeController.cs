using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BankProject.Models;
using BankProject.ViewModels;
using System.Web.Mvc;

namespace BankProject.Controllers
{
    public class HomeController : Controller
    {
        BankProjectContext context = new BankProjectContext();
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            var customerInDb = context.Customers.Where(x => x.Name == customer.Name && x.Password == customer.Password).FirstOrDefault();
            if(customerInDb == null)
            {
                ViewBag.Message = "Login Failed!! Please enter valid Credentials";
                return View();
            }
            else
            {
                //var customerId = context.Customers.Where(x => x.Name == customer.Name).FirstOrDefault();

                Session["Id"] = customerInDb.Id.ToString();
                Session["Email"] = customerInDb.Email.ToString();
                Session["Name"] = customerInDb.Name.ToString();
               
                return RedirectToAction("Select", "Customers", customerInDb);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (context.Customers.Any(x => x.Email == customer.Email))
            {
                ViewBag.Message = "This Email is already Registered";
                return View("Login");
            }
            else
            {
                context.Customers.Add(customer);
                context.SaveChanges();

                Session["Id"] = customer.Id.ToString();
                Session["Email"] = customer.Email.ToString();
                Session["Name"] = customer.Name.ToString();
                return RedirectToAction("Home", "Customers", customer);
            }
           
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        
    }
}