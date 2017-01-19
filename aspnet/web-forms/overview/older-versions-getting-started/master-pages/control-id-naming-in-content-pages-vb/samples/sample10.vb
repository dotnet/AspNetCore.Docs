'Get a reference to the master page
Dim ctl00 As MasterPage = CType(FindControl("ctl00"), MasterPage)

'Get a reference to the ContentPlaceHolder
Dim MainContent As ContentPlaceHolder = CType(ctl00.FindControl("MainContent"), ContentPlaceHolder)

'Reference the Label and TextBox controls
Dim ResultsLabel As Label = CType(MainContent.FindControl("Results"), Label)
Dim AgeTextBox As TextBox = CType(MainContent.FindControl("Age"), TextBox)