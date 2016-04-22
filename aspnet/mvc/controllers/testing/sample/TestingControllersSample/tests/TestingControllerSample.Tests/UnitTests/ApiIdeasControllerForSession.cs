using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Moq;
using TestingControllersSample.Api;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using Xunit;
namespace TestingControllerSample.Tests.UnitTests
{
    public class ApiIdeasControllerForSession
    {
        [Fact]
        public void ReturnsHttpNotFoundForInvalidSession()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            int testSessionId = 123;
            mockRepo.Setup(r => r.GetById(testSessionId)).Returns((BrainStormSession)null);
            var controller = new IdeasController(mockRepo.Object);

            var result = Assert.IsType<HttpNotFoundObjectResult>(controller.ForSession(testSessionId));
        }

        [Fact]
        public void ReturnsIdeasForSession()
        {
            var mockRepo = new Mock<IBrainStormSessionRepository>();
            int testSessionId = 123;
            mockRepo.Setup(r => r.GetById(testSessionId)).Returns(GetTestSession());
            var controller = new IdeasController(mockRepo.Object);

            var result = Assert.IsType<ObjectResult>(controller.ForSession(testSessionId)).Value as IEnumerable<dynamic>;
            dynamic idea = result.FirstOrDefault();

            // this requires InternalsVisibleTo on the SUT project
            Assert.Equal("One", idea.name);
        }

        private BrainStormSession GetTestSession()
        {
            var session = new BrainStormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            };

            var idea = new Idea() {Name = "One"};
            session.AddIdea(idea);
            return session;
        } 
    }
}