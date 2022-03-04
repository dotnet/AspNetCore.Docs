using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text.RegularExpressions;

namespace RewriteRules;

public class MethodRules
{
    #region snippet_RedirectXmlFileRequests
    public static void RedirectXmlFileRequests(RewriteContext context)
    {
        var request = context.HttpContext.Request;

        // Because the client is redirecting back to the same app, stop 
        // processing if the request has already been redirected.
        if (request.Path.StartsWithSegments(new PathString("/xmlfiles")) ||
            request.Path.Value==null)
        {
            return;
        }

        if (request.Path.Value.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        {
            var response = context.HttpContext.Response;
            response.StatusCode = (int) HttpStatusCode.MovedPermanently;
            context.Result = RuleResult.EndResponse;
            response.Headers[HeaderNames.Location] = 
                "/xmlfiles" + request.Path + request.QueryString;
        }
    }
    #endregion

    #region snippet_RewriteTextFileRequests
    public static void RewriteTextFileRequests(RewriteContext context)
    {
        var request = context.HttpContext.Request;

        if (request.Path.Value != null &&
            request.Path.Value.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = RuleResult.SkipRemainingRules;
            request.Path = "/file.txt";
        }
    }
    #endregion
}

#region snippet_RedirectImageRequests
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
        if (request.Path.StartsWithSegments(new PathString(_newPath)) ||
            request.Path.Value == null)
        {
            return;
        }

        if (request.Path.Value.EndsWith(_extension, StringComparison.OrdinalIgnoreCase))
        {
            var response = context.HttpContext.Response;
            response.StatusCode = (int) HttpStatusCode.MovedPermanently;
            context.Result = RuleResult.EndResponse;
            response.Headers[HeaderNames.Location] = 
                _newPath + request.Path + request.QueryString;
        }
    }
}
#endregion
