public Task CreateAsync(IdentityUser user)
{
    if (user == null) {
        throw new ArgumentNullException("user");
    }

    userTable.Insert(user);

    return Task.FromResult<object>(null);
}