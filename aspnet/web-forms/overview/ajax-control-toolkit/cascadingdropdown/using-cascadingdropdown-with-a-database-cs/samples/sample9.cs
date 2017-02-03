if (!kv.ContainsKey("Vendor") || !Int32.TryParse(kv["Vendor"],out VendorID)) 
{
	throw new ArgumentException("Couldn't find vendor.");
};