Public Class EntityContactManagerRepository
Implements IContactManagerRepository

Private _entities As New ContactManagerDBEntities()

Public Function GetContact(ByVal id As Integer) As Contact Implements IContactManagerRepository.GetContact
	Return (From c In _entities.ContactSet _
	        Where c.Id = id _
	        Select c).FirstOrDefault()
End Function


Public Function ListContacts() As IEnumerable(Of Contact) Implements IContactManagerRepository.ListContacts
	Return _entities.ContactSet.ToList()
End Function


Public Function CreateContact(ByVal contactToCreate As Contact) As Contact Implements IContactManagerRepository.CreateContact
	_entities.AddToContactSet(contactToCreate)
	_entities.SaveChanges()
	Return contactToCreate
End Function


Public Function EditContact(ByVal contactToEdit As Contact) As Contact Implements IContactManagerRepository.EditContact
	Dim originalContact = GetContact(contactToEdit.Id)
	_entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit)
	_entities.SaveChanges()
	Return contactToEdit
End Function


Public Sub DeleteContact(ByVal contactToDelete As Contact) Implements IContactManagerRepository.DeleteContact
	Dim originalContact = GetContact(contactToDelete.Id)
	_entities.DeleteObject(originalContact)
	_entities.SaveChanges()
End Sub

End Class