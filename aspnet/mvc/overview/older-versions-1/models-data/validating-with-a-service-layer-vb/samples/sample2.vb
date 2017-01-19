Public Class ProductController
Inherits Controller

    Private _repository As IProductRepository

Public Sub New()
	Me.New(New ProductRepository())
End Sub


Public Sub New(ByVal repository As IProductRepository)
	_repository = repository
End Sub


Public Function Index() As ActionResult
	Return View(_repository.ListProducts())
End Function


'
' GET: /Product/Create

Public Function Create() As ActionResult
	Return View()
End Function

'
' POST: /Product/Create

<AcceptVerbs(HttpVerbs.Post)> _
Public Function Create(<Bind(Exclude:="Id")> ByVal productToCreate As Product) As ActionResult
	_repository.CreateProduct(productToCreate)
	Return RedirectToAction("Index")
End Function

End Class