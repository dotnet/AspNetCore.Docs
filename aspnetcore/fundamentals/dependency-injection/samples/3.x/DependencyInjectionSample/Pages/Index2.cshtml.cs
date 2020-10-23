using DependencyInjectionSample.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            _myDependency.WriteMessage("Index2Model.OnGet");
        }
    }
    #endregion
}
