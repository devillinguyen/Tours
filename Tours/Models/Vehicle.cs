using System.ComponentModel.DataAnnotations;

namespace Tours.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Seat { get; set; }
        [Required]
        public decimal Price {get; set; }
    }
}