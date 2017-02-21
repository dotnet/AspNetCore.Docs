Imports Microsoft.VisualBasic

Public Class CustomPrincipal

 Implements System.Security.Principal.IPrincipal

 Private _identity As CustomIdentity

 Public Sub New(ByVal identity As CustomIdentity)

 _identity = identity

 End Sub

 Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity

 Get

 Return _identity

 End Get

 End Property

 Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole

 Return False

 End Function

End Class