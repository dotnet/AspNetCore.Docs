using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolSample
{
    #region snippet
    public class BirthdayMiddleware
    {
        private readonly RequestDelegate _next;

        public BirthdayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, 
                                      ObjectPool<StringBuilder> builderPool)
        {
            if (context.Request.Query.TryGetValue("firstName", out var firstName) &&
                context.Request.Query.TryGetValue("lastName", out var lastName) && 
                context.Request.Query.TryGetValue("month", out var month) &&                 
                context.Request.Query.TryGetValue("day", out var day) &&
                int.TryParse(month, out var monthOfYear) &&
                int.TryParse(day, out var dayOfMonth))
            {                
                var now = DateTime.UtcNow; // Ignoring timezones.

                // Request a StringBuilder from the pool.
                var stringBuilder = builderPool.Get();

                try
                {
                    stringBuilder.Append("Hi ")
                        .Append(firstName).Append(" ").Append(lastName).Append(". ");

                    if (now.Day == dayOfMonth && now.Month == monthOfYear)
                    {
                        stringBuilder.Append("Happy birthday!!!");

                        await context.Response.WriteAsync(stringBuilder.ToString());
                    }
                    else
                    {
                        var thisYearsBirthday = new DateTime(now.Year, monthOfYear, 
                                                                        dayOfMonth);

                        int daysUntilBirthday = thisYearsBirthday > now 
                            ? (thisYearsBirthday - now).Days 
                            : (thisYearsBirthday.AddYears(1) - now).Days;

                        stringBuilder.Append("There are ")
                            .Append(daysUntilBirthday).Append(" days until your birthday!");

                        await context.Response.WriteAsync(stringBuilder.ToString());
                    }
                }
                finally // Ensure this runs even if the main code throws.
                {
                    // Return the StringBuilder to the pool.
                    builderPool.Return(stringBuilder); 
                }

                return;
            }

            await _next(context);
        }
    }
    #endregion
}
