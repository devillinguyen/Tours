using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.ViewModels
{

    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Seat { get; set; }
        [Required]
        [MinPrice(500000, ErrorMessage = "Giá phải từ 500000 trở lên")]
        public string Price { get; set; }
    }
}