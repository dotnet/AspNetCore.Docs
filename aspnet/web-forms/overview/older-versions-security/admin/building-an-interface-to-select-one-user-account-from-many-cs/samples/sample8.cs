private string UsernameToMatch
{
 get
 {
 object o = ViewState["UsernameToMatch"];
 if (o == null)
 return string.Empty;
 else
 return (string)o;
 }
 set
 {
 ViewState["UsernameToMatch"] = value;
 }
}