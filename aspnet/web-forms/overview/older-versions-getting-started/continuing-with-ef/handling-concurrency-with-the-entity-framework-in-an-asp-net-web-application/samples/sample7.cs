protected void DepartmentsObjectDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
{
	if (e.Exception != null)
	{
		CheckForOptimisticConcurrencyException(e, "update");
		// ...
	}
}

protected void DepartmentsObjectDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
{
	if (e.Exception != null)
	{
		CheckForOptimisticConcurrencyException(e, "delete");
	}
}