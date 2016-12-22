Protected Sub BrochureOptions_SelectedIndexChanged _
    (sender As Object, e As EventArgs)
    
    ' Get a reference to the RadioButtonList and its Parent
    Dim BrochureOptions As RadioButtonList = _
        CType(sender, RadioButtonList)
    Dim parent As Control = BrochureOptions.Parent
    ' Now use FindControl("controlID") to get a reference of the 
    ' FileUpload control
    Dim BrochureUpload As FileUpload = _
        CType(parent.FindControl("BrochureUpload"), FileUpload)
    ' Only show BrochureUpload if SelectedValue = "3"
    BrochureUpload.Visible = (BrochureOptions.SelectedValue = "3")
End Sub