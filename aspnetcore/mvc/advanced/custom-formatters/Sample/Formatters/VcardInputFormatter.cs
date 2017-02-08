using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CustomFormatterDemo.Models;

namespace CustomFormatterDemo.Formatters
{
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
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding effectiveEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (effectiveEncoding == null)
            {
                throw new ArgumentNullException(nameof(effectiveEncoding));
            }

            var request = context.HttpContext.Request;

            using (var reader = new StreamReader(request.Body, effectiveEncoding))
            {
                try
                {
                    await ReadLineAsync("BEGIN:VCARD", reader);
                    await ReadLineAsync("VERSION:2.1", reader);

                    var nameLine = await ReadLineAsync("N:", reader);
                    var split = nameLine.Split(";".ToCharArray());
                    var contact = new Contact() { LastName = split[0].Substring(2), FirstName = split[1] };

                    await ReadLineAsync("FN:", reader);

                    var idLine = await ReadLineAsync("UID:", reader);
                    contact.ID = idLine.Substring(4);

                    await ReadLineAsync("END:VCARD", reader);

                    return await InputFormatterResult.SuccessAsync(contact);
                }
                catch
                {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }

        private async Task<string> ReadLineAsync(string expectedText, StreamReader reader)
        {
            var line = await reader.ReadLineAsync();
            if (!line.StartsWith(expectedText))
            {
                throw new Exception($"Looked for '{expectedText}' and got '{line}'");
            }
            return line;
        }
        #endregion
    }
}
