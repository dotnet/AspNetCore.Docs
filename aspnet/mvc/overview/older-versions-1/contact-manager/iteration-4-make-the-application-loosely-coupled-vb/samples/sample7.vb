Public Class ModelStateWrapper
Implements IValidationDictionary

Private _modelState As ModelStateDictionary

Public Sub New(ByVal modelState As ModelStateDictionary)
	_modelState = modelState
End Sub

Public Sub AddError(ByVal key As String, ByVal errorMessage As String) Implements IValidationDictionary.AddError
	_modelState.AddModelError(key, errorMessage)
End Sub

Public ReadOnly Property IsValid() As Boolean Implements IValidationDictionary.IsValid
	Get
		Return _modelState.IsValid
	End Get
End Property

End Class