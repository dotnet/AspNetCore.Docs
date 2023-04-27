public class HomeController : Controller
{
    private readonly IDataProtector _dataProtector;

    public HomeController(IDataProtectionProvider dataProtectionProvider)
    {
        _dataProtector = dataProtectionProvider.CreateProtector("HomeControllerPurpose");
    }

    // ...

    public IActionResult Privacy()
    {
        // The original data to protect
        string originalData = "original data";

        // Protect the data (encrypt)
        string protectedData = _dataProtector.Protect(originalData);
        Console.WriteLine($"Protected Data: {protectedData}");

        // Unprotect the data (decrypt)
        string unprotectedData = _dataProtector.Unprotect(protectedData);
        Console.WriteLine($"Unprotected Data: {unprotectedData}");

        return View();
    }
    
    // ...
