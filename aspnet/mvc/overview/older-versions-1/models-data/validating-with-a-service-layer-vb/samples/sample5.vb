Public Class ProductService
Implements IProductService

Private _validatonDictionary As IValidationDictionary
Private _repository As IProductRepository

Public Sub New(ByVal validationDictionary As IValidationDictionary, ByVal repository As IProductRepository)
	_validatonDictionary = validationDictionary
	_repository = repository
End Sub

Protected Function ValidateProduct(ByVal productToValidate As Product) As Boolean
	If productToValidate.Name.Trim().Length = 0 Then
		_validatonDictionary.AddError("Name", "Name is required.")
	End If
	If productToValidate.Description.Trim().Length = 0 Then
		_validatonDictionary.AddError("Description", "Description is required.")
	End If
	If productToValidate.UnitsInStock