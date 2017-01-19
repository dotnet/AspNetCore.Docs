using System.Web.Mvc;
 
namespace Movies.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is my default action...";      
        }
        
        public string Welcome()
        {  
            return "This is the Welcome action method...";
        }  
    }
}