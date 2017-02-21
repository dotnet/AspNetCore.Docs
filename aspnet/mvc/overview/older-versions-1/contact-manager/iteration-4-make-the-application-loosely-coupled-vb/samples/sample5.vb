Public Interface IContactManagerService
Function CreateContact(ByVal contactToCreate As Contact) As Boolean
Function DeleteContact(ByVal contactToDelete As Contact) As Boolean
Function EditContact(ByVal contactToEdit As Contact) As Boolean
Function GetContact(ByVal id As Integer) As Contact
Function ListContacts() As IEnumerable(Of Contact)
End Interface