function GetCustomerByCountry()
{
     var country = $get("txtCountry").value;
     InterfaceTraining.CustomersService.GetCustomersByCountry(country, OnWSRequestComplete);
}
function OnWSRequestComplete(results)
{
     if (results != null)
     {
          CreateCustomersTable(results);
          GetMap(results);
     }
}