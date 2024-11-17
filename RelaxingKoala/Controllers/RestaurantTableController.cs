using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    [Authorize(Roles = "Manager, Staff")]
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

		[HttpGet]
		public async Task<IActionResult> ViewReservations(int restaurantTableId)
		{
			var table = await _context.RestaurantTables
                .Include(t => t.Reservations)
                .FirstOrDefaultAsync(t => t.RestaurantTableId == restaurantTableId);

			if (table == null)
			{
				return NotFound();
			}

			return View(table.Reservations);
		}

		[HttpGet]
		public async Task<IActionResult> AddRestaurantTable()
		{
			ViewBag.Reservations = await _context.Reservations.ToListAsync();
			ViewBag.RestaurantTables = await _context.RestaurantTables.ToListAsync();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddRestaurantTable(RestaurantTable t, string[] assignedReservations)
		{

			if (assignedReservations != null)
			{
				foreach (var reservationId in assignedReservations)
				{
					Reservation r = _context.Reservations.Find(int.Parse(reservationId));
					t.Reservations.Add(r);
				}
			}

			_context.RestaurantTables.Add(t);

			await _context.SaveChangesAsync();

			List<RestaurantTable> tables = await _context.RestaurantTables.ToListAsync();
			ViewBag.Reservations = await _context.Reservations.ToListAsync();

			return View("Index", tables);
		}

        [HttpGet]
        public async Task<IActionResult> EditRestaurantTable(int restaurantTableId)
        {

            var table = await _context.RestaurantTables.Include(t => t.Reservations).FirstOrDefaultAsync(r => r.RestaurantTableId == restaurantTableId);

            ViewBag.Reservations = await _context.Reservations.ToListAsync();

            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyRestaurantTable(RestaurantTable t, string[] assignedReservations, string tableName)
        {
            RestaurantTable table = await _context.RestaurantTables.Where(ta => ta.RestaurantTableId == t.RestaurantTableId).Include(ta => ta.Reservations).FirstOrDefaultAsync();

            table.Reservations.Clear();

            if (assignedReservations != null)
            {
                foreach (var reservationId in assignedReservations)
                {
                    Reservation r = _context.Reservations.Find(int.Parse(reservationId));
                    table.Reservations.Add(r);
                }
            }

            table.Name = tableName;

			await _context.SaveChangesAsync();

            List<RestaurantTable> tables = await _context.RestaurantTables.ToListAsync();
            ViewBag.Reservations = await _context.Reservations.ToListAsync();

            return View("Index", tables);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
		public async Task<IActionResult> Delete(int restaurantTableId)
		{
            var table = await _context.RestaurantTables.FindAsync(restaurantTableId);
            
            return View(table);
		}

        [Authorize(Roles = "Manager")]
        [HttpPost]
		public async Task<IActionResult> Delete(RestaurantTable t)
        {
            RestaurantTable table = await _context.RestaurantTables
                .Where(ta => ta.RestaurantTableId == t.RestaurantTableId).FirstOrDefaultAsync();

            _context.RestaurantTables.Remove(table);

            await _context.SaveChangesAsync();

            List<RestaurantTable> tables = await _context.RestaurantTables.ToListAsync();
            ViewBag.Reservations = await _context.Reservations.ToListAsync();

            return View("Index", tables);
        }
    }
}
