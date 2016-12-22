<%@ WebService Language="VB" Class="NumericUpDown1" %>
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<System.Web.Script.Services.ScriptService()> _
Public Class NumericUpDown1
 Inherits System.Web.Services.WebService
 <WebMethod()> _
 Function Up(ByVal current As Integer, ByVal tag As String) As Integer
 If current <= 536870912 Then
 Return current * 2
 Else
 Return current
 End If
 End Function
 <WebMethod()> _
 Function Down(ByVal current As Integer, ByVal tag As String) As Integer
 If current >= 2 Then
 Return CInt(current / 2)
 Else
 Return current
 End If
 End Function
End Class