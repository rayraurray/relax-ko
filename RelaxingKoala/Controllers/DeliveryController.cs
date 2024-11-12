using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

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

        public async Task<IActionResult> ChangeOrder(int orderId)
        {
            List<Delivery> deliveries;

            ViewBag.Orders = await _context.Orders.ToListAsync();
            ViewBag.SelectedMenuItem = orderId;

            if (orderId != 0)
            {
                deliveries = await _context.Deliveries.Where(d => d.Order.OrderId == orderId).ToListAsync();
            }
            else
            {
                deliveries = await _context.Deliveries.ToListAsync();
            }

            return View("Index", deliveries);
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrder(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> AddDelivery()
        {
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDelivery(Delivery d, string assignedOrder, string deliveryAddress, string contactNumber, DateTime deliveryTime)
        {

            if (assignedOrder != null)
            {
                Order o = _context.Orders.Find(int.Parse(assignedOrder));

                if (o != null)
                {
                    d.OrderId = int.Parse(assignedOrder);
                    d.Order = o;
                }
            }

            d.DeliveryAddress = deliveryAddress;
            d.ContactNumber = contactNumber;
            d.DeliveryTime = deliveryTime;

            _context.Deliveries.Add(d);

            await _context.SaveChangesAsync();

            List<Delivery> deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View("Index", deliveries);
        }

        [HttpGet]
        public async Task<IActionResult> EditDelivery(int deliveryId)
        {
            var delivery = await _context.Deliveries
                                      .Include(p => p.Order)
                                      .FirstOrDefaultAsync(d => d.DeliveryId == deliveryId);

            if (delivery == null)
            {
                return NotFound();
            }

            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View(delivery);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyDelivery(Delivery d, string assignedOrder, string deliveryAddress, string contactNumber, DateTime deliveryTime)
        {
            Delivery delivery = await _context.Deliveries.Where(de => de.DeliveryId == d.DeliveryId)
                .Include(de => de.Order)
                .FirstOrDefaultAsync();

            if (assignedOrder != null)
            {
                Order o = _context.Orders.Find(int.Parse(assignedOrder));

                if (o != null)
                {
                    delivery.OrderId = int.Parse(assignedOrder);
                    delivery.Order = o;
                }
            }

            delivery.DeliveryAddress = deliveryAddress;
            delivery.ContactNumber = contactNumber;
            delivery.DeliveryTime = deliveryTime;

            await _context.SaveChangesAsync();

            List<Delivery> deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View("Index", deliveries);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int deliveryId)
        {
            return View(await _context.Deliveries.FindAsync(deliveryId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Delivery d)
        {
            Delivery delivery = await _context.Deliveries.Where(de => de.DeliveryId == d.DeliveryId)
                .Include(de => de.Order)
                .FirstOrDefaultAsync();

            _context.Deliveries.Remove(delivery);

            await _context.SaveChangesAsync();

            List<Delivery> deliveries = await _context.Deliveries.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View("Index", deliveries);
        }
    }
}
