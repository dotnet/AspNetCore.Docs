Public Interface IContactManagerRepository
Function CreateContact(ByVal contactToCreate As Contact) As Contact
Sub DeleteContact(ByVal contactToDelete As Contact)
Function EditContact(ByVal contactToUpdate As Contact) As Contact
Function GetContact(ByVal id As Integer) As Contact
Function ListContacts() As IEnumerable(Of Contact)
End Interface