Imports System.Runtime.CompilerServices

Public Module AdHelper

    <Extension()> _
    Sub RenderBanner(ByVal helper As HtmlHelper)
        Dim context = helper.ViewContext.HttpContext
        context.Response.WriteSubstitution(AddressOf RenderBannerInternal)
    End Sub

    Private Function RenderBannerInternal(ByVal context As HttpContext) As String
        Dim ads As New List(Of String)
        ads.Add("/ads/banner1.gif")
        ads.Add("/ads/banner2.gif")
        ads.Add("/ads/banner3.gif")

        Dim rnd As New Random()
        Dim ad = ads(rnd.Next(ads.Count))
        Return String.Format("<img src='{0}' />", ad)
    End Function

End Module