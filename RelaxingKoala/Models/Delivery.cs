namespace RelaxingKoala.Models
{
	public class Delivery
	{
		public int DeliveryId { get; set; }
		public int OrderId { get; set; }
		public string DeliveryAddress { get; set; }
		public DateTime DeliveryTime { get; set; }
		public string ContactNumber { get; set; }

		// Navigation property
		public Order Order { get; set; }
	}
}
