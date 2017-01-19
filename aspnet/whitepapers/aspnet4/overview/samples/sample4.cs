public override string GetOutputCacheProviderName(HttpContext context)
{
    if (context.Request.Path.EndsWith("Advanced.aspx"))
       return "DiskCache";
    else
        return base.GetOutputCacheProviderName(context);
}