using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Generic;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustController : Controller
    {
        public IActionResult Index()
        {
            return Content("Index");
        }

        public IActionResult ViewCusts()
        {
            TestdbContext dbContext = new();
            List<Customer> custList = dbContext.Customers.ToList();
            return Json(custList);
        }
        public IActionResult ViewRides()
        {
            TestdbContext dbContext = new();
            List<Ride> rideList = dbContext.Rides.ToList();
            return Json(rideList);
        }
        public IActionResult ViewTickets()
        {
            TestdbContext dbContext = new();
            List<Ticket> ticketList = dbContext.Tickets.ToList();
            return Json(ticketList);
        }

        [Route("cust/get/name/{name}")]
        public IActionResult GetCust(string name)
        {
            var ctx = new TestdbContext();
            
                var selected = (from cust in ctx.Customers
                                where cust.FirstName == name
                                select cust
                                  ).ToList();
            return Json(selected);
        }

        [Route("cust/Add")]
        public IActionResult AddCust(string first , string last , int phone , string email , int cityid)
        {
            TestdbContext dbContext = new();
            Customer newcust = new()
            {
                FirstName = first,
                LastName = last,
                Phone = phone,
                Email = email,
                CityId = cityid
            };
           dbContext.Customers.Add(newcust);
            dbContext.SaveChanges();
            return Json("new cutomer added");
        }

        [Route("cust/Remove")]
        public IActionResult RemoveCust(int id)
        {
            TestdbContext ctx = new();

            var customerToRemove = ctx.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customerToRemove != null)
            {
                ctx.Customers.Remove(customerToRemove);
            }
            ctx.SaveChanges();
            return Json("customer removed");
        }

        [Route("cust/Update")]
        public IActionResult RemoveCust(int id ,string first, string last, int phone, string email, int cityid)
        {
            TestdbContext dbContext = new();
            var customerToUpdate = dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (customerToUpdate != null) {
                if (first != null) { customerToUpdate.FirstName = first; }
                if (last != null) { customerToUpdate.LastName = last; }
                if (phone != 0) { customerToUpdate.Phone = phone; }
                if (email != null) { customerToUpdate.Email = email; }
                if (cityid != 0) { customerToUpdate.CityId = cityid; }
            }

            dbContext.SaveChanges();
            return Json("Cutomer Updated");
        }


    }
}
