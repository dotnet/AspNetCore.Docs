// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace RewriteRules
{
    #region snippet1
    public class RedirectImageRequests : IRule
    {
        private readonly string _extension;
        private readonly string _target;

        public RedirectImageRequests(string extension, Uri target)
        {
            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException(nameof(extension));
            }

            if (!Regex.IsMatch(extension, @"^\.(png|jpg|gif)$"))
            {
                throw new ArgumentException("The extension is not valid. The extension must be .png, .jpg, or .gif.", nameof(extension));
            }

            if (!target.IsAbsoluteUri)
            {
                throw new ArgumentException("The target Url must be absolute.", nameof(target));
            }

            _extension = extension;
            _target = target.OriginalString;
        }

        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var path = request.Path.Value;

            // Because we're redirecting back to the same app, stop processing 
            // if this request has already been redirected
            if (path.StartsWith("/png-images/") || path.StartsWith("/jpg-images/") || path.StartsWith("/gif-images/"))
            {
                return;
            }

            if (path.EndsWith(_extension, StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = _target + path + request.QueryString;
            }
        }
    }
    #endregion
}
