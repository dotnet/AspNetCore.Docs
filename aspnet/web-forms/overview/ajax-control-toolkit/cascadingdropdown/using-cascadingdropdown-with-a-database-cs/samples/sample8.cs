[WebMethod]
public CascadingDropDownNameValue[] GetContactsForVendor(string knownCategoryValues, 
	string category)
{
	int VendorID;
	CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);