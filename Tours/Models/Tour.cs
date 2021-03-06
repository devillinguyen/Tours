﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(255)]
        public string Cover { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Description { get; set; }
        public bool TourNoiBat { get; set; }
    }
}