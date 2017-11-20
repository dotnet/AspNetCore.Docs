using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesTestingSample.Data;

namespace RazorPagesTestingSample.Tests
{
    public static class Utilities
    {
        #region snippet1
        public class MessageComparer : IEqualityComparer<Message>
        {
            public bool Equals(Message firstMessage, Message secondMessage)
            {
                return firstMessage.Id == secondMessage.Id && 
                    string.Equals(firstMessage.Text, secondMessage.Text, StringComparison.Ordinal);
            }

            public int GetHashCode(Message message)
            {
                if (Object.ReferenceEquals(message, null)) return 0;
                int hashMessageId = message.Id.GetHashCode();
                int hashMessageText = message.Text == null ? 0 : message.Text.GetHashCode();
                return hashMessageId ^ hashMessageText;
            }
        }
        #endregion

        #region snippet2
        public static DbContextOptions<AppDbContext> TestingDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
        #endregion

        #region snippet3
        public static async Task<FormUrlEncodedContent> GetRequestContentAsync(
            HttpClient _client, string path, IDictionary<string, string> data)
        {
            // Make a request for the resource.
            var getResponse = await _client.GetAsync(path);

            // Set the response's antiforgery cookie on the HttpClient.
            _client.DefaultRequestHeaders.Add("Cookie", 
                getResponse.Headers.GetValues("Set-Cookie"));

            // Obtain the request verification token from the response.
            // Any <form> element in the response contains a token, and
            // they're all the same within a single response.
            var responseMarkup = await getResponse.Content.ReadAsStringAsync();
            var regExp_RequestVerificationToken = new Regex(
                "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" \\/>", 
                RegexOptions.Compiled);
            var matches = regExp_RequestVerificationToken.Matches(responseMarkup);
            // Group[1] represents the captured characters, represented
            // by (.*?) in the Regex pattern string.
            var token = matches?.FirstOrDefault().Groups[1].Value;

            // Add the token to the form data for the request.
            data.Add("__RequestVerificationToken", token);

            return new FormUrlEncodedContent(data);
        }
        #endregion
    }
}
