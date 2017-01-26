using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
     public class DataController : Controller
     {
          [OutputCache(Duration=10)]
          public string Index()
          {
               return DateTime.Now.ToString("T");
          }
     }
}