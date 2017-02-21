function GetCustomerByCountry() 
{
     var country = $get("txtCountry").value;
     PageMethods.GetCustomersByCountry(country, OnWSRequestComplete);
}
function GetCustomerByID() 
{
     var custID = $get("txtCustomerID").value;
     PageMethods.GetCustomersByID(custID, OnWSRequestComplete);
}
function OnWSRequestComplete(results) 
{
     var searchResults = $get("searchResults");
     searchResults.control.set_data(results);
     if (results != null) GetMap(results[0].Country,results);
}