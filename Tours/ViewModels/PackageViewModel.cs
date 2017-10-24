using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Tours.Models;

namespace Tours.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        //[Required]
        //[Display(Name = "Chọn Tour du lịch")]
        public int TourId { get; set; }
        public IEnumerable<Tour> Tours { get; set; } // Only Edit, Delele
        [Required(ErrorMessage = "Chưa chọn!")]
        [Display(Name = "Chọn gói dịch vụ")]
        public int ServiceId { get; set; }
        public IEnumerable<Service> Services { get; set; }
        [Required(ErrorMessage = "Chưa Chọn")]
        [Display(Name = "Chọn Xe")]
        public int VehicleId { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        [Required(ErrorMessage = "Chưa nhập")]
        [Display(Name = "Số lượng xe")]
        [MinQuantity(1, ErrorMessage = "Số lượng phải từ 1 trở lên")]
        public string Quantity { get; set; }
        public string Total { get; set; } // Only Delele
        // Foreign OM only delete action
        public Tour Tour { get; set; }
        public Service Service { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}