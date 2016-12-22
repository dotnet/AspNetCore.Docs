Const BrochureDirectory As String = "~/Brochures/"
Dim brochurePath As String = BrochureDirectory & BrochureUpload.FileName
Dim fileNameWithoutExtension As String = _
    System.IO.Path.GetFileNameWithoutExtension(BrochureUpload.FileName)
Dim iteration As Integer = 1
While System.IO.File.Exists(Server.MapPath(brochurePath))
    brochurePath = String.Concat(BrochureDirectory, _
        fileNameWithoutExtension, "-", iteration, ".pdf")
    iteration += 1
End While