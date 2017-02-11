[HttpPost]
public async Task<IHttpActionResult> Rate([FromODataUri] int key, ODataActionParameters parameters)
{
    if (!ModelState.IsValid)
    {
        return BadRequest();
    }

    int rating = (int)parameters["Rating"];
    db.Ratings.Add(new ProductRating
    {
        ProductID = key,
        Rating = rating
    });

    try
    {
        await db.SaveChangesAsync();
    }
    catch (DbUpdateException e)
    {
        if (!ProductExists(key))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return StatusCode(HttpStatusCode.NoContent);
}