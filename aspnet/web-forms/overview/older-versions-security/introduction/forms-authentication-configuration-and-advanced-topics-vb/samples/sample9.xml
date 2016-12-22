Imports Microsoft.VisualBasic

Public Class CustomIdentity

 Implements System.Security.Principal.IIdentity

 Private _ticket As FormsAuthenticationTicket

 Public Sub New(ByVal ticket As FormsAuthenticationTicket)

 _ticket = ticket

 End Sub

 Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType

 Get

 Return "Custom"

 End Get

 End Property

 Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated

 Get

 Return True

 End Get

 End Property

 Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name

 Get

 Return _ticket.Name

 End Get

 End Property

 Public ReadOnly Property Ticket() As FormsAuthenticationTicket

 Get

 Return _ticket

 End Get

 End Property

 Public ReadOnly Property CompanyName() As String

 Get

 Dim userDataPieces() As String = _ticket.UserData.Split("|".ToCharArray())

 Return userDataPieces(0)

 End Get

 End Property

 Public ReadOnly Property Title() As String

 Get

 Dim userDataPieces() As String = _ticket.UserData.Split("|".ToCharArray())

 Return userDataPieces(1)

 End Get

 End Property

End Class