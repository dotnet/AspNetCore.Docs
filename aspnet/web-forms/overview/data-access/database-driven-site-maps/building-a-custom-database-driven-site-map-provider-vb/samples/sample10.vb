Dim customProvider As NorthwindSiteMapProvider = _
    TryCast(SiteMap.Providers("Northwind"), NorthwindSiteMapProvider)
If customProvider IsNot Nothing Then
    Dim lastCachedDate As Nullable(Of DateTime) = customProvider.CachedDate
    If lastCachedDate.HasValue Then
        SiteMapLastCachedDate.Text = _
            "Site map cached on: " & lastCachedDate.Value.ToString()
    Else
        SiteMapLastCachedDate.Text = "The site map is being reconstructed!"
    End If
End If