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
    public class HomeControllerIndex
    {
        [Fact]
        public void ReturnsAViewResultWithAListOfBrainstormSessions()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            mockRepo.Setup(r => r.List()).Returns(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            var result = Assert.IsType<ViewResult>(controller.Index());
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(result.ViewData.Model);
            Assert.Equal(2, model.Count());
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