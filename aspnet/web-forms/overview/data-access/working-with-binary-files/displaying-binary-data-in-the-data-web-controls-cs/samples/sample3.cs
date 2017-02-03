protected string GenerateBrochureLink(object BrochurePath)
{
    if (Convert.IsDBNull(BrochurePath))
        return "No Brochure Available";
    else
        return string.Format(@"<a href="{0}">View Brochure</a>", 
            ResolveUrl(BrochurePath.ToString()));
}