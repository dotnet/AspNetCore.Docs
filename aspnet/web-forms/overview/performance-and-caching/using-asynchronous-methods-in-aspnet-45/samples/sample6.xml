protected void Page_Load(object sender, EventArgs e)
{
    RegisterAsyncTask(new PageAsyncTask(GetGizmosSvcCancelAsync));
}

private async Task GetGizmosSvcCancelAsync(CancellationToken cancellationToken)
{
    var gizmoService = new GizmoService();
    var gizmoList = await gizmoService.GetGizmosAsync(cancellationToken);
    GizmosGridView.DataSource = gizmoList;
    GizmosGridView.DataBind();
}
private void Page_Error(object sender, EventArgs e)
{
    Exception exc = Server.GetLastError();

    if (exc is TimeoutException)
    {
        // Pass the error on to the Timeout Error page
        Server.Transfer("TimeoutErrorPage.aspx", true);
    }
}