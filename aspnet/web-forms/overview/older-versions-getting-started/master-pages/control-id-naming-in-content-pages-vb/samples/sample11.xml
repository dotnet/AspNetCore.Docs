Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
 'Get a reference to the ContentPlaceHolder
 Dim MainContent As ContentPlaceHolder = CType(Page.Master.FindControl("MainContent"), ContentPlaceHolder)

 'Reference the Label and TextBox controls
 Dim ResultsLabel As Label = CType(MainContent.FindControl("Results"), Label)
 Dim AgeTextBox As TextBox = CType(MainContent.FindControl("Age"), TextBox)

 ResultsLabel.Text = String.Format("You are {0} years old!", AgeTextBox.Text)
End Sub