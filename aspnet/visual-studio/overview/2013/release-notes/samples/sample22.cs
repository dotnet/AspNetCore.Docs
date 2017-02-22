public IHttpActionResult Get(ODataQueryOptions<Customer> query)
{
	IQueryable result = query.ApplyTo(_customers);
	return Ok(result, result.GetType());
}
 
private IHttpActionResult Ok(object content, Type type)
{
	Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
	return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
}