using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;

namespace RelaxingKoala.Controllers
{
    public class RestaurantTableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantTableController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tables = await _context.RestaurantTables.ToListAsync();

            return View(tables);
        }
    }
}
