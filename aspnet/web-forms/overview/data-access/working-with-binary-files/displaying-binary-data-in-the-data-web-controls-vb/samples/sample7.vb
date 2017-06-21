If category.IsPictureNull() Then
    ' Display some "No Image Available" picture
    Response.Redirect("~/Images/NoPictureAvailable.gif")
Else
    ' Send back the binary contents of the Picture column
    ' ... Set ContentType property and write out ...
    ' ... data via Response.BinaryWrite ...
End If