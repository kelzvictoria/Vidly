using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies/
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(c => c.Genre).
                Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            
        }

        //GET /api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies/*.Include(c=>c.Genre)*/.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomer)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomer)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        //DELETE /api/movies
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomer)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
