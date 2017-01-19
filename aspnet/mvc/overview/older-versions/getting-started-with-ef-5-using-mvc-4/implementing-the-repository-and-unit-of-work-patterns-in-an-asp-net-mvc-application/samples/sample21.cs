IQueryable<TEntity> query = dbSet;

if (filter != null)
{
    query = query.Where(filter);
}