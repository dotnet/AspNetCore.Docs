using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PageFilter.Filters
{
    public class AddHeaderAttribute  : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute (string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(
                            _name, new string[] { _value });
            await next.Invoke();
        }
    }
}
