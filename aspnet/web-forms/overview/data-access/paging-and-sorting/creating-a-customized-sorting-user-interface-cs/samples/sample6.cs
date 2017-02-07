string currentValue = string.Empty;
if (gvr.Cells[sortColumnIndex].Controls.Count > 0)
{
    if (gvr.Cells[sortColumnIndex].Controls[0] is CheckBox)
    {
        if (((CheckBox)gvr.Cells[sortColumnIndex].Controls[0]).Checked)
            currentValue = "Yes";
        else
            currentValue = "No";
    }
    // ... Add other checks here if using columns with other
    //      Web controls in them (Calendars, DropDownLists, etc.) ...
}
else
    currentValue = gvr.Cells[sortColumnIndex].Text;