public class ExceptionLogger : IExceptionLogger
{
    public virtual Task LogAsync(ExceptionLoggerContext context, 
                                 CancellationToken cancellationToken)
    {
        if (!ShouldLog(context))
        {
            return Task.FromResult(0);
        }

        return LogAsyncCore(context, cancellationToken);
    }

    public virtual Task LogAsyncCore(ExceptionLoggerContext context, 
                                     CancellationToken cancellationToken)
    {
        LogCore(context);
        return Task.FromResult(0);
    }

    public virtual void LogCore(ExceptionLoggerContext context)
    {
    }

    public virtual bool ShouldLog(ExceptionLoggerContext context)
    {
        IDictionary exceptionData = context.ExceptionContext.Exception.Data;

        if (!exceptionData.Contains("MS_LoggedBy"))
        {
            exceptionData.Add("MS_LoggedBy", new List<object>());
        }

        ICollection<object> loggedBy = ((ICollection<object>)exceptionData[LoggedByKey]);

        if (!loggedBy.Contains(this))
        {
            loggedBy.Add(this);
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class ExceptionHandler : IExceptionHandler
{
    public virtual Task HandleAsync(ExceptionHandlerContext context, 
                                    CancellationToken cancellationToken)
    {
        if (!ShouldHandle(context))
        {
            return Task.FromResult(0);
        }

        return HandleAsyncCore(context, cancellationToken);
    }

    public virtual Task HandleAsyncCore(ExceptionHandlerContext context, 
                                       CancellationToken cancellationToken)
    {
        HandleCore(context);
        return Task.FromResult(0);
    }

    public virtual void HandleCore(ExceptionHandlerContext context)
    {
    }

    public virtual bool ShouldHandle(ExceptionHandlerContext context)
    {
        return context.ExceptionContext.IsOutermostCatchBlock;
    }
}