using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.ViewModels
{
    public class MinPrice : ValidationAttribute
    {
        private readonly double _minimum;
        // Constructors
        public MinPrice(double minValue) : base("Giá trị nhập vào phải là số dương")
        {
            _minimum = minValue;
        }
        public override bool IsValid(object value)
        {
            var stringValue = value as string;// Ép kiểu string
            double numericValue;
            if (stringValue == null)
                return false;
            else if (!double.TryParse(stringValue, out numericValue) || numericValue < _minimum) // Check < _minimum
            {
                return false;
            }
            return true;
        }
    }
}