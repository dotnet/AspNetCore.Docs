using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersSample.Filters
{
    #region snippet
    public class UnprocessableResultFilter : Attribute, IAlwaysRunResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is StatusCodeResult statusCodeResult &&
                statusCodeResult.StatusCode == 415)
            {
                context.Result = new ObjectResult("Can't process this!")
                {
                    StatusCode = 422,
                };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
    #endregion
}
