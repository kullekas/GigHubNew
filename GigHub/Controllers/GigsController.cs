using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

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
    

        // GET: Gigs
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                //Genres from Db to list.
                Genres = _context.Genres.ToList()

            };

            return View(viewmodel);
        }
    }
}