using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netflix.Models;

namespace Netflix.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/
        public ActionResult Index()
        {
            var customer = GetCustomers();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            string name = null;
            int flag = 0;

            var customer = GetCustomers().Find(x => x.Id == id);
            if (customer!=null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{Name = "C1", Id = 1},
                new Customer{Name = "C2" , Id = 2}
            };

            return customers;
        } 
	}
}