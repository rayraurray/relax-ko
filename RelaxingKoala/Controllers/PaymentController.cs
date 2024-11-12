using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View(await _context.Payments.ToListAsync());
        }

        public async Task<IActionResult> ChangeOrder(int orderId)
        {
            List<Payment> payments;

            ViewBag.Orders = await _context.Orders.ToListAsync();
            ViewBag.SelectedMenuItem = orderId;

            if (orderId != 0)
            {
                payments = await _context.Payments.Where(p => p.Order.OrderId == orderId).ToListAsync();
            }
            else
            {
                payments = await _context.Payments.ToListAsync();
            }

            return View("Index", payments);
        }

		[HttpGet]
		public async Task<IActionResult> AddPayment()
		{
			ViewBag.Customers = await _context.Customers.ToListAsync();
			ViewBag.Orders = await _context.Orders.ToListAsync();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddPayment(Payment p, string assignedOrder, string[] assignedCustomers, float amount, bool paymentStatus, string paymentType, DateTime paymentTime)
		{

			if (assignedOrder != null)
			{
				Order o = _context.Orders.Find(int.Parse(assignedOrder));

				if (o != null)
				{
					p.OrderId = int.Parse(assignedOrder);
					p.Order = o;
				}
			}

			if (assignedCustomers != null)
			{
				foreach (var customerId in assignedCustomers)
				{
					Customer c = _context.Customers.Find(int.Parse(customerId));
					p.Customers.Add(c);
				}
			}

            p.PaymentTime = paymentTime;
			p.PaymentStatus = paymentStatus;
            p.PaymentType = int.Parse(paymentType);
			p.Amount = amount;

			_context.Payments.Add(p);

			await _context.SaveChangesAsync();

			List<Payment> payments = await _context.Payments.ToListAsync();
			ViewBag.Customers = await _context.Customers.ToListAsync();
			ViewBag.Orders = await _context.Orders.ToListAsync();

			return View("Index", payments);
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
        public async Task<IActionResult> ViewDelivery(int deliveryId)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(d => d.DeliveryId== deliveryId);

            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        [HttpGet]
        public async Task<IActionResult> ViewCustomers(int paymentId)
        {
            var payment = await _context.Payments
                .Include(p => p.Customers)
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment.Customers);
        }

        [HttpGet]
        public async Task<IActionResult> EditPayment(int paymentId)
        {
            var payment = await _context.Payments
                                      .Include(p => p.Customers)
                                      .Include(p => p.Order)
                                      .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
            {
                return NotFound();
            }

            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();


            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyPayment(Payment p, string assignedOrder, string[] assignedCustomers, float amount, bool paymentStatus, string paymentType, DateTime paymentTime)
        {
            Payment payment = await _context.Payments.Where(pa => pa.PaymentId == p.PaymentId)
                .Include(pa => pa.Customers)
                .Include(pa => pa.Order)
                .FirstOrDefaultAsync();

            payment.Customers.Clear();

            if (assignedOrder != null)
            {
                Order o = _context.Orders.Find(int.Parse(assignedOrder));

                if (o != null)
                {
                    payment.OrderId = int.Parse(assignedOrder);
                    payment.Order = o;
                }
            }

            if (assignedCustomers != null)
            {
                foreach (var customerId in assignedCustomers)
                {
                    Customer c = _context.Customers.Find(int.Parse(customerId));
                    payment.Customers.Add(c);
                }
            }

            payment.PaymentTime = paymentTime;
            payment.PaymentStatus = paymentStatus;
            payment.PaymentType = int.Parse(paymentType);
            payment.Amount = amount;

            await _context.SaveChangesAsync();

            List<Payment> payments = await _context.Payments.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View("Index", payments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int paymentId)
        {
            return View(await _context.Payments.FindAsync(paymentId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Payment p)
        {
            Payment payment = await _context.Payments.Where(pa => pa.PaymentId == p.PaymentId)
                                      .Include(pa => pa.Customers)
                                      .Include(pa => pa.Order).FirstOrDefaultAsync();

            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();

            List<Payment> payments = await _context.Payments.ToListAsync();
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.Orders = await _context.Orders.ToListAsync();

            return View("Index", payments);
        }

    }
}
