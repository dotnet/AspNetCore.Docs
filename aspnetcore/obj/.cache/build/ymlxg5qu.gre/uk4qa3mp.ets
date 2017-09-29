<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Migrating From ASP.NET to ASP.NET Core 2.0 </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Migrating From ASP.NET to ASP.NET Core 2.0 ">
    <meta name="generator" content="docfx 2.24.0.0">
    
    <link rel="shortcut icon" href="../../favicon.ico">
    <link rel="stylesheet" href="../../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../../styles/docfx.css">
    <link rel="stylesheet" href="../../styles/main.css">
    <meta property="docfx:navrel" content="/foo">
    <meta property="docfx:tocrel" content="../../toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../../index.html">
                <img id="logo" class="svg" src="../../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="migration/mvc2">
<h1 id="migrating-from-aspnet-to-aspnet-core-20">Migrating From ASP.NET to ASP.NET Core 2.0</h1>

<p>By <a href="https://isaaclevin.com">Isaac Levin</a></p>
<p>This article serves as a reference guide for migrating ASP.NET applications to ASP.NET Core 2.0.</p>
<h2 id="prerequisites">Prerequisites</h2>
<ul>
<li><a href="https://www.microsoft.com/net/core">.NET Core 2.0.0 SDK</a> or later.</li>
</ul>
<h2 id="target-frameworks">Target Frameworks</h2>
<p>ASP.NET Core 2.0 projects offer developers the flexibility of targeting .NET Core, .NET Framework, or both. See <a href="https://docs.microsoft.com/dotnet/standard/choosing-core-framework-server">Choosing between .NET Core and .NET Framework for server apps</a> to determine which target framework is most appropriate.</p>
<p>When targeting .NET Framework, projects need to reference individual NuGet packages.</p>
<p>Targeting .NET Core allows you to eliminate numerous explicit package references, thanks to the ASP.NET Core 2.0 <a class="xref" href="../../fundamentals/metapackage.html">metapackage</a>. Install the <code>Microsoft.AspNetCore.All</code> metapackage in your project:</p>
<pre><code class="lang-xml">&lt;ItemGroup&gt;
  &lt;PackageReference Include=&quot;Microsoft.AspNetCore.All&quot; Version=&quot;2.0.0&quot; /&gt;
&lt;/ItemGroup&gt;
</code></pre><p>When the metapackage is used, no packages referenced in the metapackage are deployed with the app. The .NET Core Runtime Store includes these assets, and they are precompiled to improve performance. See <a class="xref" href="../../fundamentals/metapackage.html">Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.x</a> for more detail.</p>
<h2 id="project-structure-differences">Project structure differences</h2>
<p>The <em>.csproj</em> file format has been simplified in ASP.NET Core. Some notable changes include:</p>
<ul>
<li>Explicit inclusion of files is not necessary for them to be considered part of the project. This reduces the risk of XML merge conflicts when working on large teams.</li>
<li>There are no GUID-based references to other projects, which improves file readability.</li>
<li><p>The file can be edited without unloading it in Visual Studio:</p>
<p>  <img src="_static/EditProjectVs2017.png" alt="Edit CSPROJ context menu option in Visual Studio 2017"></p>
</li>
</ul>
<h2 id="globalasax-file-replacement">Global.asax file replacement</h2>
<p>ASP.NET Core introduced a new mechanism for bootstrapping an app. The entry point for ASP.NET applications is the <em>Global.asax</em> file. Tasks such as route configuration and filter and area registrations are handled in the <em>Global.asax</em> file.</p>
<pre><code class="lang-csharp" name="Main">public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
}
</code></pre><p>This approach couples the application and the server to which it&#39;s deployed in a way that interferes with the implementation. In an effort to decouple, <a href="http://owin.org/">OWIN</a> was introduced to provide a cleaner way to use multiple frameworks together. OWIN provides a pipeline to add only the modules needed. The hosting environment takes a <a class="xref" href="../../fundamentals/startup.html">Startup</a> function to configure services and the app&#39;s request pipeline. <code>Startup</code> registers a set of middleware with the application. For each request, the application calls each of the the middleware components with the head pointer of a linked list to an existing set of handlers. Each middleware component can add one or more handlers to the request handling pipeline. This is accomplished by returning a reference to the handler that is the new head of the list. Each handler is responsible for remembering and invoking the next handler in the list. With ASP.NET Core, the entry point to an application is <code>Startup</code>, and you no longer have a dependency on <em>Global.asax</em>. When using OWIN with .NET Framework, use something like the following as a pipeline:</p>
<pre><code class="lang-csharp" name="Main">using Owin;
using System.Web.Http;

