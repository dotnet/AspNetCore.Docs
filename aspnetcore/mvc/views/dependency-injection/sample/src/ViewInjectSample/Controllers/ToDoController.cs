using Microsoft.AspNetCore.Mvc;
using ViewInjectSample.Interfaces;

namespace ViewInjectSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [Route("Todo")]
        public IActionResult Index()
        {
            var model = _toDoItemRepository.List();
            return View(model);
        }
    }
}
