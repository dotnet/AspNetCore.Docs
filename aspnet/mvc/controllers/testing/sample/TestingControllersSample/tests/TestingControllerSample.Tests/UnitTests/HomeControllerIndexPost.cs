using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Moq;
using TestingControllersSample.Controllers;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.ViewModels;
using Xunit;
namespace TestingControllerSample.Tests.UnitTests
{
    public class HomeControllerIndexPost
    {
        [Fact]
        public void ReturnsAViewResultWhenModelStateIsInvalid()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            mockRepo.Setup(r => r.List()).Returns(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            var result = Assert.IsType<ViewResult>(controller.Index(newSession));
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(result.ViewData.Model);
        }

        [Fact]
        public void ReturnsARedirectToActionResultWhenModelStateIsValid()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            mockRepo.Setup(r => r.List()).Returns(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            var newSession = new HomeController.NewSessionModel() {SessionName = "Test Name"};

            var result = Assert.IsType<RedirectToActionResult>(controller.Index(newSession));
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
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