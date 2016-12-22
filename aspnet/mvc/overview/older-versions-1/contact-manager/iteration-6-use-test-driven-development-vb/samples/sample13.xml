Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class GroupControllerTest

    Private _repository As IContactManagerRepository
    Private _modelState As ModelStateDictionary
    Private _service As IContactManagerService

    <TestInitialize()> _
    Public Sub Initialize()
        _repository = New FakeContactManagerRepository()
        _modelState = New ModelStateDictionary()
        _service = New ContactManagerService(New ModelStateWrapper(_modelState), _repository)
    End Sub

    <TestMethod()> _
    Public Sub Index()
        ' Arrange
        Dim controller = New GroupController(_service)

        ' Act
        Dim result = CType(controller.Index(), ViewResult)

        ' Assert
        Assert.IsInstanceOfType(result.ViewData.Model, GetType(IEnumerable(Of Group)))
    End Sub

    <TestMethod()> _
    Public Sub Create()
        ' Arrange
        Dim controller = New GroupController(_service)

        ' Act
        Dim groupToCreate = New Group()
        groupToCreate.Name = "Business"
        controller.Create(groupToCreate)

        ' Assert
        Dim result = CType(controller.Index(), ViewResult)
        Dim groups = CType(result.ViewData.Model, IEnumerable(Of Group))
        CollectionAssert.Contains(groups.ToList(), groupToCreate)
    End Sub

    <TestMethod()> _
    Public Sub CreateRequiredName()
        ' Arrange
        Dim controller = New GroupController(_service)

        ' Act
        Dim groupToCreate = New Group()
        groupToCreate.Name = String.Empty
        Dim result = CType(controller.Create(groupToCreate), ViewResult)

        ' Assert
        Dim nameError = _modelState("Name").Errors(0)
        Assert.AreEqual("Name is required.", nameError.ErrorMessage)
    End Sub

End Class