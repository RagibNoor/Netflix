using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netflix.Models;
using Netflix.ViewModel;

namespace Netflix.Controllers
{
    public class MoviesController : Controller
    {
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
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex , string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("PageIndex= {0}& sortBy = {1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,30)}")]
        public ActionResult ByReleaseYear(int year , int month)
        {
            return Content(year + "/" + month);
        }
	}
}