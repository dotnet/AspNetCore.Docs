using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SampleApp.Conventions;
using SampleApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddRazorPages(options =>
            {
                #region snippet1
                options.Conventions.Add(new GlobalTemplatePageRouteModelConvention());
                #endregion

                #region snippet2
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
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
