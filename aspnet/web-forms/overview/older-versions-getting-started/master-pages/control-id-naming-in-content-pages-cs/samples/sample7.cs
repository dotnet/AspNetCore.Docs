protected void SubmitButton_Click(object sender, EventArgs e)
{
	Label ResultsLabel = FindControl("Results") as Label;
	TextBox AgeTextBox = Page.FindControl("Age") as TextBox;

	ResultsLabel.Text = string.Format("You are {0} years old!", AgeTextBox.Text);
}