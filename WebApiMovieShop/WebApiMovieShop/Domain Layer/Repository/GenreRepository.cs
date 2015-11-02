using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovieShop.DAL.Context;
using WebApiMovieShop.Models;


namespace WebApiMovieShop.Repository
{

    public class GenreRepository : IRepository<Genre>
    {
        private List<Genre> genres = new List<Genre>();
        public Genre Add(Genre item)
        {
            using (var ctx = new ShopContextConnectionString())
            {
                //Create the queries
                ctx.Genres.Add(item);
                //Execute the queries
                ctx.SaveChanges();
            }
            return item;
        }

        public Genre Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAll()
        {
            using (var ctx = new ShopContextConnectionString())
            {
                return ctx.Genres.ToList();
            }
        }

        public void Remove(Genre movie)
        {
            throw new NotImplementedException();
        }

        public bool Update(Genre item)
        {
            throw new NotImplementedException();
        }

    }
}