using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;

namespace RelaxingKoala.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            var reservations = await _context.Reservations
            .Include(r => r.Customer)  // Include the related Customer entity
            .ToListAsync();

            return View(reservations);
        }
    }
}
