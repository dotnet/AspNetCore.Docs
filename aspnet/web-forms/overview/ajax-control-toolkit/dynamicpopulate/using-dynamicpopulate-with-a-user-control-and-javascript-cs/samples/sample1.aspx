<%@ WebService Language="C#" Class="DynamicPopulate" %>
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
[ScriptService]
public class DynamicPopulate : System.Web.Services.WebService
{
 [WebMethod]
 public string getDate(string contextKey)
 {
 string myDate = "";
 switch (contextKey)
 {
 case "format1":
 myDate = String.Format("{0:MM}-{0:dd}-{0:yyyy}", DateTime.Now);
 break;
 case "format2":
 myDate = String.Format("{0:dd}.{0:MM}.{0:yyyy}", DateTime.Now);
 break;
 case "format3":
 myDate = String.Format("{0:yyyy}/{0:MM}/{0:dd}", DateTime.Now);
 break;
 }
 return myDate;
 }
}