Public Class ContactManagerService
Implements IContactManagerService

Private _validationDictionary As IValidationDictionary
Private _repository As IContactManagerRepository


Public Sub New(ByVal validationDictionary As IValidationDictionary)
	Me.New(validationDictionary, New EntityContactManagerRepository())
End Sub


Public Sub New(ByVal validationDictionary As IValidationDictionary, ByVal repository As IContactManagerRepository)
	_validationDictionary = validationDictionary
	_repository = repository
End Sub


Public Function ValidateContact(ByVal contactToValidate As Contact) As Boolean
	If contactToValidate.FirstName.Trim().Length = 0 Then
		_validationDictionary.AddError("FirstName", "First name is required.")
	End If
	If contactToValidate.LastName.Trim().Length = 0 Then
		_validationDictionary.AddError("LastName", "Last name is required.")
	End If
	If contactToValidate.Phone.Length > 0 AndAlso (Not Regex.IsMatch(contactToValidate.Phone, "((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")) Then
		_validationDictionary.AddError("Phone", "Invalid phone number.")
	End If
	If contactToValidate.Email.Length > 0 AndAlso (Not Regex.IsMatch(contactToValidate.Email, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) Then
		_validationDictionary.AddError("Email", "Invalid email address.")
	End If
	Return _validationDictionary.IsValid
End Function


#Region "IContactManagerService Members"

Public Function CreateContact(ByVal contactToCreate As Contact) As Boolean Implements IContactManagerService.CreateContact
	' Validation logic
	If Not ValidateContact(contactToCreate) Then
		Return False
	End If

	' Database logic
	Try
		_repository.CreateContact(contactToCreate)
	Catch
		Return False
	End Try
	Return True
End Function

Public Function EditContact(ByVal contactToEdit As Contact) As Boolean Implements IContactManagerService.EditContact
	' Validation logic
	If Not ValidateContact(contactToEdit) Then
		Return False
	End If

	' Database logic
	Try
		_repository.EditContact(contactToEdit)
	Catch
		Return False
	End Try
	Return True
End Function

Public Function DeleteContact(ByVal contactToDelete As Contact) As Boolean Implements IContactManagerService.DeleteContact
	Try
		_repository.DeleteContact(contactToDelete)
	Catch
		Return False
	End Try
	Return True
End Function

Public Function GetContact(ByVal id As Integer) As Contact Implements IContactManagerService.GetContact
	Return _repository.GetContact(id)
End Function

Public Function ListContacts() As IEnumerable(Of Contact) Implements IContactManagerService.ListContacts
	Return _repository.ListContacts()
End Function

#End Region
End Class