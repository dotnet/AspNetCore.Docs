Protected Sub Page_Load(ByVal sender As Object, ByVal e As  System.EventArgs) Handles Me.Load

    Dim filePath As  String = Server.MapPath("~/LastTYASP35Access.txt")

    Dim contents As  String = String.Format("Last accessed on {0} by {1}", _

                                 DateTime.Now.ToString(), Request.UserHostAddress)

     System.IO.File.WriteAllText(filePath, contents)

End Sub