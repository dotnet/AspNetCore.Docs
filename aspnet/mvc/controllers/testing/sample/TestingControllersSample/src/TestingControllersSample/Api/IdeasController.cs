using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TestingControllersSample.ClientModels;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Api
{
    [Route("api/ideas")]
    public class IdeasController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;

        public IdeasController(IBrainstormSessionRepository sessionRepository)
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
            var result = session.Ideas.Select(i => new IdeaDTO()
            {
                id = i.Id,
                name = i.Name,
                description = i.Description,
                dateCreated = i.DateCreated
            }).ToList();
            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]NewIdeaModel model)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var session = _sessionRepository.GetById(model.SessionId);
            if (session == null)
            {
                return HttpNotFound(model.SessionId);
            }
            var idea = new Idea()
            {
                DateCreated = DateTimeOffset.Now,
                Description = model.Description,
                Name = model.Name
            };
            session.AddIdea(idea);
            _sessionRepository.Update(session);
            return Ok(session);
        }
    }
}