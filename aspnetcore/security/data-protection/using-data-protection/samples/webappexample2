public class HomeController : Controller
{
    private readonly IDataProtector _dataProtector;

    public HomeController(IDataProtectionProvider dataProtectionProvider)
    {
        _dataProtector = dataProtectionProvider.CreateProtector("HomeControllerPurpose");
    }

  // ...
