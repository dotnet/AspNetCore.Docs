[HttpPost]
public void RateAllProducts(ODataActionParameters parameters)
{
    if (!ModelState.IsValid)
    {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
    }

    var ratings = parameters["Ratings"] as ICollection<int>; 

    // ...
}