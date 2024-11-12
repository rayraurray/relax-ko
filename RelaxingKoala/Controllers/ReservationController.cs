using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

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
                .Include(r => r.Customer)
                .ToListAsync();

            return View(reservations);
        }

        public async Task<IActionResult> ChangeCustomer(int customerId)
        {
            List<Reservation> filteredReservations;

            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.SelectedCustomer = customerId;

            if (customerId != 0)
            {
                filteredReservations = await _context.Reservations.Where(r => r.Customer.CustomerId == customerId).ToListAsync();
            }
            else
            {
                filteredReservations = await _context.Reservations.ToListAsync();
            }

            return View("Index", filteredReservations);
        }

        [HttpGet]
        public async Task<IActionResult> AddReservation()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.RestaurantTables = await _context.RestaurantTables.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation r, string assignedCustomer, string[] assignedRestaurantTables)
        {

            if (assignedCustomer != null)
            {
                Customer c = _context.Customers.Find(int.Parse(assignedCustomer));

                if (c != null)
                {
                    r.CustomerId = int.Parse(assignedCustomer);
                    r.Customer = c;
                }
            }

            if (assignedRestaurantTables != null)
            {
                foreach (var restaurantTableId in assignedRestaurantTables)
                {
                    RestaurantTable rt = _context.RestaurantTables.Find(int.Parse(restaurantTableId));
                    r.Tables.Add(rt);
                }
            }

            _context.Reservations.Add(r);

            await _context.SaveChangesAsync();

            List<Reservation> reservations = await _context.Reservations.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();

            return View("Index", reservations);
        }

        [HttpGet]
        public async Task<IActionResult> ViewTables(int reservationId)
        {
            var reservation = await _context.Reservations.Include(r => r.Tables).FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation.Tables);
        }

        [HttpGet]
        public async Task<IActionResult> EditReservation(int reservationId)
        {

            var reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Tables).FirstOrDefaultAsync();

            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.RestaurantTables = await _context.RestaurantTables.ToListAsync();

            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyReservation(Reservation r, string assignedCustomer, string[] assignedTables)
        {
            Reservation reservation = await _context.Reservations.Where(re => re.ReservationId == r.ReservationId)
                .Include(re => re.Customer)
                .Include(re => re.Tables).FirstOrDefaultAsync();

            reservation.Tables.Clear();

            if (assignedCustomer != null)
            {
                Customer c = _context.Customers.Find(int.Parse(assignedCustomer));

                if (c != null)
                {
                    reservation.CustomerId = int.Parse(assignedCustomer);

                    reservation.Customer = c;
                }
            }

            if (assignedTables != null)
            {
                foreach (var restaurantTableId in assignedTables)
                {
                    RestaurantTable t = _context.RestaurantTables.Find(int.Parse(restaurantTableId));
                    reservation.Tables.Add(t);
                }
            }

            await _context.SaveChangesAsync();

            List<Reservation> reservations = await _context.Reservations.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.RestaurantTables = await _context.RestaurantTables.ToListAsync();

            return View("Index", reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int reservationId)
        {
            ViewBag.Reservations = await _context.Reservations.ToListAsync();

            return View(await _context.Reservations.FindAsync(reservationId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Reservation r)
        {
            Reservation reservation = await _context.Reservations.Where(re => re.ReservationId == r.ReservationId)
                .Include(re => re.Customer)
                .Include(re => re.Tables).FirstOrDefaultAsync();

            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync();

            List<Reservation> reservations = await _context.Reservations.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.RestaurantTables = await _context.RestaurantTables.ToListAsync();

            return View("Index", reservations);
        }
    }
}
