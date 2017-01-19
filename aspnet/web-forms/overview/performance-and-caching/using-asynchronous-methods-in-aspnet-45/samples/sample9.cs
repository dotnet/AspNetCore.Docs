protected void Page_Load(object sender, EventArgs e)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();

    var widgetService = new WidgetService();
    var prodService = new ProductService();
    var gizmoService = new GizmoService();

    var pwgVM = new ProdGizWidgetVM(
        widgetService.GetWidgets(),
        prodService.GetProducts(),
        gizmoService.GetGizmos()
       );
    WidgetGridView.DataSource = pwgVM.widgetList;
    WidgetGridView.DataBind();
    ProductGridView.DataSource = pwgVM.prodList;
    ProductGridView.DataBind();
    GizmoGridView.DataSource = pwgVM.gizmoList;
    GizmoGridView.DataBind();

    stopWatch.Stop();
    ElapsedTimeLabel.Text = String.Format("Elapsed time: {0}", 
        stopWatch.Elapsed.Milliseconds / 1000.0);
}