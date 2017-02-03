Protected Sub SaveData(ByVal sender As Object, ByVal e As EventArgs)
 lblName.Text = HttpUtility.HtmlEncode(tbName.Text)
 lblEmail.Text = HttpUtility.HtmlEncode(tbEmail.Text)
End Sub