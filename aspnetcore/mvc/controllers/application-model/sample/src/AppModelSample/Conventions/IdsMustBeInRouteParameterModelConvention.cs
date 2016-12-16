using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppModelSample.Conventions
{
    public class IdsMustBeInRouteParameterModelConvention : IParameterModelConvention
    {
        public void Apply(ParameterModel model)
        {
            if (model.ParameterName == "id")
            {
                model.BindingInfo.BindingSource = BindingSource.Path;
            }
        }
    }
}