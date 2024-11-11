namespace RelaxingKoala.Models
{
	public class RestaurantTable
	{
		public int TableId { get; set; }
		public string Name { get; set; }

		// Navigation property
		public List<Reservation> Reservations { get; set; } = new List<Reservation>();
	}
}
