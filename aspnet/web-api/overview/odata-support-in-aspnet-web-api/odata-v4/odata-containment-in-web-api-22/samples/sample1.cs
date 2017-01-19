public class Account     
{         
    public int AccountID { get; set; }         
    public string Name { get; set; }         
    [Contained]         
    public IList<PaymentInstrument> PayinPIs { get; set; }     
}     

public class PaymentInstrument     
{         
    public int PaymentInstrumentID { get; set; }        
    public string FriendlyName { get; set; }     
}