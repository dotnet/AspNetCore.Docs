<script runat="server">
 Protected Sub c1_SelectionChanged(sender As object, e As EventArgs)
 Dim id As String = tbHidden.Value
 If (id = "tbDeparture" Or id = "tbReturn")
 Dim tb As TextBox = CType(FindControl(id), TextBox)
 tb.Text = CType(sender, Calendar).SelectedDate.ToShortDateString()
 End If
 End Sub
</script>