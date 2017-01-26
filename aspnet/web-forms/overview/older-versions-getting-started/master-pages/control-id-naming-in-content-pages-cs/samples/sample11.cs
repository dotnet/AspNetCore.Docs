protected void SubmitButton_Click(object sender, EventArgs e)
{
	ContentPlaceHolder MainContent = Page.Master.FindControl("MainContent") as ContentPlaceHolder;

	Label ResultsLabel = MainContent.FindControl("Results") as Label;
	TextBox AgeTextBox = MainContent.FindControl("Age") as TextBox;

	ResultsLabel.Text = string.Format("You are {0} years old!", AgeTextBox.Text);
}