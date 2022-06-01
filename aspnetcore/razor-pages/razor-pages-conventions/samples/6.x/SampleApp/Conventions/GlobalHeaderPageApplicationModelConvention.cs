using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SampleApp.Filters;

namespace SampleApp.Conventions
{
    #region snippet1
    public class GlobalHeaderPageApplicationModelConvention 
        : IPageApplicationModelConvention
    {
        public void Apply(PageApplicationModel model)
        {
            model.Filters.Add(new AddHeaderAttribute(
                "GlobalHeader", new string[] { "Global Header Value" }));
        }
    }
    #endregion
}
