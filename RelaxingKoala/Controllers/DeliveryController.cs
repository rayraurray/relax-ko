using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;

namespace RelaxingKoala.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View(await _context.Deliveries.ToListAsync());
        }
    }
}
