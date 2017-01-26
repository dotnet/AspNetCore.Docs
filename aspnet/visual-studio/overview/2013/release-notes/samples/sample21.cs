// Sample ODataQueryOptions<T> usage from earlier
public IQueryable<Customer> Get(ODataQueryOptions<Customer> query)
{
	IQueryable<customer> result="query.ApplyTo(_customers)" as iqueryable<customer>; return result;
}