Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports System.Web.Mvc

<TestClass()> _
Public Class ContactControllerTest

    Private _service As Mock(Of IContactManagerService)

    <TestInitialize()> _
    Public Sub Initialize()
        _service = New Mock(Of IContactManagerService)()
    End Sub

    <TestMethod()> _
    Public Sub CreateValidContact()
        ' Arrange
        Dim contactToCreate = New Contact()
        _service.Expect(Function(s) s.CreateContact(contactToCreate)).Returns(True)
        Dim controller = New ContactController(_service.Object)

        ' Act
        Dim result = CType(controller.Create(contactToCreate), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

    <TestMethod()> _
    Public Sub CreateInvalidContact()
        ' Arrange
        Dim contactToCreate = New Contact()
        _service.Expect(Function(s) s.CreateContact(contactToCreate)).Returns(False)
        Dim controller = New ContactController(_service.Object)

        ' Act
        Dim result = CType(controller.Create(contactToCreate), ViewResult)

        ' Assert
        Assert.AreEqual("Create", result.ViewName)
    End Sub

End Class