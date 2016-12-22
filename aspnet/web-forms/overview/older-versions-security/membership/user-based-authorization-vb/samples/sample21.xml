' Is this Tito visiting the page?
Dim userName As String = User.Identity.Name
If String.Compare(userName, "Tito", True) = 0 Then
 ' This is Tito, SHOW the Delete column
 FilesGrid.Columns(1).Visible = True
Else
 ' This is NOT Tito, HIDE the Delete column
 FilesGrid.Columns(1).Visible = False
End If