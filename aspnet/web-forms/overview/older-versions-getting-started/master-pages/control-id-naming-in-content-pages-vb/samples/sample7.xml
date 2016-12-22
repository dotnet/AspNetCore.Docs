Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
 Dim ResultsLabel As Label = CType(FindControl("Results"), Label)
 Dim AgeTextBox As TextBox = CType(Page.FindControl("Age"), TextBox)

 ResultsLabel.Text = String.Format("You are {0} years old!", AgeTextBox.Text)
End Sub