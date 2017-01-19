Public Class ProductRepository
Implements IProductRepository

    Private _entities As New ProductDBEntities()


Public Function ListProducts() As IEnumerable(Of Product) Implements IProductRepository.ListProducts
	Return _entities.ProductSet.ToList()
End Function


Public Function CreateProduct(ByVal productToCreate As Product) As Boolean Implements IProductRepository.CreateProduct
	Try
		_entities.AddToProductSet(productToCreate)
		_entities.SaveChanges()
		Return True
	Catch
		Return False
	End Try
End Function

End Class

Public Interface IProductRepository
Function CreateProduct(ByVal productToCreate As Product) As Boolean
Function ListProducts() As IEnumerable(Of Product)
End Interface