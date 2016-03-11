using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Api
{
    [Route("api/ideas")]
    public class IdeasController : Controller
    {
        private readonly IBrainStormSessionRepository _sessionRepository;

        public IdeasController(IBrainStormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [Route("forsession/{sessionId}")]
        [HttpGet]
        public IActionResult ForSession(int sessionId)
        {
            var session = _sessionRepository.GetById(sessionId);
            if (session == null)
            {
                return HttpNotFound(sessionId);
            }
            return new ObjectResult(session.Ideas.Select(i => new { id = i.Id, name=i.Name, description = i.Description, dateCreated = i.DateCreated}));
        }

        public class NewIdeaModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public int SessionId { get; set; }
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]NewIdeaModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var session = _sessionRepository.GetById(model.SessionId);
            if (session == null)
            {
                return HttpNotFound(model.SessionId);
            }
            var idea = new Idea()
            {
                DateCreated = DateTime.Now,
                Description = model.Description,
                Name = model.Name
            };
            session.AddIdea(idea);
            _sessionRepository.Update(session);
            return new ObjectResult(session);
        }
    }
}