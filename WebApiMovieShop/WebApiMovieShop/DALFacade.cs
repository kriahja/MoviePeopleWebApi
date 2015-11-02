using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovieShop.Models;

namespace WebApiMovieShop
{
    public class DALFacade
    {
        System.Data.Entity.SqlServer.SqlProviderServices
        sqlprovider = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        private IRepository<Movie> movieRepository;
        private IRepository<Genre> genreRepository;

    }
}