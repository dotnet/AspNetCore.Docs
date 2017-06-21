Public Class ProductController
Inherits Controller

Private _service As IProductService

Public Sub New()
	_service = New ProductService(Me.ModelState, New ProductRepository())
End Sub

Public Sub New(ByVal service As IProductService)
	_service = service
End Sub


Public Function Index() As ActionResult
	Return View(_service.ListProducts())
End Function


'
' GET: /Product/Create

Public Function Create() As ActionResult
	Return View()
End Function

'
' POST: /Product/Create

<AcceptVerbs(HttpVerbs.Post)> _
Public Function Create(<Bind(Exclude := "Id")> ByVal productToCreate As Product) As ActionResult
	If Not _service.CreateProduct(productToCreate) Then
		Return View()
	End If
	Return RedirectToAction("Index")
End Function

End Class