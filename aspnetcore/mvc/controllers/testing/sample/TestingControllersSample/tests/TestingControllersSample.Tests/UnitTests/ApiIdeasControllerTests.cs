using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestingControllersSample.Api;
using TestingControllersSample.ClientModels;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using Xunit;

namespace TestingControllersSample.Tests.UnitTests
{
    public class ApiIdeasControllerTests
    {
        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error","some error");

            // Act
            var result = await controller.Create(model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsHttpNotFound_ForInvalidSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .Returns(Task.FromResult((BrainstormSession)null));
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.Create(new NewIdeaModel());

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsNewlyCreatedIdeaForSession()
        {
            // Arrange
            int testSessionId = 123;
            string testName = "test name";
            string testDescription = "test description";
            var testSession = GetTestSession();
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .Returns(Task.FromResult(testSession));
            var controller = new IdeasController(mockRepo.Object);

            var newIdea = new NewIdeaModel()
            {
                Description = testDescription,
                Name = testName,
                SessionId = testSessionId
            };
            mockRepo.Setup(repo => repo.UpdateAsync(testSession))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            var result = await controller.Create(newIdea);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSession = Assert.IsType<BrainstormSession>(okResult.Value);
            mockRepo.Verify();
            Assert.Equal(2, returnSession.Ideas.Count());
            Assert.Equal(testName, returnSession.Ideas.LastOrDefault().Name);
            Assert.Equal(testDescription, returnSession.Ideas.LastOrDefault().Description);
        }

        [Fact]
        public async Task ForSession_ReturnsHttpNotFound_ForInvalidSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .Returns(Task.FromResult((BrainstormSession)null));
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSession(testSessionId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testSessionId, notFoundObjectResult.Value);
        }

        [Fact]
        public async Task ForSession_ReturnsIdeasForSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId)).Returns(Task.FromResult(GetTestSession()));
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSession(testSessionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<IdeaDTO>>(okResult.Value);
            var idea = returnValue.FirstOrDefault();
            Assert.Equal("One", idea.Name);
        }

        private BrainstormSession GetTestSession()
        {
            var session = new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            };

            var idea = new Idea() { Name = "One" };
            session.AddIdea(idea);
            return session;
        }
    }
}
