public ApplicationUserManager UserManager
{
    get
    {
        return _userManager ?? 
	HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    }
    private set
    {
        _userManager = value;
    }
}