function UpdateAddress()
{
     var cust = new Model.CustomerDetails();
     cust.CustomerID = $get("hidCustomerID").value;
     cust.Address = CreateAddress();
     InterfaceTraining.DemoService.UpdateAddress(cust,OnWSUpdateComplete);
}
function CreateAddress()
{
     var addr = new Model.Address();
     addr.Street = $get("txtStreet").value;
     addr.City = $get("txtCity").value;
     addr.State = $get("txtState").value;
     return addr;
}
function OnWSUpdateComplete(result)
{
     alert("Update " + ((result)?"succeeded":"failed")+ "!");
}