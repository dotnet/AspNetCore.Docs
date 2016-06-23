using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Helper
{
    public static class Helpers
    {
        public static ContentResult GetContentResult(object result, string message)
        {
            var actualResult = result as ContentResult;
            var content = message;

            if (actualResult != null)
            {
                content += ", " + actualResult.Content;
            }

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html"
            };
        }
    }
}