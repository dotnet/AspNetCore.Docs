protected void ExecuteButton_Click(object sender, EventArgs e)
{
	using (SchoolEntities context = new SchoolEntities())
	{
		RowsAffectedLabel.Text = context.ExecuteStoreCommand("UPDATE Course SET Credits = Credits * {0}", CreditsMultiplierTextBox.Text).ToString();
	}
}