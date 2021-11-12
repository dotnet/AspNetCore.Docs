using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    // <snippet>
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add( _name, new string[] { _value });
            base.OnResultExecuting(context);
        }
    }
    // </snippet>
}
