public void HandleTransients()
{
    var connStr = "some database";
    var _policy = RetryPolicy.Create < SqlAzureTransientErrorDetectionStrategy(
        retryCount: 3,
        retryInterval: TimeSpan.FromSeconds(5));

    using (var conn = new ReliableSqlConnection(connStr, _policy))
    {
        // Do SQL stuff here.
    }
}