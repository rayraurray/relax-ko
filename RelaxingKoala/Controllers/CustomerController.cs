using System.Security.Cryptography.Pkcs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

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

        public async Task<IActionResult> ViewOrders(int customerId)
        {
            Customer customer = await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer.Orders);
        }

        public async Task<IActionResult> ViewReservations(int customerId)
        {
            Customer customer = await _context.Customers
                .Include(c => c.Reservations)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer.Reservations);
        }

        public async Task<IActionResult> ViewPayments(int customerId)
        {
            Customer customer = await _context.Customers
                .Include(c => c.Payments)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer.Payments);
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            ViewBag.Reservations = await _context.Reservations.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer c, string[] assignedOrders, string[] assignedReservations, string[] assignedPayments, string name, string contactInfo)
        {

            if (name != null)
            {
                c.Name = name;
            }

            if (contactInfo != null)
            {
                c.ContactInfo = contactInfo;
            }

            if (assignedOrders != null)
            {
                foreach (var orderId in assignedOrders)
                {
                    Order o = _context.Orders.Find(int.Parse(orderId));
                    c.Orders.Add(o);
                }
            }

            if (assignedReservations != null)
            {
                foreach (var reservationId in assignedReservations)
                {
                    Reservation r = _context.Reservations.Find(int.Parse(reservationId));
                    c.Reservations.Add(r);
                }
            }

            if (assignedPayments != null)
            {
                foreach (var paymentId in assignedPayments)
                {
                    Payment p = _context.Payments.Find(int.Parse(paymentId));
                    c.Payments.Add(p);
                }
            }

            _context.Customers.Add(c);

            await _context.SaveChangesAsync();

            List<Customer> customers = await _context.Customers.ToListAsync();

            return View("Index", customers);
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(int customerId)
        {
            var customer = await _context.Customers
                                      .Include(c => c.Payments)
                                      .Include(c => c.Reservations)
                                      .Include(c => c.Orders)
                                      .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.Reservations = await _context.Reservations.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyCustomer(Customer c, string[] assignedOrders, string[] assignedReservations, string[] assignedPayments, string name, string contactInfo)
        {
            Customer customer = await _context.Customers.Where(cu => cu.CustomerId == c.CustomerId)
                                      .Include(cu => cu.Payments)
                                      .Include(cu => cu.Reservations)
                                      .Include(cu => cu.Orders)
                                      .FirstOrDefaultAsync();

            if (name != null) 
            { 
                customer.Name = name;
            }

            if (contactInfo != null)
            {
                customer.ContactInfo = contactInfo;
            }

            customer.Payments.Clear();
            customer.Reservations.Clear();
            customer.Orders.Clear();

            if (assignedOrders != null)
            {
                foreach (var orderId in assignedOrders)
                {
                    Order o = _context.Orders.Find(int.Parse(orderId));
                    customer.Orders.Add(o);
                }
            }

            if (assignedReservations != null)
            {
                foreach (var reservationId in assignedReservations)
                {
                    Reservation r = _context.Reservations.Find(int.Parse(reservationId));
                    customer.Reservations.Add(r);
                }
            }

            if (assignedPayments != null)
            {
                foreach (var paymentId in assignedPayments)
                {
                    Payment p = _context.Payments.Find(int.Parse(paymentId));
                    customer.Payments.Add(p);
                }
            }

            await _context.SaveChangesAsync();

            List<Customer> customers = await _context.Customers.ToListAsync();

            return View("Index", customers);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int customerId)
        {
            return View(await _context.Customers.FindAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer c)
        {
            Customer customer = await _context.Customers.Where(cu => cu.CustomerId == c.CustomerId)
                                      .Include(cu => cu.Payments)
                                      .Include(cu => cu.Reservations)
                                      .Include(cu => cu.Orders)
                                      .FirstOrDefaultAsync();

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            List<Customer> customers = await _context.Customers.ToListAsync();

            return View("Index", customers);
        }
    }
}
