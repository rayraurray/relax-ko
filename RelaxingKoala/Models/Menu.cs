using System.ComponentModel.DataAnnotations;

namespace RelaxingKoala.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MenuItem> Items { get; set; }

        public Menu() 
        { 
            Items = new List<MenuItem>();
        }
    }
}
