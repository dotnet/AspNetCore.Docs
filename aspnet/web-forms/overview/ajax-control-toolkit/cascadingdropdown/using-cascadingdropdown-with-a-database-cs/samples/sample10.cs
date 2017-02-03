SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS; 
 Integrated Security=true; Initial Catalog=AdventureWorks");
 conn.Open();
 SqlCommand comm = new SqlCommand("SELECT Person.Contact.ContactID, FirstName, LastName 
 FROM Person.Contact,Purchasing.VendorContact 
 WHERE VendorID=@VendorID 
 AND Person.Contact.ContactID=Purchasing.VendorContact.ContactID",conn);
 comm.Parameters.AddWithValue("@VendorID", VendorID);
 SqlDataReader dr = comm.ExecuteReader();
 List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
 while (dr.Read())
 {
 l.Add(new CascadingDropDownNameValue(
 dr["FirstName"].ToString() + " " + dr["LastName"].ToString(),
 dr["ContactID"].ToString()));
 }
 conn.Close();
 return l.ToArray();
}