public HttpResponseMessage Get()
{
    string sessionId = Request.Properties[SessionIdHandler.SessionIdToken] as string;

    return new HttpResponseMessage()
    {
        Content = new StringContent("Your session ID = " + sessionId)
    };
}