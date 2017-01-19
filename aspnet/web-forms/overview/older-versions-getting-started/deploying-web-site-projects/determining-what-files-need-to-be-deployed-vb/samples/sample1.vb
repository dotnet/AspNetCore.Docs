Protected Sub Page_Load(ByVal sender As Object, ByVal e As  System.EventArgs) Handles Me.Load
    TimeLabel.Text =  "The time at the beep is: " & DateTime.Now.ToString()
End Sub