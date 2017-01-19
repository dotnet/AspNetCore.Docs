Protected Function GenerateBrochureLink(BrochurePath As Object) As String
    If Convert.IsDBNull(BrochurePath) Then
        Return "No Brochure Available"
    Else
        Return String.Format("<a href="{0}">View Brochure</a>", _
            ResolveUrl(BrochurePath.ToString()))
    End If
End Function