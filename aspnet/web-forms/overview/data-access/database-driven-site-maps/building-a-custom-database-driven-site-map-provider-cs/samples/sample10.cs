NorthwindSiteMapProvider customProvider = 
    SiteMap.Providers["Northwind"] as NorthwindSiteMapProvider;
if (customProvider != null)
{
    DateTime? lastCachedDate = customProvider.CachedDate;
    if (lastCachedDate != null)
        LabelID.Text = "Site map cached on: " + lastCachedDate.Value.ToString();
    else
        LabelID.Text = "The site map is being reconstructed!";
}