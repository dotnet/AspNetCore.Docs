<TestMethod> _
Public Sub CreateRequiredName()
    ' Arrange
    Dim controller = New GroupController()

    ' Act
    Dim groupToCreate As New Group()
    groupToCreate.Name = String.Empty
    Dim result = CType(controller.Create(groupToCreate), ViewResult)

    ' Assert
    Dim [error] = result.ViewData.ModelState("Name").Errors(0)
    Assert.AreEqual("Name is required.", [error].ErrorMessage)
End Sub