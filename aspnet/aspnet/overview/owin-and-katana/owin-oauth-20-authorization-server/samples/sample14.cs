namespace ResourceServer.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
    }
}