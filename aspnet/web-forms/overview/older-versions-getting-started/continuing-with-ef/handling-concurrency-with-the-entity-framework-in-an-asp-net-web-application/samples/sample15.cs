protected void Page_Init(object sender, EventArgs e)
{
	OfficeAssignmentsGridView.EnableDynamicData(typeof(OfficeAssignment));
}

protected void OfficeAssignmentsObjectDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
{
	if (e.Exception != null)
	{
		var concurrencyExceptionValidator = new CustomValidator();
		concurrencyExceptionValidator.IsValid = false;
		concurrencyExceptionValidator.ErrorMessage = "The record you attempted to " +
			"update has been modified by another user since you last visited this page. " +
			"Your update was canceled to allow you to review the other user's " +
			"changes and determine if you still want to update this record.";
		Page.Validators.Add(concurrencyExceptionValidator);
		e.ExceptionHandled = true;
	}
}