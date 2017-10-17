using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ModelProvidersSample.Conventions
{
    #region snippet1
    public class GlobalAttributePageRouteModelConvention 
        : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;
            for (var i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];
                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = AttributeRouteModel.CombineTemplates(
                            selector.AttributeRouteModel.Template, 
                            "{globalAttribute?}"),
                    }
                });
            }
        }
    }
    #endregion
}
