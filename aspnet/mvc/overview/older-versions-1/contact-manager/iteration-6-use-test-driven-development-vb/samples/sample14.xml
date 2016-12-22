Public Interface IContactManagerRepository
' Contact methods
Function CreateContact(ByVal groupId As Integer, ByVal contactToCreate As Contact) As Contact
Sub DeleteContact(ByVal contactToDelete As Contact)
Function EditContact(ByVal groupId As Integer, ByVal contactToEdit As Contact) As Contact
Function GetContact(ByVal id As Integer) As Contact

' Group methods
Function CreateGroup(ByVal groupToCreate As Group) As Group
Function ListGroups() As IEnumerable(Of Group)
Function GetGroup(ByVal groupId As Integer) As Group
Function GetFirstGroup() As Group
Sub DeleteGroup(ByVal groupToDelete As Group)

End Interface