if (RequestContext.Url == null)
{
	RequestContext.Url = new UrlHelper(Request);
}