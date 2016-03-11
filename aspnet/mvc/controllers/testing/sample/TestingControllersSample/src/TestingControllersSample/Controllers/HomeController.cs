using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.Infrastructure;
using TestingControllersSample.ViewModels;

namespace TestingControllersSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainStormSessionRepository _sessionRepository;

        public HomeController(IBrainStormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public IActionResult Index()
        {
            var model = _sessionRepository.List()
                .Select(s => new StormSessionViewModel()
                {
                    Id = s.Id,
                    DateCreated = s.DateCreated,
                    Name = s.Name,
                    IdeaCount = 123
                });

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
            _sessionRepository.Add(new BrainStormSession()
            {
                DateCreated = DateTime.Now,
                Name = model.SessionName
            });
            return new RedirectToActionResult("Index", "Home", null);
        }

    }
}
