using System.Web.Security;

protected void Page_Load(object sender, EventArgs e)
{
  // If the user is not submitting their credentials
  // save refferer
  if (!Page.IsPostBack)
     {
     if (Page.Request.UrlReferrer != null)
        {
        Session["LoginReferrer"] = Page.Request.UrlReferrer.ToString();
        }
      }
           
  // User is logged in so log them out.
  if (User.Identity.IsAuthenticated)
     {
     FormsAuthentication.SignOut();
     Response.Redirect("~/");
     }
}