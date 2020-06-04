using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpRequestsSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoClient _todoClient;

        public IndexModel(TodoClient todoClient)
        {
            _todoClient = todoClient;
        }

        public List<TodoItem> CompleteTodoItems { get; private set; }

        public List<TodoItem> IncompleteTodoItems { get; private set; }

        public async Task OnGetAsync()
        {
            var todoItems = await _todoClient.GetItemsAsync();

            CompleteTodoItems = todoItems.Where(x => x.IsComplete).ToList();
            IncompleteTodoItems = todoItems.Except(CompleteTodoItems).ToList();
        }

        public async Task<IActionResult> OnPostCreateAsync([Required] string name)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            var newTodoItem = new TodoItem
            {
                Name = name
            };

            await _todoClient.CreateItemAsync(newTodoItem);

            return RedirectToPage();
        }
    }
}
