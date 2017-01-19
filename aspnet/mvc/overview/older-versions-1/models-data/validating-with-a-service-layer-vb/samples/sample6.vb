Public Interface IValidationDictionary
Sub AddError(ByVal key As String, ByVal errorMessage As String)
ReadOnly Property IsValid() As Boolean
End Interface