Public Function ValidateGroup(ByVal groupToValidate As Group) As Boolean
If groupToValidate.Name.Trim().Length = 0 Then
	_validationDictionary.AddError("Name", "Name is required.")
End If
Return _validationDictionary.IsValid
End Function

Public Function CreateGroup(ByVal groupToCreate As Group) As Boolean Implements IContactManagerService.CreateGroup
    ' Validation logic
    If Not ValidateGroup(groupToCreate) Then
        Return False
    End If

    ' Database logic
    Try
        _repository.CreateGroup(groupToCreate)
    Catch
        Return False
    End Try
    Return True
End Function

Public Function ListGroups() As IEnumerable(Of Group) Implements IContactManagerService.ListGroups
    Return _repository.ListGroups()
End Function