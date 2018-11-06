using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Netflix.Dto;
using Netflix.Models;

namespace Netflix.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/Api/Customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        } 

        //GET/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(a => a.Id == id);
            if (customer == null)
            {
                return NotFound();
            }


            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();

            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT / api /Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var customerInDb = _context.Customers.SingleOrDefault(a => a.Id == id);
            if (customerInDb == null)
            {
               // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE / api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomers(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(a => a.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
