Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports Store

<TestClass()> Public Class ProductControllerTest

     <TestMethod()> Public Sub TestDetailsRedirect()
          Dim controller As New ProductController()
          Dim result As RedirectToRouteResult = controller.Details(-1)
          Assert.AreEqual("Index", result.Values("action"))
     End Sub
End Class