[WebMethod]
public string[] GetCustomerIDs(string prefixText, int count) 
{
     return Biz.BAL.GetCustomerIDs(prefixText, count);
}