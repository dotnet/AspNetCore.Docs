using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using RazorPagesTestSample.Pages;
using RazorPagesTestSample.Data;

namespace RazorPagesTestSample.Tests.UnitTests
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfMessages()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            #region snippet1
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var expectedMessages = AppDbContext.GetSeedingMessages();
            mockAppDbContext.Setup(
                db => db.GetMessagesAsync()).Returns(Task.FromResult(expectedMessages));
            var pageModel = new IndexModel(mockAppDbContext.Object);
            #endregion

            #region snippet2
            // Act
            await pageModel.OnGetAsync();
            #endregion

            #region snippet3
            // Assert
            var actualMessages = Assert.IsAssignableFrom<List<Message>>(pageModel.Messages);
            Assert.Equal(
                expectedMessages.OrderBy(m => m.Id).Select(m => m.Text), 
                actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            #endregion
        }

        #region snippet4
        [Fact]
        public async Task OnPostAddMessageAsync_ReturnsAPageResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var expectedMessages = AppDbContext.GetSeedingMessages();
            mockAppDbContext.Setup(db => db.GetMessagesAsync()).Returns(Task.FromResult(expectedMessages));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new IndexModel(mockAppDbContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            pageModel.ModelState.AddModelError("Message.Text", "The Text field is required.");

            // Act
            var result = await pageModel.OnPostAddMessageAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }
        #endregion

        [Fact]
        public async Task OnPostAddMessageAsync_ReturnsARedirectToPageResult_WhenModelStateIsValid()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var expectedMessages = AppDbContext.GetSeedingMessages();
            mockAppDbContext.Setup(db => db.GetMessagesAsync()).Returns(Task.FromResult(expectedMessages));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new IndexModel(mockAppDbContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            // A new ModelStateDictionary is valid by default.
            var result = await pageModel.OnPostAddMessageAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteAllMessagesAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var pageModel = new IndexModel(mockAppDbContext.Object);

            // Act
            var result = await pageModel.OnPostDeleteAllMessagesAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteMessageAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var pageModel = new IndexModel(mockAppDbContext.Object);
            var recId = 1;

            // Act
            var result = await pageModel.OnPostDeleteMessageAsync(recId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostAnalyzeMessagesAsync_ReturnsARedirectToPageResultWithCorrectAnalysis_WhenMessagesArePresent()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            var seedMessages = AppDbContext.GetSeedingMessages();
            mockAppDbContext.Setup(db => db.GetMessagesAsync()).Returns(Task.FromResult(seedMessages));
            var pageModel = new IndexModel(mockAppDbContext.Object);
            var wordCount = 0;

            foreach (var message in seedMessages)
            {
                wordCount += message.Text.Split(' ').Length;
            }

            var avgWordCount = Decimal.Divide(wordCount, seedMessages.Count);
            var expectedMessageAnalysisResultString = $"The average message length is {avgWordCount:0.##} words.";

            // Act
            var result = await pageModel.OnPostAnalyzeMessagesAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(expectedMessageAnalysisResultString, pageModel.MessageAnalysisResult);
        }

        [Fact]
        public async Task OnPostAnalyzeMessagesAsync_ReturnsARedirectToPageResultWithCorrectAnalysis_WhenNoMessagesArePresent()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockAppDbContext = new Mock<AppDbContext>(optionsBuilder.Options);
            mockAppDbContext.Setup(db => db.GetMessagesAsync()).Returns(Task.FromResult(new List<Message>()));
            var pageModel = new IndexModel(mockAppDbContext.Object);
            var expectedMessageAnalysisResultString = "There are no messages to analyze.";

            // Act
            var result = await pageModel.OnPostAnalyzeMessagesAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(expectedMessageAnalysisResultString, pageModel.MessageAnalysisResult);
        }
    }
}
