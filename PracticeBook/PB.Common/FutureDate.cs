using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PB.Common
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime startDate;
            bool isValid = DateTime.TryParseExact(Convert.ToString(value), "d MMM yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out startDate);
            return (isValid && startDate > DateTime.Now);
        }
    }
}
