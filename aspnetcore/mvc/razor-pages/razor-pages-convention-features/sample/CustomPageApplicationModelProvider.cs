using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages.Internal;

namespace ModelProvidersSample
{
    #region snippet1
    public class CustomPageApplicationModelProvider : 
        DefaultPageApplicationModelProvider
    {
        protected override PageHandlerModel CreateHandlerModel(MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (!IsHandler(method))
            {
                return null;
            }

            if (!TryParseHandlerMethod(
                method.Name, out var httpMethod, out var handlerName))
            {
                return null;
            }

            var handlerModel = new PageHandlerModel(
                method,
                method.GetCustomAttributes(inherit: true))
            {
                Name = method.Name,
                HandlerName = handlerName,
                HttpMethod = httpMethod,
            };

            var methodParameters = handlerModel.MethodInfo.GetParameters();

            for (var i = 0; i < methodParameters.Length; i++)
            {
                var parameter = methodParameters[i];
                var parameterModel = CreateParameterModel(parameter);
                parameterModel.Handler = handlerModel;

                handlerModel.Parameters.Add(parameterModel);
            }

            return handlerModel;
        }

        private static bool TryParseHandlerMethod(
            string methodName, out string httpMethod, out string handler)
        {
            httpMethod = null;
            handler = null;

            // Parse the method name according to our conventions to 
            // determine the required HTTP verb and optional 
            // handler name.
            //
            // Valid names look like:
            //  - Get
            //  - Post
            //  - PostAsync
            //  - GetMessage
            //  - PostMessage
            //  - DeleteMessage
            //  - DeleteMessageAsync

            var length = methodName.Length;
            if (methodName.EndsWith("Async", StringComparison.Ordinal))
            {
                length -= "Async".Length;
            }

            if (length == 0)
            {
                // The method is named "Async". Exit processing.
                return false;
            }

            // The HTTP verb is at the start of the method name. Use 
            // casing to determine where it ends.
            var handlerNameStart = 1;
            for (; handlerNameStart < length; handlerNameStart++)
            {
                if (char.IsUpper(methodName[handlerNameStart]))
                {
                    break;
                }
            }

            httpMethod = methodName.Substring(0, handlerNameStart);

            // The handler name follows the HTTP verb and is optional. 
            // It includes everything up to the end excluding the 
            // "Async" suffix, if present.
            handler = handlerNameStart == length ? null : methodName.Substring(0, length);

            if (string.Equals(httpMethod, "GET", StringComparison.OrdinalIgnoreCase) || 
                string.Equals(httpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                // Do nothing. The httpMethod is correct for GET and POST.
                return true;
            }
            if (string.Equals(httpMethod, "DELETE", StringComparison.OrdinalIgnoreCase) || 
                string.Equals(httpMethod, "PUT", StringComparison.OrdinalIgnoreCase) || 
                string.Equals(httpMethod, "PATCH", StringComparison.OrdinalIgnoreCase))
            {
                // Convert HTTP verbs for DELETE, PUT, and PATCH to POST
                // For example: DeleteMessage, PutMessage, PatchMessage -> POST
                httpMethod = "POST";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
}
