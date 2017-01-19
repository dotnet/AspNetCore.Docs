public ActionResult Gizmos()
{
    ViewBag.SyncOrAsync = "Synchronous";
    var gizmoService = new GizmoService();
    return View("Gizmos", gizmoService.GetGizmos());
}