using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        //Get Genres from Database.
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                //Genres from Db to list.
                Genres = _context.Genres.ToList()

            };

            return View(viewmodel);
        }

        //Form submit Action button.
        [Authorize]
        [HttpPost]  //On Post
        public ActionResult Create(GigFormViewModel viewModel)


        {
            //Makeing varaible, cause SQL sentence cant read C# language. 
            var artistId = User.Identity.GetUserId();

            //Returns Appliction user object, that can be associated eith this gig.
            var artist = _context.Users.Single(u => u.Id == artistId);

            //Select Genre from Db.
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gig
            {
                Artist = artist,

                //But two stings from date in viewmodel together to one Datetime object.
                DateTime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                Genre = genre,
                Venue = viewModel.Venue
            };

            //We have a gig object and we need to hava it in the context.
            _context.Gigs.Add(gig);

            //Entity framework will make a SQL statement and save it to Db.
            _context.SaveChanges();

            //Post return. We are coing to redirect the user back to homepage.
            return RedirectToAction("Index", "Home");

        }
    }
}