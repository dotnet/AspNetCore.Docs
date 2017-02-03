<%@ WebService Language="VB" Class="CascadingDropDown0" %>
Imports System.Web.Script.Services
Imports AjaxControlToolkit
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
<ScriptService()> _
Public Class CascadingDropDown0
 Inherits System.Web.Services.WebService
 <WebMethod()> _
 Public Function GetVendors(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
 Dim l As New List(Of CascadingDropDownNameValue)
 l.Add(New CascadingDropDownNameValue("International", "1"))
 l.Add(New CascadingDropDownNameValue("Electronic Bike Repairs & Supplies","2"))
 l.Add(New CascadingDropDownNameValue("Premier Sport, Inc.", "3"))
 Return l.ToArray()
 End Function
End Class