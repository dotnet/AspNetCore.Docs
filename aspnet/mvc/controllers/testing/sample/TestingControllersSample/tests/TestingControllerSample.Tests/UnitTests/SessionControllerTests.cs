using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Moq;
using TestingControllersSample.Controllers;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.ViewModels;
using Xunit;
namespace TestingControllerSample.Tests.UnitTests
{
    public class SessionControllerTests
    {
        [Fact]
        public void IndexReturnsARedirectToIndexHomeWhenIdIsNull()
        {
            var controller = new SessionController(sessionRepository:null);

            var result = Assert.IsType<RedirectToActionResult>(controller.Index(null));
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void IndexReturnsContentWithSessionNotFoundWhenSessionNotFound()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            int testSessionId = 1;
            mockRepo.Setup(r => r.GetById(testSessionId))
                .Returns((BrainstormSession)null);
            var controller = new SessionController(mockRepo.Object);

            var result = Assert.IsType<ContentResult>(controller.Index(testSessionId));
            Assert.Equal("Session not found.", result.Content);
        }

        [Fact]
        public void IndexReturnsViewResultWithStormSessionViewModel()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            int testSessionId = 1;
            mockRepo.Setup(r => r.GetById(testSessionId))
                .Returns(GetTestSessions().FirstOrDefault(s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object);

            var result = Assert.IsType<ViewResult>(controller.Index(testSessionId));
            var model = Assert.IsType<StormSessionViewModel>(result.ViewData.Model);

            Assert.Equal("Test One", model.Name);
            Assert.Equal(2, model.DateCreated.Day);
            Assert.Equal(testSessionId, model.Id);
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        } 
    }
}