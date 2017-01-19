// Restrict by user:
[Authorize(Users="Alice,Bob")]
public class ValuesController : ApiController
{
}
   
// Restrict by role:
[Authorize(Roles="Administrators")]
public class ValuesController : ApiController
{
}