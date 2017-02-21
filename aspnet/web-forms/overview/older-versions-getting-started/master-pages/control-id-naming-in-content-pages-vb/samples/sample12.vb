Imports System.Runtime.CompilerServices

Public Module PageExtensionMethods
 <Extension()> _
  Public Function FindControlRecursive(ByVal ctrl As Control, ByVal controlID As String) As Control
 If String.Compare(ctrl.ID, controlID, True) = 0 Then
 ' We found the control!
 Return ctrl
 Else
 ' Recurse through ctrl's Controls collections
 For Each child As Control In ctrl.Controls
 Dim lookFor As Control = FindControlRecursive(child, controlID)

 If lookFor IsNot Nothing Then
 Return lookFor  ' We found the control
 End If
 Next

 ' If we reach here, control was not found
 Return Nothing
 End If
 End Function
End Module