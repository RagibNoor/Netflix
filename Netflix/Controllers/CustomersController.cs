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
           _context.Dispose();
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

        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.MemberShipType = membershipTypes;
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.MemberShipType = membershipTypes;
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(a => a.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }
            _context.SaveChanges();
           
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)

        {
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.MemberShipType = membershipTypes;

            var customer = _context.Customers.SingleOrDefault(a => a.Id == id);

            return View("Create",customer);
        }

       
	}
}