Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
 Dim MainContent As ContentPlaceHolder = CType(FindControl("MainContent"), ContentPlaceHolder)

 Dim ResultsLabel As Label = CType(MainContent.FindControl("Results"), Label)
 Dim AgeTextBox As TextBox = CType(MainContent.FindControl("Age"), TextBox)

 ResultsLabel.Text = String.Format("You are {0} years old!", AgeTextBox.Text)
End Sub