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

            // specify a default argument name if none is set
            var modelName = bindingContext.ModelName;
            //if (string.IsNullOrEmpty(modelName))
            //{
            //    modelName = "authorId";
            //}

            // attempt to fetch the value of the argument by name
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            // check if no matching argument exists
            if (valueProviderResult == ValueProviderResult.None)
            {
                return TaskCache.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // check if the argument is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return TaskCache.CompletedTask;
            }

            int id = 0;
            if (!int.TryParse(value, out id))
            {
                bindingContext.ModelState.TryAddModelError(
                                        bindingContext.ModelName,
                                        "Author Id must be an integer.");
                return TaskCache.CompletedTask;
            }

            // model will be null if not found
            var model = _db.Authors.Find(int.Parse(value));
            bindingContext.Result = ModelBindingResult.Success(model);
            return TaskCache.CompletedTask;
        }
    }
}
