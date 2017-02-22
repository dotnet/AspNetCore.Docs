public class CookieValueProviderFactory : ValueProviderFactory
{
    public override IValueProvider GetValueProvider(HttpActionContext actionContext)
    {
        return new CookieValueProvider(actionContext);
    }
}