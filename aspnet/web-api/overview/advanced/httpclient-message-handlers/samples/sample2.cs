class MessageHandler1 : DelegatingHandler
{
    private int _count = 0;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        System.Threading.Interlocked.Increment(ref _count);
        request.Headers.Add("X-Custom-Header", _count.ToString());
        return base.SendAsync(request, cancellationToken);
    }
}
