[ODataRoute("Umbrella/Revenue")] 
public IHttpActionResult GetCompanyRevenue() 
{
     return Ok(Umbrella.Revenue); 
}