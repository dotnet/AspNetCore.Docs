<WebMethod()> _
Public Function GetVendors(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
 Dim conn As New SqlConnection("server=(local)\SQLEXPRESS; Integrated Security=true; Initial Catalog=AdventureWorks")
 conn.Open()
 Dim comm As New SqlCommand( _
 "SELECT TOP 25 VendorID, Name FROM Purchasing.Vendor", conn)
 Dim dr As SqlDataReader = comm.ExecuteReader()
 Dim l As New List(Of CascadingDropDownNameValue)
 While (dr.Read())
 l.Add(New CascadingDropDownNameValue(dr("Name").ToString(),dr("VendorID").ToString()))
 End While
 conn.Close()
 Return l.ToArray()
End Function