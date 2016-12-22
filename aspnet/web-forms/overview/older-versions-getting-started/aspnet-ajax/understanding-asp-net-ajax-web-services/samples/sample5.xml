[System.Web.Script.Services.ScriptService]
[WebService(Namespace = "http://xmlforasp.net")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CustomersService : System.Web.Services.WebService
{
     [WebMethod]
     public Customer[] GetCustomersByCountry(string country)
     {
          return Biz.BAL.GetCustomersByCountry(country);
     }
}