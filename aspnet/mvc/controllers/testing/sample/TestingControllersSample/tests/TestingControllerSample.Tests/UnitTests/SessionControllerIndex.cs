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
    public class SessionControllerIndex
    {
        [Fact]
        public void ReturnsARedirectToIndexHomeWhenIdIsNull()
        {
            var controller = new SessionController(null);

            var result = Assert.IsType<RedirectToActionResult>(controller.Index(null));
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void ReturnsContentWithSessionNotFoundWhenSessionNotFound()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            int testSessionId = 1;
            mockRepo.Setup(r => r.GetById(testSessionId))
                .Returns((BrainStormSession)null);
            var controller = new SessionController(mockRepo.Object);

            var result = Assert.IsType<ContentResult>(controller.Index(testSessionId));
            Assert.Equal("Session not found.", result.Content);
        }

        [Fact]
        public void ReturnsViewResultWithStormSessionViewModel()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
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

        private List<BrainStormSession> GetTestSessions()
        {
            var sessions = new List<BrainStormSession>();
            sessions.Add(new BrainStormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainStormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        } 
    }
}