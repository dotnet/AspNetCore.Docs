using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class GroupControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new GroupController();

            // Act
            var result = (ViewResult)controller.Index();
        
            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable));
        }
    }
}