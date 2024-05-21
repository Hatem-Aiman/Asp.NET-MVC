using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Generic;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewTickets() 
        {
            TestdbContext dbContext = new();
            List<Ticket> ticketList = dbContext.Tickets.ToList();
            return Json(ticketList);
        }
        public IActionResult AddTicket(int? custid , int? rideid) 
        {
            TestdbContext dbContext = new();
            if (custid.HasValue && rideid.HasValue)
            {
               
                Ticket newticket = new()
                {
                    CustomerId = custid.Value,
                    RideId = rideid.Value
                };
                dbContext.Tickets.Add(newticket);
                dbContext.SaveChanges();
            }
            return Json("new ticket added");
        }

        public IActionResult RemoveTicket(int id)
        {
            TestdbContext ctx = new();

            var ticketToRemove = ctx.Tickets.FirstOrDefault(c => c.TicketId == id);

            if (ticketToRemove != null)
            {
                ctx.Tickets.Remove(ticketToRemove);
            }

            ctx.SaveChanges();
            return Json("Ticket removed");
        }

        }
}
