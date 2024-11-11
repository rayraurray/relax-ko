namespace RelaxingKoala.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public string ContactInfo { get; set; }

		// Navigation properties
		public List<Order> Orders { get; set; }
		public List<Reservation> Reservations { get; set; }
		public List<Payment> Payments { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
			Reservations = new List<Reservation>();
			Payments = new List<Payment>();
        }
    }
}
