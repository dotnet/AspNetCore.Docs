using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TestingControllersSample.Core.Model;
using TestingControllersSample.Infrastructure;
using TestingControllersSample.ViewModels;

namespace TestingControllersSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.BrainStormSessions
                .Select(s => new StormSessionViewModel()
                {
                    DateCreated = s.DateCreated,
                    Name = s.Name,
                    IdeaCount = 123
                })
                .OrderByDescending(s => s.DateCreated)
                .ToList();

            return View(model);
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public IActionResult Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                return Index();
            }
            _dbContext.BrainStormSessions.Add(new BrainStormSession()
            {
                DateCreated = DateTime.Now,
                Name = model.SessionName
            });
            _dbContext.SaveChanges();
            return new RedirectToActionResult("Index", "Home", null);
        }

    }
}
