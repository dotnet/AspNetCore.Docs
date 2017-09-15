using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Utilities
{
    public class FileHelpers
    {
        public static async Task<string> ProcessSchedule(IFormFile scheduleFormFile, ModelStateDictionary modelState)
        {
            var fieldDisplayName = string.Empty;

            // Use reflection to obtain the display name for the model 
            // property associated with this IFormFile. If a display
            // name isn't found, error messages simply won't show
            // a display name.
            MemberInfo property = typeof(FileUpload).GetProperty(scheduleFormFile.Name.Substring(scheduleFormFile.Name.IndexOf(".") + 1));

            if (property != null)
            {
                var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

                if (dd != null)
                {
                    fieldDisplayName = $"{dd.Name} ";
                }
            }

            // HtmlEncode the FileName property in case it must be returned
            // in an error message.
            var fileName = WebUtility.HtmlEncode(Path.GetFileName(scheduleFormFile.FileName));

            if (scheduleFormFile.ContentType.ToLower() != "text/plain")
            {
                modelState.AddModelError(scheduleFormFile.Name, $"The {fieldDisplayName}file ({fileName}) must be a text file.");
            }

            // Check the file length and don't bother even attempting
            // to read it if the file contains no content. This check
            // doesn't catch files that only have a BOM as their
            // content, so a content length check is made below after 
            // reading the file's content to catch a file that only
            // contains a BOM.
            if (scheduleFormFile.Length == 0)
            {
                modelState.AddModelError(scheduleFormFile.Name, $"The {fieldDisplayName}file ({fileName}) is empty.");
            }
            else
            {
                try
                {
                    string fileContents;

                    using (var reader = new StreamReader(scheduleFormFile.OpenReadStream(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), detectEncodingFromByteOrderMarks: true))
                    {
                        fileContents = await reader.ReadToEndAsync();

                        // Check the content length in case the file's only
                        // content was a BOM and the content is actually
                        // empty after removing the BOM.
                        if (fileContents.Length > 0)
                        {
                            return fileContents;
                        }
                        else
                        {
                            modelState.AddModelError(scheduleFormFile.Name, $"The {fieldDisplayName}file ({fileName}) is empty.");
                        }
                    }
                }
                catch (IOException ex)
                {
                    modelState.AddModelError(scheduleFormFile.Name, $"The {fieldDisplayName}file ({fileName}) upload failed. Please contact the Help Desk for support.");
                    // Log the exception
                }
            }

            return string.Empty;
        }
    }
}
