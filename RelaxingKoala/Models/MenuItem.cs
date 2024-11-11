using System.ComponentModel.DataAnnotations;

namespace RelaxingKoala.Models
{
    public class MenuItem
    {
        //Primary Key and ID
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        //Navigation Property
        public List<Menu> Menus { get; set; }

        public MenuItem()
        {
            Menus = new List<Menu>();
        }
    }
}
