using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpRequestsSample.Pages
{
    public class ItemModel : PageModel
    {
        private readonly TodoClient _todoClient;

        public ItemModel(TodoClient todoClient)
        {
            _todoClient = todoClient;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var todoItem = await _todoClient.GetItemAsync(id);

            if (todoItem == null)
                return RedirectToPage("/Index");

            Input = new InputModel
            {
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

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

            await _todoClient.SaveItemAsync(updatedTodoItem);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _todoClient.DeleteItemAsync(id);

            return RedirectToPage("/Index");
        }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }

            public bool IsComplete { get; set; }
        }
    }
}
