Public Class GroupController
Inherits Controller

Private _groups As IList(Of Group) = New List(Of Group)()

Public Function Index() As ActionResult
	Return View(_groups)
End Function

Public Function Create(ByVal groupToCreate As Group) As ActionResult
	_groups.Add(groupToCreate)
	Return RedirectToAction("Index")

End Function
End Class