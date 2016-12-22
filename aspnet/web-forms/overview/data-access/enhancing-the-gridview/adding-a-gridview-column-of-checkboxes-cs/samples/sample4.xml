private void ToggleCheckState(bool checkState)
{
    // Iterate through the Products.Rows property
    foreach (GridViewRow row in Products.Rows)
    {
        // Access the CheckBox
        CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
        if (cb != null)
            cb.Checked = checkState;
    }
}