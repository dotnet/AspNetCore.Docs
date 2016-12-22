using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;

public class CustomIdentity : System.Security.Principal.IIdentity

{

  private FormsAuthenticationTicket _ticket;

  public CustomIdentity(FormsAuthenticationTicket ticket)

  {

  _ticket = ticket;

  }

  public string AuthenticationType

  {

  get { return "Custom"; }

  }

  public bool IsAuthenticated

  {

  get { return true; }

  }

  public string Name

  {

  get { return _ticket.Name; }

  }

  public FormsAuthenticationTicket Ticket

  {

  get { return _ticket; }

  }

  public string CompanyName

  {

  get 

  {

  string[] userDataPieces = _ticket.UserData.Split("|".ToCharArray());

  return userDataPieces[0];

  }

  }

  public string Title

  {

  get 

  {

  string[] userDataPieces = _ticket.UserData.Split("|".ToCharArray());

  return userDataPieces[1];

  }

  }

}