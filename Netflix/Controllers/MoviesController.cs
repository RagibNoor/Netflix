using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netflix.Models;
using Netflix.ViewModel;

namespace Netflix.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //
        // GET: /Movies/
        public ActionResult Random()
        {
            var movie =new  Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer{Name = "C1"},
                new Customer{Name = "C2"}
            };

            var viewModel = new  RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Genre = _context.Genres.ToList();
            var movieInDb = _context.Movies.SingleOrDefault(a => a.Id == id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            return View("Save", movieInDb);
        }
        [HttpGet]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(a => a.Genre).ToList();
            return View(movies);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            ViewBag.Genre = _context.Genres.ToList();
            if (movie.Id==0)
            {
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(a => a.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
            }
            _context.SaveChanges();
           // var movies = _context.Movies.Include(a => a.Genre).ToList();
            return RedirectToAction("Index");
        }

        public ActionResult Save()
        {
            ViewBag.Genre = _context.Genres.ToList();

            return View();
        }
        public ActionResult Details(int id)

        {
            var movie = _context.Movies.Include(a => a.Genre).FirstOrDefault(a => a.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,30)}")]
        public ActionResult ByReleaseYear(int year , int month)
        {
            return Content(year + "/" + month);
        }
	}
}