protected void UserGrid_RowCreated(object sender, GridViewRowEventArgs e)
{
     if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != UserGrid.EditIndex)
     {
          // Programmatically reference the Edit and Delete LinkButtons
          LinkButton EditButton = e.Row.FindControl("EditButton") as LinkButton;

          LinkButton DeleteButton = e.Row.FindControl("DeleteButton") as LinkButton;

          EditButton.Visible = (User.IsInRole("Administrators") || User.IsInRole("Supervisors"));
          DeleteButton.Visible = User.IsInRole("Administrators");
     }
}