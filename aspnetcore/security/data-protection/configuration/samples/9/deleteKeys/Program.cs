var keyManager = services.GetService<IKeyManager>();
if (keyManager is IDeletableKeyManager deletableKeyManager)
{
    var utcNow = DateTimeOffset.UtcNow;
    var yearAgo = utcNow.AddYears(-1);
    if (!deletableKeyManager.DeleteKeys(key => key.ExpirationDate < yearAgo))
    {
        throw new InvalidOperationException("Failed to delete keys.");
    }
}
