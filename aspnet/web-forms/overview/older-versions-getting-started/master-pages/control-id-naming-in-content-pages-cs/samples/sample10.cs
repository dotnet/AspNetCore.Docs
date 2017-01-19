// Get a reference to the master page
MasterPage ctl00 = FindControl("ctl00") as MasterPage;

// Get a reference to the ContentPlaceHolder
ContentPlaceHolder MainContent = ctl00.FindControl("MainContent") as ContentPlaceHolder;

// Reference the Label and TextBox controls
Label ResultsLabel = MainContent.FindControl("Results") as Label;
TextBox AgeTextBox = MainContent.FindControl("Age") as TextBox;