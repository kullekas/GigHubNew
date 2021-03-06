﻿using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
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
        [HttpPost] //On Post
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //Checks if the Model is valid.
            if (!ModelState.IsValid)
            {
                //Loads Genres from Db. Cant be 0 for validation.
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            //Returns Appliction user object, that can be associated eith this gig.
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            //Select Genre from Db.
            var gig = new Gig
            {
                ArtistID = User.Identity.GetUserId(),

                //But two stings from date in viewmodel together to one Datetime object.
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            //We have a gig object and we need to have it in the context.
            _context.Gigs.Add(gig);

            //Entity framework will make a SQL statement and save it to Db.
            _context.SaveChanges();

            //Post return. We are coing to redirect the user back to homepage.
            return RedirectToAction("Index", "Home");
        }
    }
}