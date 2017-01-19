Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports AjaxControlToolkit

<Assembly: System.Web.UI.WebResource("CustomExtenders.DisabledButtonBehavior.js", "text/javascript")> 

<Designer(GetType(DisabledButtonExtender))> _
<ClientScriptResource("CustomExtenders.DisabledButtonBehavior", "CustomExtenders.DisabledButtonBehavior.js")> _
<TargetControlType(GetType(TextBox))> _
Public Class DisabledButtonExtender
    Inherits ExtenderControlBase

    <ExtenderControlProperty()> _
    <DefaultValue("")> _
    <IDReferenceProperty(GetType(Button))> _
    Public Property TargetButtonID() As String
        Get
            Return GetPropertyValue("TargetButtonID", "")
        End Get
        Set(ByVal value As String)
            SetPropertyValue("TargetButtonID", value)
        End Set
    End Property

    <ExtenderControlProperty(), DefaultValue("")> _
    Public Property DisabledText() As String
        Get
            Return GetPropertyValue("DisabledText", "")
        End Get
        Set(ByVal value As String)
            SetPropertyValue("DisabledText", value)
        End Set
    End Property

End Class