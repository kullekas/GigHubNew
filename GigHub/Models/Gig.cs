using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }

        [Required] //Not null
        public string ArtistID { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)] //Change length in SQL
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}