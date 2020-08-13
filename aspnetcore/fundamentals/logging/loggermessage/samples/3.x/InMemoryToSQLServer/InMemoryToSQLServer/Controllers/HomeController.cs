using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InMemoryToSQLServer.Models;
using InMemoryToSQLServer.Data;

namespace InMemoryToSQLServer.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;
        private SQLServerDbContext _SQLServerDbContext;
        private LoggerProcessor _loggerProcessor;

        public HomeController(AppDbContext db,LoggerProcessor loggerProcessor, SQLServerDbContext sqlServerDbContext)
        {
            _db = db;
            _loggerProcessor = loggerProcessor;
            _SQLServerDbContext = sqlServerDbContext;
        }

        public IActionResult Index()
        {
            Log log = new Log();
            log.message = "Index requested.";
            _loggerProcessor.EnqueueMessage(log);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
