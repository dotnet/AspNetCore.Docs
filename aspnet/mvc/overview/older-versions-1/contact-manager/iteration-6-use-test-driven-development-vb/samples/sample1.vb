Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class GroupControllerTest

    <TestMethod()> _
    Public Sub Index()
        ' Arrange
        Dim controller = New GroupController()

        ' Act
        Dim result = CType(controller.Index(), ViewResult)

        ' Assert
        Assert.IsInstanceOfType(result.ViewData.Model, GetType(IEnumerable(Of Group)))
    End Sub
End Class