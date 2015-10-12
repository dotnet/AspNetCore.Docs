using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionSample.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;

namespace DependencyInjectionSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(IHostingEnvironment hostingEnvironment,
            ApplicationDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Environment"] = _hostingEnvironment.EnvironmentName;
            ViewData["UserCount"] = _dbContext.Users.Count();
            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
