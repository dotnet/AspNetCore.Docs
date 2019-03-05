using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Conventions;
using SampleApp.Data;
using SampleApp.Filters;
using SampleApp.Factories;

namespace SampleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
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
                                    Order = 2,
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
                                    Order = 2,
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

                    #region snippet10
                    options.Conventions.Add(new GlobalPageHandlerModelConvention());
                    #endregion
                });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
