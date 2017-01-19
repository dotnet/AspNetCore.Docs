Public Class News

    Shared Function RenderNews(ByVal context As HttpContext) As String
        Dim newsItems As New List(Of String)
        newsItems.Add("Gas prices go up!")
        newsItems.Add("Life discovered on Mars!")
        newsItems.Add("Moon disappears!")

        Dim rnd As New Random()
        Return newsItems(rnd.Next(newsItems.Count))
    End Function

End Class