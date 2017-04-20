[HttpGet]
[ODataRoute("GetSalesTaxRate(PostalCode={postalCode})")]
public IHttpActionResult GetSalesTaxRate([FromODataUri] int postalCode)
{
    double rate = 5.6;  // Use a fake number for the sample.
    return Ok(rate);
}