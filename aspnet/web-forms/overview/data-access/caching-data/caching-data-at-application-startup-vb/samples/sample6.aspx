<%@ Application Language="VB" %>
<script runat="server">
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        StaticCache.LoadStaticCache()
    End Sub
</script>