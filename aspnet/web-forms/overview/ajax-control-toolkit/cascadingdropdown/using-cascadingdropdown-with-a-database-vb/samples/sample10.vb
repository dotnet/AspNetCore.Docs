Dim conn As New SqlConnection("server=(local)\SQLEXPRESS; Integrated Security=true; Initial Catalog=AdventureWorks")
 conn.Open()
 Dim comm As New SqlCommand("SELECT Person.Contact.ContactID, FirstName, LastName FROM Person.Contact,Purchasing.VendorContact WHERE VendorID=@VendorID AND Person.Contact.ContactID=Purchasing.VendorContact.ContactID",conn)
 comm.Parameters.AddWithValue("@VendorID", VendorID)
 Dim dr As SqlDataReader = comm.ExecuteReader()
 Dim l As New List(Of CascadingDropDownNameValue)
 While (dr.Read())
 l.Add(New CascadingDropDownNameValue(dr("FirstName").ToString() & " " & dr("LastName").ToString(),dr("ContactID").ToString()))
 End While
 conn.Close()
 Return l.ToArray()
End Function