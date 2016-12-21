protected void Page_Load(object sender, EventArgs e)
{
    RegisterAsyncTask(new PageAsyncTask(GetGizmosSvcAsync));
}

private async Task GetGizmosSvcAsync()
{
    var gizmoService = new GizmoService();
    GizmosGridView.DataSource = await gizmoService.GetGizmosAsync();
    GizmosGridView.DataBind();
}