[Queryable]
public SingleResult<Category> GetCategory([FromODataUri] int key)
{
    return SingleResult.Create(db.Categories.Where(c => c.ID == key));
}