string sql = "SELECT ProductName, ProductID FROM Products";
SqlConnection conn = new
SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
SqlCommand cmd = new SqlCommand(sql, conn);
SqlCacheDependency dep = new SqlCacheDependency(cmd);
Response.AddCacheDependency(dep);