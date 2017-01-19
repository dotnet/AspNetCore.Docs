public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
{
    return dbSet.SqlQuery(query, parameters).ToList();
}