using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using Netflix.Dto;
using Netflix.Models;

namespace Netflix.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /Api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesInDb = _context.Movies.Include(x => x.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesInDb);
        }

        //GET /Api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var moviesInDb = _context.Movies.Include(x => x.Genre).SingleOrDefault(x=>x.Id==id);



            if (moviesInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie,MovieDto>(moviesInDb));
        }

        //POST / APi/Movies/

        [HttpPost]
        public IHttpActionResult SaveMovie(MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created( new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto );
        }
        //PUT / Api/movies/1
        [HttpPut]

        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb==null)
            {
                return BadRequest();
            }

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /Api/movie/1
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb ==  null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
