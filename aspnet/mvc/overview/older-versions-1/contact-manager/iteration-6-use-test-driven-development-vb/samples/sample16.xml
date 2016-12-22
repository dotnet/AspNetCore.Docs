Public Class EntityContactManagerRepository
Implements IContactManagerRepository

Private _entities As New ContactManagerDBEntities()

' Contact methods

Public Function GetContact(ByVal id As Integer) As Contact Implements IContactManagerRepository.GetContact
	Return (From c In _entities.ContactSet.Include("Group") _
	        Where c.Id = id _
	        Select c).FirstOrDefault()
End Function

Public Function CreateContact(ByVal groupId As Integer, ByVal contactToCreate As Contact) As Contact Implements IContactManagerRepository.CreateContact
	' Associate group with contact
	contactToCreate.Group = GetGroup(groupId)

	' Save new contact
	_entities.AddToContactSet(contactToCreate)
	_entities.SaveChanges()
	Return contactToCreate
End Function

Public Function EditContact(ByVal groupId As Integer, ByVal contactToEdit As Contact) As Contact Implements IContactManagerRepository.EditContact
	' Get original contact
	Dim originalContact = GetContact(contactToEdit.Id)

	' Update with new group
	originalContact.Group = GetGroup(groupId)

	' Save changes
	_entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit)
	_entities.SaveChanges()
	Return contactToEdit
End Function

Public Sub DeleteContact(ByVal contactToDelete As Contact) Implements IContactManagerRepository.DeleteContact 
	Dim originalContact = GetContact(contactToDelete.Id)
	_entities.DeleteObject(originalContact)
	_entities.SaveChanges()
End Sub

    ' Group methods

Public Function CreateGroup(ByVal groupToCreate As Group) As Group Implements IContactManagerRepository.CreateGroup 
	_entities.AddToGroupSet(groupToCreate)
	_entities.SaveChanges()
	Return groupToCreate
End Function

Public Function ListGroups() As IEnumerable(Of Group) Implements IContactManagerRepository.ListGroups
	Return _entities.GroupSet.ToList()
End Function

Public Function GetFirstGroup() As Group Implements IContactManagerRepository.GetFirstGroup
	Return _entities.GroupSet.Include("Contacts").FirstOrDefault()
End Function

Public Function GetGroup(ByVal id As Integer) As Group Implements IContactManagerRepository.GetGroup
	Return (From g In _entities.GroupSet.Include("Contacts") _
	        Where g.Id = id _
	        Select g).FirstOrDefault()
End Function

Public Sub DeleteGroup(ByVal groupToDelete As Group) Implements IContactManagerRepository.DeleteGroup
	Dim originalGroup = GetGroup(groupToDelete.Id)
	_entities.DeleteObject(originalGroup)
	_entities.SaveChanges()
End Sub

End Class