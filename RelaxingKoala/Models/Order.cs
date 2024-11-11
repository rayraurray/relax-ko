namespace RelaxingKoala.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public DateTime OrderTime { get; set; }
		public int? PaymentId { get; set; }
		public int? DeliveryId { get; set; }

		// Navigation properties
		public List<Customer> Customers { get; set; }
		public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
		public Payment Payment { get; set; }
		public Delivery Delivery { get; set; }

        public Order()
        {
            Customers = new List<Customer>();
			MenuItems = new List<MenuItem>();
        }
    }
}
