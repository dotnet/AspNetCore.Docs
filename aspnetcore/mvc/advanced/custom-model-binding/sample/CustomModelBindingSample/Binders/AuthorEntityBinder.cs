using CustomModelBindingSample.Data;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomModelBindingSample.Binders
{
    public class AuthorEntityBinder : IModelBinder
    {
        private readonly AppDbContext _db;
        public AuthorEntityBinder(AppDbContext db)
        {
            _db = db;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // get the value of the appropriate argument
            var valueProviderResult = 
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            // check if no matching argument exists
            if (valueProviderResult == ValueProviderResult.None)
            {
                return TaskCache.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName,
                valueProviderResult);

            var value = valueProviderResult.FirstValue;
            
            // check if the argument is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return TaskCache.CompletedTask;
            }

            try
            {
                var model = _db.Authors.Find(int.Parse(value));
                if(model == null)
                {
                    bindingContext.ModelState.TryAddModelError(
                                        bindingContext.ModelName,
                                        "Author not found.");
                    return TaskCache.CompletedTask;
                }
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.TryAddModelError(
                                    bindingContext.ModelName,
                                    ex,
                                    bindingContext.ModelMetadata);
            }
            return TaskCache.CompletedTask;
        }
    }
}
