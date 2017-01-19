[EnableCors(origins: "http://www.example.com", headers: "*", methods: "get,post")]
public class TestController : ApiController
{
    public HttpResponseMessage Get() { ... }
    public HttpResponseMessage Post() { ... }
    public HttpResponseMessage Put() { ... }    
}