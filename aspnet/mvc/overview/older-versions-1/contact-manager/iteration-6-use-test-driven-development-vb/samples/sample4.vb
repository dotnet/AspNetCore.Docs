<TestMethod> _
Public Sub Create()
    ' Arrange
    Dim controller = New GroupController()

    ' Act
    Dim groupToCreate = New Group()
    controller.Create(groupToCreate)

    ' Assert
    Dim result = CType(controller.Index(), ViewResult)
    Dim groups = CType(result.ViewData.Model, IEnumerable(Of Group))
    CollectionAssert.Contains(groups.ToList(), groupToCreate)
End Sub