using System.ComponentModel.DataAnnotations;
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
    public class ItemModel : PageModel
    {
        private const string ApiUrl = "https://localhost:5001/api/TodoItems/";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ItemModel(IHttpClientFactory httpClientFactory, IOptions<JsonOptions> jsonOptionsAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = jsonOptionsAccessor.Value.JsonSerializerOptions;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse = await httpClient.GetAsync(ApiUrl + id.ToString());

            if (httpResponse.IsSuccessStatusCode)
            {
                using var httpResponseStream = await httpResponse.Content.ReadAsStreamAsync();
                var todoItem = await JsonSerializer.DeserializeAsync<TodoItem>(httpResponseStream, _jsonSerializerOptions);

                Input = new InputModel
                {
                    Name = todoItem.Name,
                    IsComplete = todoItem.IsComplete
                };
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong when calling the API.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updatedTodoItem = new TodoItem
            {
                Id = id,
                Name = Input.Name,
                IsComplete = Input.IsComplete
            };

            var updatedTodoItemJson = new StringContent(JsonSerializer.Serialize(updatedTodoItem), Encoding.UTF8, "application/json");

            using var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse = await httpClient.PutAsync(ApiUrl + id.ToString(), updatedTodoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Something went wrong when calling the API.");
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse = await httpClient.DeleteAsync(ApiUrl + id.ToString());

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Something went wrong when calling the API.");
            return Page();
        }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }

            public bool IsComplete { get; set; }
        }
    }
}
