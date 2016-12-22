[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class MyCorsPolicyAttribute : Attribute, ICorsPolicyProvider 
{
    private CorsPolicy _policy;

    public MyCorsPolicyAttribute()
    {
        // Create a CORS policy.
        _policy = new CorsPolicy
        {
            AllowAnyMethod = true,
            AllowAnyHeader = true
        };

        // Add allowed origins.
        _policy.Origins.Add("http://myclient.azurewebsites.net");
        _policy.Origins.Add("http://www.contoso.com");
    }

    public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request)
    {
        return Task.FromResult(_policy);
    }
}