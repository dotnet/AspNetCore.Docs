[WebMethod]
public static Customer[] GetCustomersByCountry(string country)
{
     return Biz.BAL.GetCustomersByCountry(country);
}
[WebMethod]
public static Customer[] GetCustomersByID(string id)
{
     return Biz.BAL.GetCustomersByID(id);
}