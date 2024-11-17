using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    [Authorize(Roles = "Manager, Staff")]
    public class OrderController : Controller
	{
		private readonly ApplicationDbContext _context;

		public OrderController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Customers = await _context.Customers.ToListAsync();
			ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

			return View(await _context.Orders.ToListAsync());
		}

        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order o, string assignedPayment, string assignedDelivery, string[] assignedMenuItems, string[] assignedCustomers)
        {

            if (assignedPayment != null)
            {
                Payment p = _context.Payments.Find(int.Parse(assignedPayment));
				if (p != null)
                {
                    o.PaymentId = int.Parse(assignedPayment);
                    o.Payment = p;
                }
            }

			if (assignedDelivery != null)
			{
				Delivery d = _context.Deliveries.Find(int.Parse(assignedDelivery));
                if (d != null)
                {
                    o.DeliveryId = int.Parse(assignedDelivery);
                    o.Delivery = d;
                }
			}

            if (assignedMenuItems != null)
            {
                foreach (var menuItemId in assignedMenuItems)
                {
                    MenuItem i = _context.MenuItems.Find(int.Parse(menuItemId));
                    o.MenuItems.Add(i);
                }
            }

            if (assignedCustomers != null)
            {
                foreach (var customerId in assignedCustomers)
                {
                    Customer c = _context.Customers.Find(int.Parse(customerId));
                    o.Customers.Add(c);
                }
            }

            o.OrderTime = DateTime.Now;

			_context.Orders.Add(o);

            await _context.SaveChangesAsync();

            List<Order> orders = await _context.Orders.ToListAsync();

            return View("Index", orders);
        }

        [HttpGet]
        public async Task<IActionResult> ViewPayment(int paymentId)
        {

            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpGet]
        public async Task<IActionResult> ViewDelivery(int deliveryId)
        {

            var delivery = await _context.Deliveries.FirstOrDefaultAsync(d => d.DeliveryId == deliveryId);

            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        [HttpGet]
        public async Task<IActionResult> ViewCustomers(int orderId)
        {
            var order = await _context.Orders.Include(o => o.Customers).FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.Customers);  
        }

        [HttpGet]
        public async Task<IActionResult> ViewMenuItems(int orderId)
        {
            var order = await _context.Orders.Include(o => o.MenuItems).FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.MenuItems);
        }

        [HttpGet]
        public async Task<IActionResult> EditOrder(int orderId)
        {
            var order = await _context.Orders
                                      .Include(o => o.Payment)
                                      .Include(o => o.Delivery)
                                      .Include(o => o.Customers)
                                      .Include(o => o.MenuItems)
                                      .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();
            ViewBag.Deliveries = await _context.Deliveries.ToListAsync();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyOrder(Order o, string[] assignedMenuItems, string[] assignedCustomers, string assignedPayment, string assignedDelivery)
        {
            Order order = await _context.Orders.Where(or => or.OrderId == o.OrderId)
                                      .Include(or => or.Payment)
                                      .Include(or => or.Delivery)
                                      .Include(or => or.Customers)
                                      .Include(or => or.MenuItems)
                                      .FirstOrDefaultAsync();

            order.Customers.Clear();
            order.MenuItems.Clear();

            if (assignedPayment != null)
            {
                Payment p = _context.Payments.Find(int.Parse(assignedPayment));
                if (p != null)
                {
                    order.PaymentId = int.Parse(assignedPayment);
                    order.Payment = p;
                }
            }

            if (assignedDelivery != null)
            {
                Delivery d = _context.Deliveries.Find(int.Parse(assignedDelivery));
                if (d != null)
                {
                    order.DeliveryId = int.Parse(assignedDelivery);
                    order.Delivery = d;
                }
            }

            if (assignedCustomers != null)
            {
                foreach (var customerId in assignedCustomers)
                {
                    Customer c = _context.Customers.Find(int.Parse(customerId));
                    order.Customers.Add(c);
                }
            }

            if (assignedMenuItems != null)
            {
                foreach (var menuItemId in assignedMenuItems)
                {
                    MenuItem i = _context.MenuItems.Find(int.Parse(menuItemId));
                    order.MenuItems.Add(i);
                }
            }

            await _context.SaveChangesAsync();

            List<Order> orders = await _context.Orders.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();
            ViewBag.Deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", orders);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Delete(int orderId)
        {
            return View(await _context.Orders.FindAsync(orderId));
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Delete(Order o)
        {
            Order order = await _context.Orders.Where(or => or.OrderId == o.OrderId)
                                      .Include(or => or.Payment)
                                      .Include(or => or.Delivery)
                                      .Include(or => or.Customers)
                                      .Include(or => or.MenuItems)
                                      .FirstOrDefaultAsync();
            
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            List<Order> orders = await _context.Orders.ToListAsync();
            ViewBag.Payments = await _context.Payments.ToListAsync();
            ViewBag.Deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", orders);
        }

    }
}
