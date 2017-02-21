var queryAttribute = new QueryableAttribute()
{
    AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Skip,
    MaxTop = 100
};
                
config.EnableQuerySupport(queryAttribute);