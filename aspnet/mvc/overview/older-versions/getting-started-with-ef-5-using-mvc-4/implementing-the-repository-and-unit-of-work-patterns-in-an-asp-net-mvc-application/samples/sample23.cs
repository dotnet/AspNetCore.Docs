if (orderBy != null)
{
    return orderBy(query).ToList();
}
else
{
    return query.ToList();
}