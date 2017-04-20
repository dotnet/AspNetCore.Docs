Public Function Index(ByVal id As Integer?) As ActionResult
    ' Get selected group
    Dim selectedGroup = _service.GetGroup(id)
    if IsNothing(selectedGroup) Then
        Return RedirectToAction("Index", "Group")
    End If

    ' Normal Request
    if Not Request.IsAjaxRequest() Then
        Dim model As new IndexModel With { _
            .Groups = _service.ListGroups(), _
            .SelectedGroup = selectedGroup _
        }
        Return View("Index", model)
    End If

    ' Ajax Request
    return PartialView("ContactList", selectedGroup)
End Function