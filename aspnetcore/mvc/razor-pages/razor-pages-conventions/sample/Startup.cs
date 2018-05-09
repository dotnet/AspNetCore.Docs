using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelProvidersSample.Conventions;
using ModelProvidersSample.Data;
using ModelProvidersSample.Filters;
using ModelProvidersSample.Factories;

namespace ModelProvidersSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddMvc()
                .AddRazorPagesOptions(options =>
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
                                    Order = 1,
                                    Template = AttributeRouteModel.CombineTemplates(
                                        selector.AttributeRouteModel.Template, 
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
                                    Order = 1,
                                    Template = AttributeRouteModel.CombineTemplates(
                                        selector.AttributeRouteModel.Template, 
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
                });

            #region snippet10
            services.AddSingleton<IPageApplicationModelProvider, 
                CustomPageApplicationModelProvider>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
