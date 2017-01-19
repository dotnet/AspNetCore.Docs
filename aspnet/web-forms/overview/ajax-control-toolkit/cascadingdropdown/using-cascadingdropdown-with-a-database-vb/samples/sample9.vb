If Not kv.ContainsKey("Vendor") Or Not Int32.TryParse(kv("Vendor"),VendorID) Then
 Throw New ArgumentException("Couldn't find vendor.")
 End If