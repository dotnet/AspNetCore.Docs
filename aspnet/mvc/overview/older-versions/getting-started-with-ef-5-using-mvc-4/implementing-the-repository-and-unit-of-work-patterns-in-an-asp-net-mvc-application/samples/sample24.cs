public virtual void Delete(object id)
{
    TEntity entityToDelete = dbSet.Find(id);
    dbSet.Remove(entityToDelete);
}

public virtual void Delete(TEntity entityToDelete)
{
	if (context.Entry(entityToDelete).State == EntityState.Detached)
	{
		dbSet.Attach(entityToDelete);
	}
	dbSet.Remove(entityToDelete);
}