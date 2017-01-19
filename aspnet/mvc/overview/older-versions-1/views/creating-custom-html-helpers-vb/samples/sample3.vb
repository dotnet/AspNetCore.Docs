Public Class LabelHelper
Public Shared Function Label(ByVal target As String, ByVal text As String) As String
     Return String.Format("<label for='{0}'>{1}</label>", target, text)
End Function
End Class