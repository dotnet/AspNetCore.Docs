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
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfBrainstormSessions()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(r => r.List()).Returns(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            var result = Assert.IsType<ViewResult>(controller.Index());
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>
                (result.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void IndexPostReturnsAViewResultWhenModelStateIsInvalid()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(r => r.List()).Returns(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            var result = Assert.IsType<ViewResult>(controller.Index(newSession));
            Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>
                (result.ViewData.Model);
        }

        [Fact]
        public void IndexPostReturnsARedirectAndAddsSessionWhenModelStateIsValid()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(r => r.Add(It.IsAny<BrainstormSession>())).Verifiable();
            var controller = new HomeController(mockRepo.Object);
            var newSession = new HomeController.NewSessionModel()
            { SessionName = "Test Name" };

            var result = Assert.IsType<RedirectToActionResult>
                (controller.Index(newSession));
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
            mockRepo.Verify();
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