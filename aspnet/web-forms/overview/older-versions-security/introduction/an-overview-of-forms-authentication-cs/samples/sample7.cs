protected void Page_Load(object sender, EventArgs e)
{
    if (Request.IsAuthenticated)
    {
        WelcomeBackMessage.Text = "Welcome back!";
    
        AuthenticatedMessagePanel.Visible = true;
        AnonymousMessagePanel.Visible = false;
    }
    else
    {
        AuthenticatedMessagePanel.Visible = false;
        AnonymousMessagePanel.Visible = true;
    }
}