namespace WebApi
{
    // Note: By default all requests go through this OWIN pipeline. Alternatively you can turn this off by adding an appSetting owin:AutomaticAppStartup with value “false”. 
    // With this turned off you can still have OWIN apps listening on specific routes by adding routes in global.asax file using MapOwinPath or MapOwinRoute extensions on RouteTable.Routes
    public class Startup
    {
        // Invoked once at startup to configure your application.
        public void Configuration(IAppBuilder builder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(&quot;Default&quot;, &quot;{controller}/{customerID}&quot;, new { controller = &quot;Customer&quot;, customerID = RouteParameter.Optional });

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            // config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            builder.UseWebApi(config);
        }
    }
}
</code></pre><p>This configures your default routes, and defaults to XmlSerialization over Json. Add other Middleware to this pipeline as needed (loading services, configuration settings, static files, etc.).</p>
<p>ASP.NET Core uses a similar approach, but doesn&#39;t rely on OWIN to handle the entry. Instead, that is done through the <em>Program.cs</em> <code>Main</code> method (similar to console applications) and <code>Startup</code> is loaded through there.</p>
<pre><code class="lang-csharp" name="Main">using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =&gt;
            WebHost.CreateDefaultBuilder(args)
                .UseStartup&lt;Startup&gt;()
                .Build();
    }
}
</code></pre><p><code>Startup</code> must include a <code>Configure</code> method. In <code>Configure</code>, add the necessary middleware to the pipeline. In the following example (from the default web site template), several extension methods are used to configure the pipeline with support for:</p>
<ul>
<li><a href="http://vswebessentials.com/features/browserlink">BrowserLink</a></li>
<li>Error pages</li>
<li>Static files</li>
<li>ASP.NET Core MVC</li>
<li>Identity</li>
</ul>
<pre><code class="lang-csharp" name="Main" highlight-lines="8,9,10,14,17,19,21">public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole(Configuration.GetSection(&quot;Logging&quot;));
    loggerFactory.AddDebug();

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
        app.UseBrowserLink();
    }
    else
    {
        app.UseExceptionHandler(&quot;/Home/Error&quot;);
    }

    app.UseStaticFiles();

    app.UseIdentity();

    app.UseMvc(routes =&gt;
    {
        routes.MapRoute(
            name: &quot;default&quot;,
            template: &quot;{controller=Home}/{action=Index}/{id?}&quot;);
    });
}
</code></pre><p>The host and application have been decoupled, which provides the flexibility of moving to a different platform in the future.</p>
<p><strong>Note:</strong> For a more in-depth reference to ASP.NET Core Startup and Middleware, see <a class="xref" href="../../fundamentals/startup.html">Startup in ASP.NET Core</a></p>
<h2 id="storing-configurations">Storing Configurations</h2>
<p>ASP.NET supports storing settings. These setting are used, for example, to support the environment to which the applications were deployed. A common practice was to store all custom key-value pairs in the <code>&lt;appSettings&gt;</code> section of the <em>Web.config</em> file:</p>
<pre><code class="lang-xml" name="Main">&lt;appSettings&gt;
  &lt;add key=&quot;UserName&quot; value=&quot;User&quot; /&gt;
  &lt;add key=&quot;Password&quot; value=&quot;Password&quot; /&gt;
&lt;/appSettings&gt;
</code></pre><p>Applications read these settings using the <code>ConfigurationManager.AppSettings</code> collection in the <code>System.Configuration</code> namespace:</p>
<pre><code class="lang-csharp" name="Main">string userName = System.Web.Configuration.ConfigurationManager.AppSettings[&quot;UserName&quot;];
string password = System.Web.Configuration.ConfigurationManager.AppSettings[&quot;Password&quot;];
</code></pre><p>ASP.NET Core can store configuration data for the application in any file and load them as part of middleware bootstrapping. The default file used in the project templates is <em>appsettings.json</em>:</p>
<pre><code class="lang-json" name="Main">{
  &quot;Logging&quot;: {
    &quot;IncludeScopes&quot;: false,
    &quot;LogLevel&quot;: {
      &quot;Default&quot;: &quot;Debug&quot;,
      &quot;System&quot;: &quot;Information&quot;,
      &quot;Microsoft&quot;: &quot;Information&quot;
    }
  },
  // Here is where you can supply custom configuration settings, Since it is is JSON, everything is represented as key: value pairs
  // Name of section is your choice
  &quot;AppConfiguration&quot;: {
    &quot;UserName&quot;: &quot;UserName&quot;,
    &quot;Password&quot;: &quot;Password&quot;
  }
}
</code></pre><p>Loading this file into an instance of <code>IConfiguration</code> inside your application is done in <em>Startup.cs</em>:</p>
<pre><code class="lang-csharp" name="Main">public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public IConfiguration Configuration { get; }
</code></pre><p>The app reads from <code>Configuration</code> to get the settings:</p>
<pre><code class="lang-csharp" name="Main">string userName = Configuration.GetSection(&quot;AppConfiguration&quot;)[&quot;UserName&quot;];
string password = Configuration.GetSection(&quot;AppConfiguration&quot;)[&quot;Password&quot;];
</code></pre><p>There are extensions to this approach to make the process more robust, such as using <a class="xref" href="../../fundamentals/dependency-injection.html">Dependency Injection</a> (DI) to load a service with these values. The DI approach provides a strongly-typed set of configuration objects.</p>
<pre><code class="lang-csharp">// Assume AppConfiguration is a class representing a strongly-typed version of AppConfiguration section
services.Configure&lt;AppConfiguration&gt;(Configuration.GetSection(&quot;AppConfiguration&quot;));
</code></pre><p><strong>Note:</strong> For a more in-depth reference to ASP.NET Core configuration, see <a class="xref" href="../../fundamentals/configuration.html">Configuration in ASP.NET Core</a>.</p>
<h2 id="native-dependency-injection">Native Dependency Injection</h2>
<p>An important goal when building large, scalable applications is the loose coupling of components and services. <a class="xref" href="../../fundamentals/dependency-injection.html">Dependency Injection</a> is a popular technique for achieving this, and it is a native component of ASP.NET Core.</p>
<p>In ASP.NET applications, developers rely on a third-party library to implement Dependency Injection. One such library is <a href="https://github.com/unitycontainer/unity">Unity</a>, provided by Microsoft Patterns &amp; Practices. </p>
<p>An example of setting up Dependency Injection with Unity is implementing <code>IDependencyResolver</code> that wraps a <code>UnityContainer</code>:</p>
<pre><code class="lang-csharp" name="Main">using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

