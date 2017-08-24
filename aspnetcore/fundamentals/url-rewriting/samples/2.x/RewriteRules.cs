using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;

namespace RewriteRules
{
    public class MethodRules
    {
        #region snippet1
        public static void RedirectXMLRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            // Because we're redirecting back to the same app, stop 
            // processing if the request has already been redirected
            if (request.Path.StartsWithSegments(new PathString("/xmlfiles")))
            {
                return;
            }

            if (request.Path.Value.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = 
                    "/xmlfiles" + request.Path + request.QueryString;
            }
        }
        #endregion
    }

    #region snippet2
    public class RedirectImageRequests : IRule
    {
        private readonly string _extension;
        private readonly PathString _newPath;

        public RedirectImageRequests(string extension, string newPath)
        {
            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException(nameof(extension));
            }

            if (!Regex.IsMatch(extension, @"^\.(png|jpg|gif)$"))
            {
                throw new ArgumentException("Invalid extension", nameof(extension));
            }

            if (!Regex.IsMatch(newPath, @"(/[A-Za-z0-9]+)+?"))
            {
                throw new ArgumentException("Invalid path", nameof(newPath));
            }

            _extension = extension;
            _newPath = new PathString(newPath);
        }

        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            // Because we're redirecting back to the same app, stop 
            // processing if the request has already been redirected
            if (request.Path.StartsWithSegments(new PathString(_newPath)))
            {
                return;
            }

            if (request.Path.Value.EndsWith(_extension, StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = 
                    _newPath + request.Path + request.QueryString;
            }
        }
    }
    #endregion
}
