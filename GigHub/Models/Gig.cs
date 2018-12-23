using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required] //Not null
        public ApplicationUser Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]  //Change length in SQL
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}