public class CustomerDetails : Customer
{
     public CustomerDetails()
     {
     }
     Address _Address;
     Gender _Gender = Gender.Unknown;
     public Address Address
     {
          get { return _Address; }
          set { _Address = value; }
     }
     public Gender Gender
     {
          get { return _Gender; }
          set { _Gender = value; }
     }
}