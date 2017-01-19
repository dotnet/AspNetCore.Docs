<%@ WebService Language="VB" Class="DynamicPopulate" %>
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
<ScriptService()> _
Public Class DynamicPopulate
 Inherits System.Web.Services.WebService
 <WebMethod()> _
 Public Function getDate(ByVal contextKey As String) As String
 Dim myDate As String = ""
 Select Case contextKey
 Case "format1"
 myDate = String.Format("{0:MM}-{0:dd}-{0:yyyy}", DateTime.Now)
 Case "format2"
 myDate = String.Format("{0:dd}.{0:MM}.{0:yyyy}", DateTime.Now)
 Case "format3"
 myDate = String.Format("{0:yyyy}/{0:MM}/{0:dd}", DateTime.Now)
 End Select
 Return myDate
 End Function
End Class