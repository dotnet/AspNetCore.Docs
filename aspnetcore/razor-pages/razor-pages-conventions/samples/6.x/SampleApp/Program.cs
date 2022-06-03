#define SECOND // FIRST SECOND
#if NEVER
#elif FIRST
#region snippet11
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SampleApp.Conventions;
using SampleApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
                                   options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddRazorPages(options =>
   {
       options.Conventions.Add(new GlobalTemplatePageRouteModelConvention());

       options.Conventions.AddFolderRouteModelConvention("/OtherPages", model =>
       {
           var selectorCount = model.Selectors.Count;
           for (var i = 0; i < selectorCount; i++)
           {
               var selector = model.Selectors[i];
               model.Selectors.Add(new SelectorModel
               {
                   AttributeRouteModel = new AttributeRouteModel
                   {
                       Order = 2,
                       Template = AttributeRouteModel.CombineTemplates(
                           selector.AttributeRouteModel!.Template,
                           "{otherPagesTemplate?}"),
                   }
               });
           }
       });

       options.Conventions.AddPageRouteModelConvention("/About", model =>
       {
           var selectorCount = model.Selectors.Count;
           for (var i = 0; i < selectorCount; i++)
           {
               var selector = model.Selectors[i];
               model.Selectors.Add(new SelectorModel
               {
                   AttributeRouteModel = new AttributeRouteModel
                   {
                       Order = 2,
                       Template = AttributeRouteModel.CombineTemplates(
                           selector.AttributeRouteModel!.Template,
                           "{aboutTemplate?}"),
                   }
               });
           }
       });

   });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
#endregion
#elif SECOND
#region snippet12
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SampleApp.Conventions;
using SampleApp.Data;
using SampleApp.Factories;
using SampleApp.Filters;
#region snippet2
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddRazorPages(options =>
   {
       #region snippet1
       options.Conventions.Add(new GlobalTemplatePageRouteModelConvention());
       #endregion

       options.Conventions.Add(new GlobalHeaderPageApplicationModelConvention());
       #endregion

       #region snippet3
       options.Conventions.AddFolderRouteModelConvention("/OtherPages", model =>
       {
           var selectorCount = model.Selectors.Count;
           for (var i = 0; i < selectorCount; i++)
           {
               var selector = model.Selectors[i];
               model.Selectors.Add(new SelectorModel
               {
                   AttributeRouteModel = new AttributeRouteModel
                   {
                       Order = 2,
                       Template = AttributeRouteModel.CombineTemplates(
                           selector.AttributeRouteModel!.Template,
                           "{otherPagesTemplate?}"),
                   }
               });
           }
       });
       #endregion

       #region snippet4
       options.Conventions.AddPageRouteModelConvention("/About", model =>
       {
           var selectorCount = model.Selectors.Count;
           for (var i = 0; i < selectorCount; i++)
           {
               var selector = model.Selectors[i];
               model.Selectors.Add(new SelectorModel
               {
                   AttributeRouteModel = new AttributeRouteModel
                   {
                       Order = 2,
                       Template = AttributeRouteModel.CombineTemplates(
                           selector.AttributeRouteModel!.Template,
                           "{aboutTemplate?}"),
                   }
               });
           }
       });
       #endregion

       #region snippet5
       options.Conventions.AddPageRoute("/Contact", "TheContactPage/{text?}");
       #endregion

       #region snippet6
       options.Conventions.AddFolderApplicationModelConvention("/OtherPages", model =>
       {
           model.Filters.Add(new AddHeaderAttribute(
               "OtherPagesHeader", new string[] { "OtherPages Header Value" }));
       });
       #endregion

       #region snippet7
       options.Conventions.AddPageApplicationModelConvention("/About", model =>
       {
           model.Filters.Add(new AddHeaderAttribute(
               "AboutHeader", new string[] { "About Header Value" }));
       });
       #endregion

       #region snippet8
       options.Conventions.ConfigureFilter(model =>
       {
           if (model.RelativePath.Contains("OtherPages/Page2"))
           {
               return new AddHeaderAttribute(
                   "OtherPagesPage2Header",
                   new string[] { "OtherPages/Page2 Header Value" });
           }
           return new EmptyFilter();
       });
       #endregion

       #region snippet9
       options.Conventions.ConfigureFilter(new AddHeaderWithFactory());
       #endregion

       #region snippet10
       options.Conventions.Add(new GlobalPageHandlerModelConvention());
       #endregion
   });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
#endregion
#endif 
