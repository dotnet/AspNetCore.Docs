using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestingControllersSample.Controllers;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.ViewModels;
using Xunit;

namespace TestingControllersSample.Tests.UnitTests
{
    public class SessionControllerTests
    {
        #region snippet_SessionControllerTests
        [Fact]
        public async Task IndexReturnsARedirectToIndexHomeWhenIdIsNull()
        {
            // Arrange
            var controller = new SessionController(sessionRepository: null);

            // Act
            var result = await controller.Index(id: null);

            // Assert
            var redirectToActionResult = 
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task IndexReturnsContentWithSessionNotFoundWhenSessionNotFound()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync((BrainstormSession)null);
            var controller = new SessionController(mockRepo.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("Session not found.", contentResult.Content);
        }

        [Fact]
        public async Task IndexReturnsViewResultWithStormSessionViewModel()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<StormSessionViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal("Test One", model.Name);
            Assert.Equal(2, model.DateCreated.Day);
            Assert.Equal(testSessionId, model.Id);
        }
        #endregion

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
