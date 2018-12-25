﻿using System;
using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        //Can be List or array as well, but we use IEnumerable to iterate over objects.
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime DateTime
        {
            get { return DateTime.Parse($"{Date} {Time}"); }

        }
    }
}