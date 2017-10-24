using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinPrice(400000, ErrorMessage = "Giá nhập phải từ 400000")]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}