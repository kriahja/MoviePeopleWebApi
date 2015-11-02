using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiMovieShop.Models;

namespace WebApiMovieShop.DAL.Context
{
    public class ShopContextConnectionString: DbContext
    {
        public ShopContextConnectionString(): 
            base("name=ShopContextConnectionString") { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}