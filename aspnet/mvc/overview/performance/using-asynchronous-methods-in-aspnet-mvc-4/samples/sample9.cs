[AsyncTimeout(150)]
[HandleError(ExceptionType = typeof(TimeoutException),
                                    View = "TimeoutError")]
public async Task<ActionResult> GizmosCancelAsync(
                       CancellationToken cancellationToken )
{
    ViewBag.SyncOrAsync = "Asynchronous";
    var gizmoService = new GizmoService();
    return View("Gizmos",
        await gizmoService.GetGizmosAsync(cancellationToken));
}