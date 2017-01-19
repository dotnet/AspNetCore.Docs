public class ValuesController : ApiController
{
    public IHttpActionResult Get()
    {
        return Ok(42);
    }
}