using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netflix.Models;

namespace Netflix.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           
        }

        //
        // GET: /Customers/
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(a => a.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {



            var customer = _context.Customers.Include(a=>a.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer!=null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }
       
	}
}