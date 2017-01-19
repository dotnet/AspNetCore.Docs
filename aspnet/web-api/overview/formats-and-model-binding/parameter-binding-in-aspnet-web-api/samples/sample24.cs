config.ParameterBindingRules.Add(p =>
{
    if (p.ParameterType == typeof(ETag) && 
        p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Get))
    {
        return new ETagParameterBinding(p, ETagMatch.IfNoneMatch);
    }
    else
    {
        return null;
    }
});