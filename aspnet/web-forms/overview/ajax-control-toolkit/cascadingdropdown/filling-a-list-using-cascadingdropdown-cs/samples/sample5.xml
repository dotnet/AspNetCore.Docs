<%@ WebService Language="C#" Class="CascadingDropdown0" %>
using System.Web.Script.Services;
using AjaxControlToolkit;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
[ScriptService]
public class CascadingDropdown0 : System.Web.Services.WebService
{
 [WebMethod]
 public CascadingDropDownNameValue[] GetVendors(string knownCategoryValues, 
 string category)
 {
 List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
 l.Add(new CascadingDropDownNameValue("International", "1"));
 l.Add(new CascadingDropDownNameValue("Electronic Bike Repairs & Supplies", "2"));
 l.Add(new CascadingDropDownNameValue("Premier Sport, Inc.", "3"));
 return l.ToArray();
 }
}