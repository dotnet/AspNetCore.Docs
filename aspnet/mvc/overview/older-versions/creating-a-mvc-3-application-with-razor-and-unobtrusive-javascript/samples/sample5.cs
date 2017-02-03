using System.Web.Mvc;
using Mvc3Razor.Models;

namespace Mvc3Razor.Controllers {
       
    public class HomeController : Controller {

        // The __usrs class is replacement for a real data access strategy.
        private static Users _usrs = new Users();