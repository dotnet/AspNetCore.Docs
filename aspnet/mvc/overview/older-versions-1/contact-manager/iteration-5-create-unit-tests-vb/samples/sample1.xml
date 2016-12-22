Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports System.Web.Mvc

<TestClass()> _
Public Class ContactManagerServiceTest

    Private _mockRepository As Mock(Of IContactManagerRepository)
    Private _modelState As ModelStateDictionary
    Private _service As IContactManagerService

    <TestInitialize()> _
    Public Sub Initialize()
        _mockRepository = New Mock(Of IContactManagerRepository)()
        _modelState = New ModelStateDictionary()
        _service = New ContactManagerService(new ModelStateWrapper(_modelState), _mockRepository.Object)
    End Sub

    <TestMethod()> _
    Public Sub CreateContact()
        ' Arrange
        Dim contactToCreate = Contact.CreateContact(-1, "Stephen", "Walther", "555-5555", "steve@somewhere.com")

        ' Act
        Dim result = _service.CreateContact(contactToCreate)

        ' Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod()> _
    Public Sub CreateContactRequiredFirstName()
        ' Arrange
        Dim contactToCreate = Contact.CreateContact(-1, String.Empty, "Walther", "555-5555", "steve@somewhere.com")

        ' Act
        Dim result = _service.CreateContact(contactToCreate)

        ' Assert
        Assert.IsFalse(result)
        Dim [error] = _modelState("FirstName").Errors(0)
        Assert.AreEqual("First name is required.", [error].ErrorMessage)
    End Sub

    <TestMethod()> _
    Public Sub CreateContactRequiredLastName()
        ' Arrange
        Dim contactToCreate = Contact.CreateContact(-1, "Stephen", String.Empty, "555-5555", "steve@somewhere.com")

        ' Act
        Dim result = _service.CreateContact(contactToCreate)

        ' Assert
        Assert.IsFalse(result)
        Dim [error] = _modelState("LastName").Errors(0)
        Assert.AreEqual("Last name is required.", [error].ErrorMessage)
    End Sub

    <TestMethod()> _
    Public Sub CreateContactInvalidPhone()
        ' Arrange
        Dim contactToCreate = Contact.CreateContact(-1, "Stephen", "Walther", "apple", "steve@somewhere.com")

        ' Act
        Dim result = _service.CreateContact(contactToCreate)

        ' Assert
        Assert.IsFalse(result)
        Dim [error] = _modelState("Phone").Errors(0)
        Assert.AreEqual("Invalid phone number.", [error].ErrorMessage)
    End Sub

    <TestMethod()> _
    Public Sub CreateContactInvalidEmail()
        ' Arrange
        Dim contactToCreate = Contact.CreateContact(-1, "Stephen", "Walther", "555-5555", "apple")

        ' Act
        Dim result = _service.CreateContact(contactToCreate)

        ' Assert
        Assert.IsFalse(result)
        Dim [error] = _modelState("Email").Errors(0)
        Assert.AreEqual("Invalid email address.", [error].ErrorMessage)
    End Sub
End Class