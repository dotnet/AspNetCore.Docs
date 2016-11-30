using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppModelSample.Conventions
{
    public class SpecialParameterAttribute : Attribute, IParameterModelConvention
    {
        public void Apply(ParameterModel model)
        {
            model.BindingInfo = model.BindingInfo ?? new BindingInfo();
            model.BindingInfo.BindingSource = BindingSource.Custom;
            model.BindingInfo.BinderModelName = "Special";
        }
    }
}