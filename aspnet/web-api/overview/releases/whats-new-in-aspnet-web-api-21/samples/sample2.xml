public class TraceSourceExceptionLogger : ExceptionLogger
{
    private readonly TraceSource _traceSource;

    public TraceSourceExceptionLogger(TraceSource traceSource)
    {
        _traceSource = traceSource;
    }

    public override void Log(ExceptionLoggerContext context)
    {
        _traceSource.TraceEvent(TraceEventType.Error, 1,
            "Unhandled exception processing {0} for {1}: {2}",
            context.Request.Method,
            context.Request.RequestUri,
            context.Exception);
    }
}

config.Services.Add(typeof(IExceptionLogger), 
    new TraceSourceExceptionLogger(new 
    TraceSource("MyTraceSource", SourceLevels.All)));