// Is this Tito visiting the page?
string userName = User.Identity.Name;
if (string.Compare(userName, "Tito", true) == 0)
	// This is Tito, SHOW the Delete column
	FilesGrid.Columns[1].Visible = true;
else
	// This is NOT Tito, HIDE the Delete column
	FilesGrid.Columns[1].Visible = false;