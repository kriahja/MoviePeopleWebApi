using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovieShop.DAL.Context;
using WebApiMovieShop.Models;

namespace WebApiMovieShop.Repository
{
    
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> movies = new List<Movie>();

        public MovieRepository()
        {
            Add(new Movie { Title = "The Martian", Description = "Aswesomenes", Price = 100, Year = DateTime.Now });
            Add(new Movie { Title = "The Plutoman", Description = "Aswesomeness", Price = 101, Year = DateTime.Now });
            Add(new Movie { Title = "The Solarman", Description = "Aswesomenesss", Price = 102, Year = DateTime.Now });
        }

        public Movie Add(Movie item)
        {
            using (var ctx = new ShopContextConnectionString())
            {
                ctx.Movies.Attach(item);
                ctx.Movies.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public Movie Get(int id)
        {
            return movies.Find(p => p.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            using (var ctx = new ShopContextConnectionString())
            {
                return movies;
                //return ctx.Movies.Include("Genre").ToList();
            }
        }

        public void Remove(Movie movie)
        {
            using (var ctx = new ShopContextConnectionString())
            {
                ctx.Movies.Attach(movie);
                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
        }

        public bool Update(Movie item)
        {
            using (var ctx = new ShopContextConnectionString())
            {

                //A gift to Lars from KBTZ team. Enjoy!
                var movieDB = ctx.Movies.FirstOrDefault(x => x.Id == item.Id);
                movieDB.Genre = ctx.Genres.FirstOrDefault(x => x.Id == item.Genre.Id);
                movieDB.Title = item.Title;
                movieDB.Price = item.Price;
                movieDB.Year = item.Year;
                movieDB.Description = item.Description;
                movieDB.url = item.url;
                movieDB.MovieCoverUrl = item.MovieCoverUrl;

                ctx.SaveChanges();
            }
            return true;
        }
    }
}