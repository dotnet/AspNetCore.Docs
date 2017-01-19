public class ETagParameterBinding : HttpParameterBinding
{
    ETagMatch _match;

    public ETagParameterBinding(HttpParameterDescriptor parameter, ETagMatch match) 
        : base(parameter)
    {
        _match = match;
    }

    public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, 
        HttpActionContext actionContext, CancellationToken cancellationToken)
    {
        EntityTagHeaderValue etagHeader = null;
        switch (_match)
        {
            case ETagMatch.IfNoneMatch:
                etagHeader = actionContext.Request.Headers.IfNoneMatch.FirstOrDefault();
                break;

            case ETagMatch.IfMatch:
                etagHeader = actionContext.Request.Headers.IfMatch.FirstOrDefault();
                break;
        }

        ETag etag = null;
        if (etagHeader != null)
        {
            etag = new ETag { Tag = etagHeader.Tag };
        }
        actionContext.ActionArguments[Descriptor.ParameterName] = etag;

        var tsc = new TaskCompletionSource<object>();
        tsc.SetResult(null);
        return tsc.Task;
    }
}