using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ModelProvidersSample.Filters;

namespace ModelProvidersSample.Conventions
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
