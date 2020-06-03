using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace HttpRequestsSample.Pages
{
    public class IndexModel : PageModel
    {
        private const string ApiUrl = "https://localhost:5001/api/TodoItems";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public IndexModel(IHttpClientFactory httpClientFactory, IOptions<JsonOptions> jsonOptionsAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = jsonOptionsAccessor.Value.JsonSerializerOptions;
        }

        public List<TodoItem> CompleteTodoItems { get; private set; } = new List<TodoItem>();

        public List<TodoItem> IncompleteTodoItems { get; private set; } = new List<TodoItem>();

        public async Task OnGetAsync()
        {
            using var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse = await httpClient.GetAsync(ApiUrl);

            if (httpResponse.IsSuccessStatusCode)
            {
                using var httpResponseStream = await httpResponse.Content.ReadAsStreamAsync();
                var todoItems = await JsonSerializer.DeserializeAsync<List<TodoItem>>(httpResponseStream, _jsonSerializerOptions);

                CompleteTodoItems = todoItems.Where(x => x.IsComplete).ToList();
                IncompleteTodoItems = todoItems.Except(CompleteTodoItems).ToList();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong when calling the API.");
            }
        }

        public async Task<IActionResult> OnPostCreateAsync([Required] string name)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            var newTodoItem = new TodoItem
            {
                Name = name
            };

            var newTodoItemJson = new StringContent(JsonSerializer.Serialize(newTodoItem), Encoding.UTF8, "application/json");

            using var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse = await httpClient.PostAsync(ApiUrl, newTodoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            ModelState.AddModelError(string.Empty, "Something went wrong when calling the API.");
            return Page();
        }
    }
}
