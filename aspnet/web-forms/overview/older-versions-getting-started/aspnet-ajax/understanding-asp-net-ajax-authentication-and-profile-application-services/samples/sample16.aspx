<%@ WebService Language="C#" Class="AuthService" %>
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
[ScriptService]
[WebService]
public class AuthService : WebService
{
 [WebMethod]
 public bool Login(string userName, string password, bool createCookie)
 {
 Session["LoggedInUser"] = userName;
 return true;
 }
 [WebMethod]
 public void Logout()
 {
 Session.Abandon();
 }
}