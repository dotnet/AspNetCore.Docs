using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HttpRequestsSample.Models
{
    public class TodoClient
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _httpClient;

        public TodoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            using var httpResponse = await _httpClient.GetAsync("/api/TodoItems");

            httpResponse.EnsureSuccessStatusCode();

            using var httpResponseStream = await httpResponse.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<List<TodoItem>>(httpResponseStream, _jsonSerializerOptions);
        }

        public async Task<TodoItem> GetItemAsync(long itemId)
        {
            using var httpResponse = await _httpClient.GetAsync($"/api/TodoItems/{itemId}");

            if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                return null;

            httpResponse.EnsureSuccessStatusCode();

            using var httpResponseStream = await httpResponse.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<TodoItem>(httpResponseStream, _jsonSerializerOptions);
        }

        // <snippet_POST>
        public async Task CreateItemAsync(TodoItem todoItem)
        {
            var todoItemJson = new StringContent(
                JsonSerializer.Serialize(todoItem, _jsonSerializerOptions),
                Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _httpClient.PostAsync("/api/TodoItems", todoItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }
        // </snippet_POST>

        // <snippet_PUT>
        public async Task SaveItemAsync(TodoItem todoItem)
        {
            var todoItemJson = new StringContent(
                JsonSerializer.Serialize(todoItem),
                Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _httpClient.PutAsync($"/api/TodoItems/{todoItem.Id}", todoItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }
        // </snippet_PUT>

        // <snippet_DELETE>
        public async Task DeleteItemAsync(long itemId)
        {
            using var httpResponse =
                await _httpClient.DeleteAsync($"/api/TodoItems/{itemId}");

            httpResponse.EnsureSuccessStatusCode();
        }
        // </snippet_DELETE>
    }
}
