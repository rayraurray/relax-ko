namespace RelaxingKoala.Models
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public int CustomerId { get; set; }
		public DateTime ReservationTime { get; set; }

		// Navigation properties
		public Customer Customer { get; set; }
		public List<RestaurantTable> Tables { get; set; } = new List<RestaurantTable>();

        public Reservation()
        {
            Tables = new List<RestaurantTable>();
        }
    }
}
