using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
     public class MovieRepository : IMovieRepository
     {
          private MovieDataContext _dataContext;

          public MovieRepository()
          {
                _dataContext = new MovieDataContext();
          }

          #region IMovieRepository Members

          public IList<Movie> ListAll()
          {
               var movies = from m in _dataContext.Movies
                    select m;
               return movies.ToList();
          }

          #endregion
     }
}