public class ErrorHandlingPipelineModule : HubPipelineModule
{
    protected override void OnIncomingError(Exception ex, IHubIncomingInvokerContext context)
    {
        Debug.WriteLine("=> Exception " + ex.Message);
        if (ex.InnerException != null)
        {
            Debug.WriteLine("=> Inner Exception " + ex.InnerException.Message);
        }
        base.OnIncomingError(ex, context);
    }
}