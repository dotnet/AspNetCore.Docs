[TestMethod]
public void CreateRequiredName()
{
    // Arrange
    var controller = new GroupController();

    // Act
    var groupToCreate = new Group();
    groupToCreate.Name = String.Empty;
    var result = (ViewResult)controller.Create(groupToCreate);

    // Assert
    var error = result.ViewData.ModelState["Name"].Errors[0];
    Assert.AreEqual("Name is required.", error.ErrorMessage);
}