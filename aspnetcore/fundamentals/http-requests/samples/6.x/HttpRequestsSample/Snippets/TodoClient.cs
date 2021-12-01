using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HttpRequestsSample.Snippets;

using static System.Net.Mime.MediaTypeNames;

public class TodoClient
{
    private readonly HttpClient _httpClient;

    public TodoClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    // <snippet_POST>
    public async Task CreateItemAsync(TodoItem todoItem)
    {
        var todoItemJson = new StringContent(
            JsonSerializer.Serialize(todoItem),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

        using var httpResponseMessage =
            await _httpClient.PostAsync("/api/TodoItems", todoItemJson);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
    // </snippet_POST>

    // <snippet_PUT>
    public async Task SaveItemAsync(TodoItem todoItem)
    {
        var todoItemJson = new StringContent(
            JsonSerializer.Serialize(todoItem),
            Encoding.UTF8,
            Application.Json);

        using var httpResponseMessage =
            await _httpClient.PutAsync($"/api/TodoItems/{todoItem.Id}", todoItemJson);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
    // </snippet_PUT>

    // <snippet_DELETE>
    public async Task DeleteItemAsync(long itemId)
    {
        using var httpResponseMessage =
            await _httpClient.DeleteAsync($"/api/TodoItems/{itemId}");

        httpResponseMessage.EnsureSuccessStatusCode();
    }
    // </snippet_DELETE>

    public record TodoItem(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("isComplete")] bool IsComplete);
}
