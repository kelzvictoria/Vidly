using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Game of Thrones" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Victoria Kazeem" },
                new Customer {Name = "Aminat Aina" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMoviesAndCustomer))
                return View("List");
            
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomer)]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel); 
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                try
                {
                    _context.Movies.Add(movie);
                }
                catch (DbEntityValidationException e)
                {

                    Console.WriteLine(e);
                }
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomer)]
        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
    }
}