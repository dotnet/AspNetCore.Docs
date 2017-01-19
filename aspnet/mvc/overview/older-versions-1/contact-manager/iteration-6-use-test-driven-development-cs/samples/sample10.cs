public bool ValidateGroup(Group groupToValidate)
{
    if (groupToValidate.Name.Trim().Length == 0)
       _validationDictionary.AddError("Name", "Name is required.");
    return _validationDictionary.IsValid;
}

public bool CreateGroup(Group groupToCreate)
{
    // Validation logic
    if (!ValidateGroup(groupToCreate))
        return false;

    // Database logic
    try
    {
        _repository.CreateGroup(groupToCreate);
    }
    catch
    {
        return false;
    }
    return true;
}

public IEnumerable<Group> ListGroups()
{
    return _repository.ListGroups();
}