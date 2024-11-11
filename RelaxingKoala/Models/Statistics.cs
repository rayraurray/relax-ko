namespace RelaxingKoala.Models
{
	public class Statistics
	{
		public int StatisticsId { get; set; }
		public int MenuItemId { get; set; }
		public int NumberOfOrders { get; set; }
		public int AverageOrderTime { get; set; }
		public DateOnly RecordedDate { get; set; }

		// Navigation property
		public MenuItem MenuItem { get; set; }
	}
}
