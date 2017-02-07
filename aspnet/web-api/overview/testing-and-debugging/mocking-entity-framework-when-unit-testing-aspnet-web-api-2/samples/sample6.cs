// PUT api/Product/5
public IHttpActionResult PutProduct(int id, Product product)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (id != product.Id)
    {
        return BadRequest();
    }

    //db.Entry(product).State = EntityState.Modified;
    db.MarkAsModified(product);
    
    // rest of method not shown
}