using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        #region resume
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!", Id = 1 };

        //    //return View(movie);
        //    //return Content("Hello World!");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    return RedirectToAction("Index", "Home", new {page = 1 , sortBy = "Name"});
        //}
        #endregion

        // GET: Movies/Random
        private ApplicationDbContext Context { get; set; }

        public MoviesController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var viewResult = new ViewResult();
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1 "},
                new Customer {Name = "Customer 2 "}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        //movies
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleName.CanManageMovies) ? "List" : "ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = Context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = Context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = Context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                Context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = Context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;

            }

            Context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = Context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

    }
}