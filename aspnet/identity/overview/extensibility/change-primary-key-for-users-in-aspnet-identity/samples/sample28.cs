private bool HasPassword()
{
    var user = UserManager.FindById(User.Identity.GetUserId<int>());
    if (user != null)
    {
        return user.PasswordHash != null;
    }
    return false;
}