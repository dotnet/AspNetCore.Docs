class TraceExceptionLogger : ExceptionLogger
{
	public override void LogCore(ExceptionLoggerContext context)
	{
		Trace.TraceError(context.ExceptionContext.Exception.ToString());
	}
}