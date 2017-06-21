private Guid GetApplicationID()
{
	using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
	{
		string queryString = "SELECT ApplicationId from aspnet_Applications WHERE ApplicationName = '/'"; //Set application name as in database

		SqlCommand command = new SqlCommand(queryString, connection);
		command.Connection.Open();

		var reader = command.ExecuteReader();
		while (reader.Read())
		{
			return reader.GetGuid(0);
		}

		return Guid.NewGuid();
	}
}