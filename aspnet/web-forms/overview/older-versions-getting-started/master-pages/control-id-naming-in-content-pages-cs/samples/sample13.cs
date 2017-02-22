protected void SubmitButton_Click(object sender, EventArgs e)
{
	Label ResultsLabel = Page.FindControlRecursive("Results") as Label;
	TextBox AgeTextBox = Page.FindControlRecursive("Age") as TextBox;

	ResultsLabel.Text = string.Format("You are {0} years old!", AgeTextBox.Text);
}