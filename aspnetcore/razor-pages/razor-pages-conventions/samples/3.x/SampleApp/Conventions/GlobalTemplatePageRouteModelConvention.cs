using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace SampleApp.Conventions
{
    #region snippet1
    public class GlobalTemplatePageRouteModelConvention 
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
                        Order = 1,
                        Template = AttributeRouteModel.CombineTemplates(
                            selector.AttributeRouteModel.Template, 
                            "{globalTemplate?}"),
                    }
                });
            }
        }
    }
    #endregion
}
