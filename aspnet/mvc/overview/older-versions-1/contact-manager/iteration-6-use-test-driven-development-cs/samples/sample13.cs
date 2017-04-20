using System.Collections.Generic;
using System.Web.Mvc;
using ContactManager.Controllers;
using ContactManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System;
using ContactManager.Tests.Models;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class GroupControllerTest
    {
        private IContactManagerRepository _repository;
        private ModelStateDictionary _modelState;
        private IContactManagerService _service;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new FakeContactManagerRepository();
            _modelState = new ModelStateDictionary();
            _service = new ContactManagerService(new ModelStateWrapper(_modelState), _repository);

        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new GroupController(_service);

            // Act
            var result = (ViewResult)controller.Index();
        
            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable));
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var controller = new GroupController(_service);

            // Act
            var groupToCreate = new Group();
            groupToCreate.Name = "Business";
            controller.Create(groupToCreate);

            // Assert
            var result = (ViewResult)controller.Index();
            var groups = (IEnumerable)result.ViewData.Model;
            CollectionAssert.Contains(groups.ToList(), groupToCreate);
        }

        [TestMethod]
        public void CreateRequiredName()
        {
            // Arrange
            var controller = new GroupController(_service);

            // Act
            var groupToCreate = new Group();
            groupToCreate.Name = String.Empty;
            var result = (ViewResult)controller.Create(groupToCreate);

            // Assert
            var error = _modelState["Name"].Errors[0];
            Assert.AreEqual("Name is required.", error.ErrorMessage);
        }
    
    }
}