Public Class AdminBasePage 
 Inherits BasePage 
 Protected Overrides Sub SetMasterPageFile() 
 Me.MasterPageFile = "~/Admin/AdminNested.master" 
 Page.Master.MasterPageFile = MyBase.GetMasterPageFileFromSession() 
 End Sub 
End Class