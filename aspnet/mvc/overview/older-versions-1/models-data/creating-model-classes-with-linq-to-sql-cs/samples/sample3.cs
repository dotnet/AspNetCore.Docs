using System.Collections.Generic;
namespace MvcApplication1.Models
{
     public interface IMovieRepository
     {
          IList<Movie> ListAll();
     }
}