using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.ViewModels
{
    public class TourViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [MinPrice(700000,ErrorMessage = "Số nhập vào phải từ 700000")]
        public string Price { get; set; }
        [Required]
        public string Cover { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Description { get; set; }
    }
}