public class CorsPolicyFactory : ICorsPolicyProviderFactory
{
    ICorsPolicyProvider _provider = new MyCorsPolicyProvider();

    public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
    {
        return _provider;
    }
}