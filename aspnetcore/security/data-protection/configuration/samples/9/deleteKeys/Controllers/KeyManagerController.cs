using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class KeyManagerController : ControllerBase
{
    private readonly IKeyManager _keyManager;

    public KeyManagerController(IKeyManager keyManager)
    {
        _keyManager = keyManager;
    }

    [HttpPost("delete-expired-keys")]
    public IActionResult DeleteExpiredKeys()
    {
        // <snippet_1>
        if (_keyManager is IDeletableKeyManager deletableKeyManager)
        {
            var utcNow = DateTimeOffset.UtcNow;
            var yearAgo = utcNow.AddYears(-1);
            if (!deletableKeyManager.DeleteKeys(key => key.ExpirationDate < yearAgo))
            {
                throw new InvalidOperationException("Failed to delete keys.");
            }
        }
        // </snippet_1>
        return Ok("Expired keys deleted successfully.");
    }
}
