Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.Load
    ' Get the data from the SqlDataSource as a DataView
    Dim randomCategoryView As DataView = CType _
        (RandomCategoryDataSource.Select(DataSourceSelectArguments.Empty), DataView)
    If randomCategoryView.Count > 0 Then
        ' Assign the CategoryName value to the Label
        CategoryNameLabel.Text = String.Format( _
            "Here are Products in the {0} Category...", _
            randomCategoryView(0)("CategoryName").ToString())
    End If
End Sub