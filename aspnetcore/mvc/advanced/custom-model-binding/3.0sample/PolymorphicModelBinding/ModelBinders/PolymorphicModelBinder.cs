using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace PolymorphicModelBinding.ModelBinders
{
    #region snippet
    [ModelBinder(typeof(DeviceModelBinder))]
    public class Device
    {
        public string Kind { get; set; }
    }

    public class Laptop : Device
    {
        public string CPUIndex { get; set; }
    }

    public class SmartPhone : Device
    {
        public string ScreenSize { get; set; }
    }

    public class DeviceModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var name = ModelNames.CreatePropertyModelName(
                bindingContext.ModelName,
                nameof(Device.Kind));

            var deviceKind = bindingContext.ValueProvider.GetValue(name).FirstValue;

            if (string.IsNullOrEmpty(deviceKind))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            Device result;
            if (deviceKind == "Laptop")
            {
                var modelName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(Laptop.CPUIndex));
                var cpuIndex = bindingContext.ValueProvider.GetValue(modelName).FirstValue;
                result = new Laptop
                {
                    Kind = deviceKind,
                    CPUIndex = cpuIndex,
                };
            }
            else if (deviceKind == "SmartPhone")
            {
                var modelName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(SmartPhone.ScreenSize));
                var screenSize = bindingContext.ValueProvider.GetValue(modelName).FirstValue;
                result = new SmartPhone
                {
                    Kind = deviceKind,
                    ScreenSize = screenSize,
                };
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(name, $"Unknown device kind '{deviceKind}'.");

                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);

            // Add a ValidationStateEntry with the "correct" ModelMetadata so validation executes on the actual type, not the declared type.
            var modelMetadataProvider = bindingContext.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();

            bindingContext.ValidationState.Add(result, new ValidationStateEntry
            {
                Metadata = modelMetadataProvider.GetMetadataForType(result.GetType()),
            });

            return Task.CompletedTask;
        }
    }
    #endregion
}
