using System.Threading.Tasks;
using DependencyInjectionSample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers
{
    #region snippet1
    public class MyDependencyController : Controller
    {
        private readonly IMyDependency _myDependency;

        public MyDependencyController(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }

        // GET: /mydependency/
        public async Task<IActionResult> Index()
        {
            await _myDependency.WriteMessage(
                "MyDependencyController.Index created this message.");

            return View();
        }
    }
    #endregion
}
