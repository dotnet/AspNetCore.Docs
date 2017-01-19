'
' POST: /Product/Create

<AcceptVerbs(HttpVerbs.Post)> _
Public Function Create(<Bind(Exclude:="Id")> ByVal productToCreate As Product) As ActionResult
    ' Validation logic
    If productToCreate.Name.Trim().Length = 0 Then
    ModelState.AddModelError("Name", "Name is required.")
    End If
    If productToCreate.Description.Trim().Length = 0 Then
    ModelState.AddModelError("Description", "Description is required.")
    End If
    If productToCreate.UnitsInStock