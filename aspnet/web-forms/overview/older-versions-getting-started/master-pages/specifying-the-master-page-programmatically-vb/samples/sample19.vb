Protected Overrides Sub OnPreInit(ByVal e As System.EventArgs)
 SetMasterPageFile() 
 MyBase.OnPreInit(e)
End Sub 
Protected Overridable Sub SetMasterPageFile() 
 Me.MasterPageFile = GetMasterPageFileFromSession() 
End Sub 
Protected Function GetMasterPageFileFromSession() As String 
 If Session("MyMasterPage") Is Nothing Then
 Return "~/Site.master"
 Else 
 Return Session("MyMasterPage").ToString() 
 End If 
End Function