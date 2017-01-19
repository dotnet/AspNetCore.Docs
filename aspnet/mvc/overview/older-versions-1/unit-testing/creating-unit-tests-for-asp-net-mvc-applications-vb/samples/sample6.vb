Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports Store

<TestClass()> Public Class ProductControllerTest

     <TestMethod()> Public Sub TestDetailsViewData()
          Dim controller As New ProductController()
          Dim result As ViewResult = controller.Details(2)
          Dim product As Product = result.ViewData.Model
          Assert.AreEqual("Laptop", product.Name)
     End Sub
End Class