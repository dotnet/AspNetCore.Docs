using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample.Pages
{
    #region snippet1
    public class Index2Model : PageModel
    {
        private readonly IMyDependency _myDependency;

        public Index2Model(IMyDependency myDependency)
        {
            _myDependency = myDependency;            
        }

        public void OnGet()
        {
            _myDependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }
    #endregion
}
