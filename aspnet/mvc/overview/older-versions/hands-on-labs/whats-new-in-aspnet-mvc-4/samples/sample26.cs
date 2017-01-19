[AsyncTimeout(500)]
[HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
public async Task<ActionResult> Index(CancellationToken cancellationToken)
{