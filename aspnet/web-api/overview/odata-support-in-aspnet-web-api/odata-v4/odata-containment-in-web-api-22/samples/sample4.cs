public class AccountsController : ODataController     
{         
    private static IList<Account> _accounts = null;         
    public AccountsController()         
    {             
        if (_accounts == null)             
        {                 
            _accounts = InitAccounts();             
        }         
    }         
    // PUT ~/Accounts(100)/PayinPIs         
    [EnableQuery] 
    public IHttpActionResult GetPayinPIs(int key)         
    {             
        var payinPIs = _accounts.Single(a => a.AccountID == key).PayinPIs;             
        return Ok(payinPIs);         
    }         
    [EnableQuery]         
    [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
    public IHttpActionResult GetSinglePayinPI(int accountId, int paymentInstrumentId)         
    {             
        var payinPIs = _accounts.Single(a => a.AccountID == accountId).PayinPIs;             
        var payinPI = payinPIs.Single(pi => pi.PaymentInstrumentID == paymentInstrumentId);             
        return Ok(payinPI);         
    }         
    // PUT ~/Accounts(100)/PayinPIs(101)         
    [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
    public IHttpActionResult PutToPayinPI(int accountId, int paymentInstrumentId, [FromBody]PaymentInstrument paymentInstrument)         
    {             
        var account = _accounts.Single(a => a.AccountID == accountId);             
        var originalPi = account.PayinPIs.Single(p => p.PaymentInstrumentID == paymentInstrumentId);             
        originalPi.FriendlyName = paymentInstrument.FriendlyName;             
        return Ok(paymentInstrument);         
    }         
    // DELETE ~/Accounts(100)/PayinPIs(101)         
    [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
    public IHttpActionResult DeletePayinPIFromAccount(int accountId, int paymentInstrumentId)         
    {             
        var account = _accounts.Single(a => a.AccountID == accountId);             
        var originalPi = account.PayinPIs.Single(p => p.PaymentInstrumentID == paymentInstrumentId);             
        if (account.PayinPIs.Remove(originalPi))             
        {                 
            return StatusCode(HttpStatusCode.NoContent);             
        }             
        else             
        {                 
            return StatusCode(HttpStatusCode.InternalServerError);             
        }         
    }         
    // GET ~/Accounts(100)/PayinPIs/Namespace.GetCount() 
    [ODataRoute("Accounts({accountId})/PayinPIs/ODataContrainmentSample.GetCount(NameContains={name})")]         
    public IHttpActionResult GetPayinPIsCountWhoseNameContainsGivenValue(int accountId, [FromODataUri]string name)         
    {             
        var account = _accounts.Single(a => a.AccountID == accountId);             
        var count = account.PayinPIs.Where(pi => pi.FriendlyName.Contains(name)).Count();             
        return Ok(count);         
    }         
    private static IList<Account> InitAccounts()         
    {             
        var accounts = new List<Account>() 
        { 
            new Account()                 
            {                    
                AccountID = 100,                    
                Name="Name100",                    
                PayinPIs = new List<PaymentInstrument>()                     
                {                         
                    new PaymentInstrument()                         
                    {                             
                        PaymentInstrumentID = 101,                             
                        FriendlyName = "101 first PI",                         
                    },                         
                    new PaymentInstrument()                         
                    {                             
                        PaymentInstrumentID = 102,                             
                        FriendlyName = "102 second PI",                         
                    },                     
                },                 
            },             
        };            
        return accounts;         
    }     
}