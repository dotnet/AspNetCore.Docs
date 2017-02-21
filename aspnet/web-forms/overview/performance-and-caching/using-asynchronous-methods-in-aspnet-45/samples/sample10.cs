protected void Page_Load(object sender, EventArgs e)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    RegisterAsyncTask(new PageAsyncTask(GetPWGsrvAsync));
    stopWatch.Stop();
    ElapsedTimeLabel.Text = String.Format("Elapsed time: {0}",
        stopWatch.Elapsed.Milliseconds / 1000.0);
}

private async Task GetPWGsrvAsync()
{
    var widgetService = new WidgetService();
    var prodService = new ProductService();
    var gizmoService = new GizmoService();

    var widgetTask = widgetService.GetWidgetsAsync();
    var prodTask = prodService.GetProductsAsync();
    var gizmoTask = gizmoService.GetGizmosAsync();

    await Task.WhenAll(widgetTask, prodTask, gizmoTask);

    var pwgVM = new ProdGizWidgetVM(
       widgetTask.Result,
       prodTask.Result,
       gizmoTask.Result
       );

    WidgetGridView.DataSource = pwgVM.widgetList;
    WidgetGridView.DataBind();
    ProductGridView.DataSource = pwgVM.prodList;
    ProductGridView.DataBind();
    GizmoGridView.DataSource = pwgVM.gizmoList;
    GizmoGridView.DataBind();           
}