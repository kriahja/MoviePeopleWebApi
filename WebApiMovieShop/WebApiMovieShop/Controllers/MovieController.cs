using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMovieShop.Models;
using WebApiMovieShop.Repository;

namespace WebApiMovieShop.Controllers
{
    public class MovieController : ApiController
    {
        static readonly IRepository<Movie> movieRepository = new MovieRepository();

        public IEnumerable<Movie> GetAllMovies()
        {
            return movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            Movie item = movieRepository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Movie> GetMovieByGenre(Genre genre)
        {
            return movieRepository.GetAll().Where(
                p => p.Genre == genre);
        }

        public HttpResponseMessage PostMovie(Movie item)
        {
            item = movieRepository.Add(item);
            var response = Request.CreateResponse<Movie>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void PutMovie(int id, Movie movie)
        {
            movie.Id = id;
            if (!movieRepository.Update(movie))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            movieRepository.Remove(movie);
        }
    }
}
