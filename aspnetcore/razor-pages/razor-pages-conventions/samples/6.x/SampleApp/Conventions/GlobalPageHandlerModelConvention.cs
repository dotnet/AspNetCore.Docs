using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace SampleApp.Conventions
{
    #region snippet1
    public class GlobalPageHandlerModelConvention
        : IPageHandlerModelConvention
    {
        public void Apply(PageHandlerModel model)
        {
            // Access the PageHandlerModel
        }
    }
    #endregion
}