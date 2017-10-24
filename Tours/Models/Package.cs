﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tours.ViewModels;

namespace Tours.Models
{
    public class Package
    {
        public int Id { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int QuantityVehi { get; set; }
        public decimal Total { get; set; }
        // ForeignOM
        public Tour Tour { get; set; }
        public Service Service { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}