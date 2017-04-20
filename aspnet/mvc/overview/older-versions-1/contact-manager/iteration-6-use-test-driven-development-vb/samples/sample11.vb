Public Class FakeContactManagerRepository
Implements IContactManagerRepository

Private _groups As IList(Of Group) = New List(Of Group)()

#Region "IContactManagerRepository Members"

' Group methods

Public Function CreateGroup(ByVal groupToCreate As Group) As Group Implements IContactManagerRepository.CreateGroup
	_groups.Add(groupToCreate)
	Return groupToCreate
End Function

Public Function ListGroups() As IEnumerable(Of Group) Implements IContactManagerRepository.ListGroups
	Return _groups
End Function

' Contact methods

Public Function CreateContact(ByVal contactToCreate As Contact) As Contact Implements IContactManagerRepository.CreateContact
	Throw New NotImplementedException()
End Function

Public Sub DeleteContact(ByVal contactToDelete As Contact) Implements IContactManagerRepository.DeleteContact
	Throw New NotImplementedException()
End Sub

Public Function EditContact(ByVal contactToEdit As Contact) As Contact Implements IContactManagerRepository.EditContact
	Throw New NotImplementedException()
End Function

Public Function GetContact(ByVal id As Integer) As Contact Implements IContactManagerRepository.GetContact
	Throw New NotImplementedException()
End Function

Public Function ListContacts() As IEnumerable(Of Contact) Implements IContactManagerRepository.ListContacts
	Throw New NotImplementedException()
End Function

#End Region
End Class