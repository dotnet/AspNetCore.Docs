[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
public class TestController : ApiController
{
    public HttpResponseMessage Get()
    {
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent("GET: Test message")
        };
        resp.Headers.Add("X-Custom-Header", "hello");
        return resp;
    }
}