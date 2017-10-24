using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tours.ViewModels
{
    public class MinQuantity : ValidationAttribute
    {
        private readonly int _minimum;
        // Constructors
        public MinQuantity(int minValue) : base("Giá trị nhập vào phải là số nguyên dương")
        {
            _minimum = minValue;
        }
        public override bool IsValid(object value)
        {
            var stringValue = value as string;// Ép kiểu string
            int numericValue;
            if (stringValue == null)
                return false;
            else if (!int.TryParse(stringValue, out numericValue) || numericValue < _minimum) // Check < _minimum
            {
                return false;
            }
            return true;
        }
    }
}