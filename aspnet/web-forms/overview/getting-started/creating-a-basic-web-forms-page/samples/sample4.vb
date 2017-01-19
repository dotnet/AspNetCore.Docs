Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Label1.Text = Calendar1.SelectedDate.ToLongDateString()
End Sub