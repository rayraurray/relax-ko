namespace RelaxingKoala.Models
{
	public class Payment
	{
		public int PaymentId { get; set; }
		public DateTime PaymentTime { get; set; }
		public int OrderId { get; set; }
		public int PaymentType { get; set; }
		public float Amount { get; set; }
		public bool PaymentStatus { get; set; }

		// Navigation properties
		public List<Customer> Customers { get; set; }
		public Order Order { get; set; }

        public Payment()
        {
            Customers = new List<Customer>();
        }
    }
}
