Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports Store

<TestClass()> Public Class ProductControllerTest
     <TestMethod()> Public Sub TestDetailsView()
          Dim controller As New ProductController()
          Dim result As ViewResult = controller.Details(2)
          Assert.AreEqual("Details", result.ViewName)

     End Sub
End Class