[Queryable(MaxExpansionDepth=4)]
public IQueryable<Category> GetCategories()
{
    return db.Categories;
}