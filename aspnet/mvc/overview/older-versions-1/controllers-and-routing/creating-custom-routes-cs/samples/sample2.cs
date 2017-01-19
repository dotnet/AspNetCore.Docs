using System;
using System.Web.Mvc;
namespace MvcApplication1.Controllers
{
    public class ArchiveController : Controller
    {
        public string Entry(DateTime entryDate)
        {
            return "You requested the entry from " + entryDate.ToString();
        }
    }
}