protected void FilesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
	string fullFileName = FilesGrid.DataKeys[e.RowIndex].Value.ToString();
	FileContents.Text = string.Format("You have opted to delete {0}.", fullFileName);

	// To actually delete the file, uncomment the following line
	// File.Delete(fullFileName);
}