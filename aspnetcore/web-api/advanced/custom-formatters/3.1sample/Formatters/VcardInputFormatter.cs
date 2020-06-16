using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CustomFormatterDemo.Models;
using Microsoft.Extensions.Logging;

namespace CustomFormatterDemo.Formatters
{
    #region snippet
    #region classdef
    public class VcardInputFormatter : TextInputFormatter
    #endregion
    {
        #region ctor
        public VcardInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        #endregion

        #region canreadtype
        protected override bool CanReadType(Type type)
        {
            if (type == typeof(Contact))
            {
                return base.CanReadType(type);
            }
            return false;
        }
        #endregion

        #region readrequest
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
                                  InputFormatterContext context, Encoding effectiveEncoding)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            var logger = serviceProvider.GetService(typeof(ILogger<VcardInputFormatter>)) 
                                                    as ILogger;

            if (context == null)
            {
                var nameOfContext = nameof(context);
                logger.LogError(nameOfContext);
                throw new ArgumentNullException(nameOfContext);
            }

            if (effectiveEncoding == null)
            {
                var nameofEffectiveEncoding = nameof(effectiveEncoding);
                logger.LogError(nameofEffectiveEncoding);
                throw new ArgumentNullException(nameofEffectiveEncoding);
            }

            var request = context.HttpContext.Request;

            using (var reader = new StreamReader(request.Body, effectiveEncoding))
            {
                string nameLine=null;
                try
                {
                    await ReadLineAsync("BEGIN:VCARD", reader, context, logger);
                    await ReadLineAsync("VERSION:", reader, context, logger);

                    nameLine = await ReadLineAsync("N:", reader, context, logger);
                    var split = nameLine.Split(";".ToCharArray());
                    var contact = new Contact() { LastName = split[0].Substring(2), 
                                             FirstName = split[1] };

                    await ReadLineAsync("FN:", reader, context, logger);
                    await ReadLineAsync("END:VCARD", reader, context, logger);
                    logger.LogInformation("nameLine = {nameLine}", nameLine);

                    return await InputFormatterResult.SuccessAsync(contact);
                }
                catch
                {
                    logger.LogError("Read failed: nameLine = {nameLine}", nameLine);
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }

        private async Task<string> ReadLineAsync(string expectedText, StreamReader reader,
                                                 InputFormatterContext context,
                                                 ILogger logger)
        {
            var line = await reader.ReadLineAsync();
            if (!line.StartsWith(expectedText))
            {
                var errorMessage = $"Looked for '{expectedText}' and got '{line}'";
                context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
            return line;
        }
        #endregion
    }
    #endregion
}
