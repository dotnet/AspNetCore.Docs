public ActionResult PWG()
{
    ViewBag.SyncType = "Synchronous";
    var widgetService = new WidgetService();
    var prodService = new ProductService();
    var gizmoService = new GizmoService();

    var pwgVM = new ProdGizWidgetVM(
        widgetService.GetWidgets(),
        prodService.GetProducts(),
        gizmoService.GetGizmos()
       );

    return View("PWG", pwgVM);
}