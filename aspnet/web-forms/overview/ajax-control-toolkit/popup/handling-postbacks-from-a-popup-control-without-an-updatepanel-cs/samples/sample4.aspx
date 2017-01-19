<script runat="server">
 protected void c1_SelectionChanged(object sender, EventArgs e)
 {
 string id = tbHidden.Value;
 if (id == "tbDeparture" || id == "tbReturn")
 {
 TextBox tb = (TextBox)FindControl(id);
 tb.Text = (sender as Calendar).SelectedDate.ToShortDateString();
 }
 }
</script>