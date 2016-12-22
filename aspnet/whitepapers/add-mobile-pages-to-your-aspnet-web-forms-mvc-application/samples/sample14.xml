public override string GetVaryByCustomString(HttpContext context, string custom)
{
    if (string.Equals(custom, "isMobileDevice", StringComparison.OrdinalIgnoreCase))
        return context.Request.Browser.IsMobileDevice.ToString();

    return base.GetVaryByCustomString(context, custom);
}