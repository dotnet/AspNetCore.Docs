public class MyQueryableAttribute : QueryableAttribute
{
    public override void ValidateQuery(HttpRequestMessage request, 
        ODataQueryOptions queryOptions)
    {
        if (queryOptions.OrderBy != null)
        {
            queryOptions.OrderBy.Validator = new MyOrderByValidator();
        }
        base.ValidateQuery(request, queryOptions);
    }
}