[WebMethod]
public Customer[] GetCustomersByCountry(string country)
{
     return Biz.BAL.GetCustomersByCountry(country);
}