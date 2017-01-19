public async Task<ActionResult> GizmosAsync()
{
    ViewBag.SyncOrAsync = "Asynchronous";
    var gizmoService = new GizmoService();
    return View("Gizmos", await gizmoService.GetGizmosAsync());
}