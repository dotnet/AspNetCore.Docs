protected void Page_Load(object sender, EventArgs e)
{
    TimeLabel.Text =  "The time at the beep is: " + DateTime.Now.ToString();
}