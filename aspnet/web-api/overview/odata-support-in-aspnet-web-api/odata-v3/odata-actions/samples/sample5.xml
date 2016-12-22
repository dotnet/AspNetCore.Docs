[HttpPost]
public async Task<IHttpActionResult> RateProduct([FromODataUri] int key, ODataActionParameters parameters)
{
    if (!ModelState.IsValid)
    {
        return BadRequest();
    }

    int rating = (int)parameters["Rating"];

    Product product = await db.Products.FindAsync(key);
    if (product == null)
    {
        return NotFound();
    }

    product.Ratings.Add(new ProductRating() { Rating = rating });
    db.SaveChanges();

    double average = product.Ratings.Average(x => x.Rating);

    return Ok(average);
}