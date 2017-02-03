// Disable the paging interface buttons, if needed
FirstPage.Enabled = StartRowIndex != 0;
PrevPage.Enabled = StartRowIndex != 0;
int LastPageStartRowIndex = ((TotalRowCount - 1) / MaximumRows) * MaximumRows;
NextPage.Enabled = StartRowIndex < LastPageStartRowIndex;
LastPage.Enabled = StartRowIndex < LastPageStartRowIndex;