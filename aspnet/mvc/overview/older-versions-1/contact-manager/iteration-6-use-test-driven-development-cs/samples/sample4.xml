[TestMethod]
public void Create()
{
    // Arrange
    var controller = new GroupController();

    // Act
    var groupToCreate = new Group();
    controller.Create(groupToCreate);

    // Assert
    var result = (ViewResult)controller.Index();
    var groups = (IEnumerable<Group>)result.ViewData.Model;
    CollectionAssert.Contains(groups.ToList(), groupToCreate);
}