using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;

namespace RelaxingKoala.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Orders = await _context.Orders.ToListAsync();
            ViewBag.Reservations = await _context.Reservations.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();

            return View(await _context.Customers.ToListAsync());
        }
    }
}
