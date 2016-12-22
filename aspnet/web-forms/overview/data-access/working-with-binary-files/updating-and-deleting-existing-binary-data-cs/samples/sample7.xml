protected void BrochureOptions_SelectedIndexChanged(object sender, EventArgs e)
{
    // Get a reference to the RadioButtonList and its Parent
    RadioButtonList BrochureOptions = (RadioButtonList)sender;
    Control parent = BrochureOptions.Parent;
    // Now use FindControl("controlID") to get a reference of the 
    // FileUpload control
    FileUpload BrochureUpload = 
        (FileUpload)parent.FindControl("BrochureUpload");
    // Only show BrochureUpload if SelectedValue = "3"
    BrochureUpload.Visible = (BrochureOptions.SelectedValue == "3");
}