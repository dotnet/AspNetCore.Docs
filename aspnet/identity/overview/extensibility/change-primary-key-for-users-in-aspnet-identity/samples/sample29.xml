private bool HasPhoneNumber()
{
    var user = UserManager.FindById(User.Identity.GetUserId<int>());
    if (user != null)
    {
        return user.PhoneNumber != null;
    }
    return false;
}