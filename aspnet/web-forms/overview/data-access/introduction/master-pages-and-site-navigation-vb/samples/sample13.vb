Partial Class UserControls_SectionLevelTutorialListing 
    Inherits UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If SiteMap.CurrentNode IsNot Nothing Then
            TutorialList.DataSource = SiteMap.CurrentNode.ChildNodes
            TutorialList.DataBind()
        End If
    End Sub
End Class