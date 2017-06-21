protected void DepartmentsObjectDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
{
	if (e.Exception != null)
	{
		if (e.Exception.InnerException is DuplicateAdministratorException)
		{
			var duplicateAdministratorValidator = new CustomValidator();
			duplicateAdministratorValidator.IsValid = false;
			duplicateAdministratorValidator.ErrorMessage = "Insert failed: " + e.Exception.InnerException.Message;
			Page.Validators.Add(duplicateAdministratorValidator);
			e.ExceptionHandled = true;
		}
	}
}