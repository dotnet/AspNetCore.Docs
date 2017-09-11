using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RazorPagesMovie.Utilities
{
    public class FileHelpers
    {
        public static async Task<(long Size, string RawText, string HtmlEncodedText)> ProcessSchedule(IFormFile scheduleFormFile)
        {
            // NOTE: Although this sample doesn't use the FileName property 
            // of IFormFile, don't trust the property without validation.

            // NOTE: The ProcessSchedule method is for demonstration
            // purposes only. It doesn't set a limit on the size of the 
            // file, check the type of file (content type or extension),
            // or validate the contents of the file.

            // Create a tuple to hold the file data
            var scheduleData = (Size: new long(), 
                RawText: string.Empty, HtmlEncodedText: string.Empty);

            scheduleData.Size = scheduleFormFile.Length;

            var fullFilePath = Path.GetTempFileName();

            if (scheduleFormFile.Length > 0)
            {
                // Create a FileStream for the file.
                using (var stream = 
                    new FileStream(fullFilePath, FileMode.Create))
                {
                    // Load the file's contents into the stream.
                    await scheduleFormFile.CopyToAsync(stream);

                    // Reset the position within the stream so that the 
                    // contents can be read from the start.
                    stream.Position = 0;

                    // Use a StreamReader to obtain the text.
                    // This example returns the raw text of the file and 
                    // an HTML-encoded version of the text.
                    using (var reader = new StreamReader(stream))
                    {
                        scheduleData.RawText = await reader.ReadToEndAsync();
                        scheduleData.HtmlEncodedText = 
                            WebUtility.HtmlEncode(scheduleData.RawText);
                    }
                }
            }

            // Delete the temp file from the system.
            System.IO.File.Delete(fullFilePath);

            return scheduleData;
        }
    }
}
