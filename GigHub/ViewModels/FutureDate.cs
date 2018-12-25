using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    //For Datetime field validation. 
    // Implements from ValidationAttribute for namespace
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)

        {
            DateTime dateTime;
            //Prase- Putś the input to wanted format.
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);

            // Is Datetime in future
            return (isValid && dateTime > DateTime.Now);
        }
    }
}