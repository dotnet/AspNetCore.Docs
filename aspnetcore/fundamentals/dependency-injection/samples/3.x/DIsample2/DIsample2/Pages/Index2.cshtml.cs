using DIsample2.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIsample2.Pages
{
// Used to test Startup2
    public class Index2Model : PageModel
    {
        private readonly Service1 _service1;
        private readonly Service2 _service2;

        public Index2Model(Service1 service1, Service2 service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        public void OnGet()
        {
            _service1.Write("IndexModel.OnGet");
            _service2.Write("IndexModel.OnGet");
        }
    }
}
