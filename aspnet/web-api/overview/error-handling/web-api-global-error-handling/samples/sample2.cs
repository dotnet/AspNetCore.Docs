public interface IExceptionLogger
{
   Task LogAsync(ExceptionLoggerContext context, 
                 CancellationToken cancellationToken);
}

public interface IExceptionHandler
{
   Task HandleAsync(ExceptionHandlerContext context, 
                    CancellationToken cancellationToken);
}