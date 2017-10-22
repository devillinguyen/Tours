using System.ComponentModel.DataAnnotations;

namespace Tours.Models
{
    public class Service
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}