using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RelaxingKoala.Models
{
    public class MenuItem
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }

    }
}
