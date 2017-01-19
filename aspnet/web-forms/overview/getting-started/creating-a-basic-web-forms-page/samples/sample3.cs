protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
{    
    Label1.Text = Calendar1.SelectedDate.ToLongDateString();
}