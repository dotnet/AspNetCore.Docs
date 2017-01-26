protected void InstructorsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
	using (var context = new SchoolEntities())
	{
		var instructorBeingUpdated = Convert.ToInt32(e.Keys[0]);
		var officeAssignment = (from o in context.OfficeAssignments
								where o.InstructorID == instructorBeingUpdated
								select o).FirstOrDefault();

		try
		{
			if (String.IsNullOrWhiteSpace(instructorOfficeTextBox.Text) == false)
			{
				if (officeAssignment == null)
				{
					context.OfficeAssignments.AddObject(OfficeAssignment.CreateOfficeAssignment(instructorBeingUpdated, instructorOfficeTextBox.Text, null));
				}
				else
				{
					officeAssignment.Location = instructorOfficeTextBox.Text;
				}
			}
			else
			{
				if (officeAssignment != null)
				{
					context.DeleteObject(officeAssignment);
				}
			}
			context.SaveChanges();
		}
		catch (Exception)
		{
			e.Cancel = true;
			ErrorMessageLabel.Visible = true;
			ErrorMessageLabel.Text = "Update failed.";
			//Add code to log the error.
		}
	}
}