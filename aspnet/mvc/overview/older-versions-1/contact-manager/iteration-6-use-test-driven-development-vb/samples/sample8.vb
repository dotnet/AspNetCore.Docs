Public Function Create(ByVal groupToCreate As Group) As ActionResult
    ' Validation logic
    If groupToCreate.Name.Trim().Length = 0 Then
    ModelState.AddModelError("Name", "Name is required.")
    Return View("Create")
    End If

    ' Database logic
    _groups.Add(groupToCreate)
    Return RedirectToAction("Index")
End Function