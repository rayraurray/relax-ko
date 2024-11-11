namespace RelaxingKoala.Models
{
    public class Kitchen
    {
        public int KitchenId { get; set; }
        public int MenuItemId { get; set; }
        public DateTime OrderTime { get; set; }
        public bool IsPrepared { get; set; }

        // Navigation property
        public MenuItem MenuItem { get; set; }
    }
}
