protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
{
	// Open the file and display it
	string fullFileName = FilesGrid.SelectedValue.ToString();
	string contents = File.ReadAllText(fullFileName);
	FileContents.Text = contents;
}