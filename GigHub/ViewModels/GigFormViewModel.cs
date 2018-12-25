using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate] //This comes from created FutureDate Class.
        public string Date { get; set; }

        [Required(ErrorMessage = "Välja Time täitmine on kohustuslik. ")]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }
        //Can be List or array as well, but we use IEnumerable to iterate over objects.
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            //Parse will try to parse Your string to Datetime format.
            return DateTime.Parse($"{Date} {Time}");

        }
    }
}