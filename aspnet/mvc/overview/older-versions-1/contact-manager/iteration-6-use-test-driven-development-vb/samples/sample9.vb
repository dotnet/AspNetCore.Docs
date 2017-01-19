Public Class GroupController
Inherits Controller

Private _service As IContactManagerService

Public Sub New()
	_service = New ContactManagerService(New ModelStateWrapper(Me.ModelState))

End Sub

Public Sub New(ByVal service As IContactManagerService)
	_service = service
End Sub

Public Function Index() As ActionResult
	Return View(_service.ListGroups())
End Function


Public Function Create(ByVal groupToCreate As Group) As ActionResult
	If _service.CreateGroup(groupToCreate) Then
		Return RedirectToAction("Index")
	End If
	Return View("Create")
End Function

End Class