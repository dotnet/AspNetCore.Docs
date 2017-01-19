Imports AjaxControlToolkit
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

<Assembly: System.Web.UI.WebResource("CustomExtenders.MyControlBehavior.js", "text/javascript")> 

<ClientScriptResource("CustomExtenders.MyControlBehavior", "CustomExtenders.MyControlBehavior.js")> _
<TargetControlType(GetType(TextBox))> _
Public Class MyControlExtender
    Inherits ExtenderControlBase

    <ExtenderControlProperty()> _
    <DefaultValue("")> _
    Public Property MyProperty() As String
        Get
            Return GetPropertyValue("MyProperty", "")
        End Get
        Set(ByVal value As String)
            SetPropertyValue("MyProperty", value)
        End Set
    End Property
End Class