public class UnityResolver : IDependencyResolver
{
    protected IUnityContainer container;

    public UnityResolver(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException(&quot;container&quot;);
        }
        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        try
        {
            return container.Resolve(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return null;
        }
    }

    public IEnumerable&lt;object&gt; GetServices(Type serviceType)
    {
        try
        {
            return container.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List&lt;object&gt;();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = container.CreateChildContainer();
        return new UnityResolver(child);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        container.Dispose();
    }
}
</code></pre><p>Create an instance of your <code>UnityContainer</code>, register your service, and set the dependency resolver of <code>HttpConfiguration</code> to the new instance of <code>UnityResolver</code> for your container:</p>
<pre><code class="lang-csharp" name="Main">public static void Register(HttpConfiguration config)
{
    var container = new UnityContainer();
    container.RegisterType&lt;IProductRepository, ProductRepository&gt;(new HierarchicalLifetimeManager());
    config.DependencyResolver = new UnityResolver(container);

    // Other Web API configuration not shown.
}
</code></pre><p>Inject <code>IProductRepository</code> where needed:</p>
<pre><code class="lang-csharp" name="Main">public class ProductsController : ApiController
{
    private IProductRepository _repository;

    public ProductsController(IProductRepository repository)  
    {
        _repository = repository;
    }

    // Other controller methods not shown.
}
</code></pre><p>Because Dependency Injection is part of ASP.NET Core, you can add your service in the <code>ConfigureServices</code> method of <em>Startup.cs</em>:</p>
<pre><code class="lang-csharp" name="Main">public void ConfigureServices(IServiceCollection services)
{
    // Add application services.
    services.AddTransient&lt;IProductRepository, ProductRepository&gt;();
}
</code></pre><p>The repository can be injected anywhere, as was true with Unity.</p>
<p><strong>Note:</strong> For an in-depth reference to dependency injection in ASP.NET Core, see <a class="xref" href="../../fundamentals/dependency-injection.html#replacing-the-default-services-container">Dependency Injection in ASP.NET Core</a></p>
<h2 id="serving-static-files">Serving Static Files</h2>
<p>An important part of web development is the ability to serve static, client-side assets. The most common examples of static files are HTML, CSS, Javascript, and images. These files need to be saved in the published location of the app (or CDN) and referenced so they can be loaded by a request. This process has changed in ASP.NET Core.</p>
<p>In ASP.NET, static files are stored in various directories and referenced in the views.</p>
<p>In ASP.NET Core, static files are stored in the &quot;web root&quot; (<em>&lt;content root&gt;/wwwroot</em>), unless configured otherwise. The files are loaded into the request pipeline by invoking the <code>UseStaticFiles</code> extension method from <code>Startup.Configure</code>:</p>
<pre><code class="lang-csharp" name="Main" highlight-lines="3">public void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();
}
</code></pre><p><strong>Note:</strong> If targeting .NET Framework, install the NuGet package <code>Microsoft.AspNetCore.StaticFiles</code>.</p>
<p>For example, an image asset in the <em>wwwroot/images</em> folder is accessible to the browser at a location such as <code>http://&lt;app&gt;/images/&lt;imageFileName&gt;</code>.</p>
<p><strong>Note:</strong> For a more in-depth reference to serving static files in ASP.NET Core, see <a class="xref" href="../../fundamentals/static-files.html">Introduction to working with static files in ASP.NET Core</a>.</p>
<h2 id="additional-resources">Additional Resources</h2>
<ul>
<li><a href="https://docs.microsoft.com/dotnet/core/porting/libraries">Porting Libraries to .NET Core</a></li>
</ul>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/aspnet/Docs/blob/w/riande/RP-EF/aspnetcore/migration/proper-to-2x/mvc2.md/#L1" class="contribution-link">Improve this Doc</a>
                  </li>
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
              <!-- <p><a class="back-to-top" href="#top">Back to top</a><p> -->
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Copyright © 2015-2017 Microsoft<br>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../../styles/docfx.js"></script>
    <script type="text/javascript" src="../../styles/main.js"></script>
  </body>
</html>
