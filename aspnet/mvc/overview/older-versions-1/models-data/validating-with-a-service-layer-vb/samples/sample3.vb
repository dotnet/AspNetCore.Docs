Public Class ProductService
Implements IProductService

Private _modelState As ModelStateDictionary
Private _repository As IProductRepository

Public Sub New(ByVal modelState As ModelStateDictionary, ByVal repository As IProductRepository)
	_modelState = modelState
	_repository = repository
End Sub

Protected Function ValidateProduct(ByVal productToValidate As Product) As Boolean
	If productToValidate.Name.Trim().Length = 0 Then
		_modelState.AddModelError("Name", "Name is required.")
	End If
	If productToValidate.Description.Trim().Length = 0 Then
		_modelState.AddModelError("Description", "Description is required.")
	End If
	If productToValidate.UnitsInStock