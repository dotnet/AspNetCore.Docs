[WebMethod]
public CascadingDropDownNameValue[] GetVendors(string knownCategoryValues, string category)
{
	SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS; 
	Integrated Security=true; Initial Catalog=AdventureWorks");
	conn.Open();
	SqlCommand comm = new SqlCommand("SELECT TOP 25 VendorID, Name 
	FROM Purchasing.Vendor",conn);
	SqlDataReader dr = comm.ExecuteReader();
	List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
	while (dr.Read())
	{
		l.Add(new CascadingDropDownNameValue(dr["Name"].ToString(),
		dr["VendorID"].ToString()));
	}
	conn.Close();
	return l.ToArray();
}