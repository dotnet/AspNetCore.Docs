function GetCustomersByCountry() 
{
     var country = $get("txtCountry").value;
     InterfaceTraining.CustomersService.GetCustomersByCountry(country, 
          OnWSRequestComplete, OnWSRequestFailed);
}
function OnWSRequestFailed(error)
{
     alert("Stack Trace: " + error.get_stackTrace() + "/r/n" +
          "Error: " + error.get_message() + "/r/n" +
          "Status Code: " + error.get_statusCode() + "/r/n" +
          "Exception Type: " + error.get_exceptionType() + "/r/n" +
          "Timed Out: " + error.get_timedOut());
}