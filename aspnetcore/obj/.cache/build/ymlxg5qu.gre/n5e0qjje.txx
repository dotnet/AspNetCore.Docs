<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>ASP.NET Core Web API Help Pages using Swagger </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="ASP.NET Core Web API Help Pages using Swagger ">
    <meta name="generator" content="docfx 2.24.0.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="/foo">
    <meta property="docfx:tocrel" content="../toc.html">
    
    
    
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
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
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
            <article class="content wrap" id="_content" data-uid="tutorials/web-api-help-pages-using-swagger">
<h1 id="aspnet-web-api-help-pages-using-swagger" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="15" sourceendlinenumber="15">ASP.NET Web API Help Pages using Swagger</h1>

<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="17" sourceendlinenumber="17"><a name="web-api-help-pages-using-swagger"></a></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="19" sourceendlinenumber="19">By <a href="https://twitter.com/spboyer" data-raw-source="[Shayne Boyer](https://twitter.com/spboyer)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="19" sourceendlinenumber="19">Shayne Boyer</a> and <a href="https://twitter.com/Scott_Addie" data-raw-source="[Scott Addie](https://twitter.com/Scott_Addie)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="19" sourceendlinenumber="19">Scott Addie</a></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="21" sourceendlinenumber="21">Understanding the various methods of an API can be a challenge for a developer when building a consuming application.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="23" sourceendlinenumber="23">Generating good documentation and help pages for your Web API, using <a href="https://swagger.io/" data-raw-source="[Swagger](https://swagger.io/)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="23" sourceendlinenumber="23">Swagger</a> with the .NET Core implementation <a href="https://github.com/domaindrivendev/Swashbuckle.AspNetCore" data-raw-source="[Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="23" sourceendlinenumber="23">Swashbuckle.AspNetCore</a>, is as easy as adding a couple of NuGet packages and modifying the <em>Startup.cs</em>.</p>
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="25" sourceendlinenumber="27">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="25" sourceendlinenumber="25"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="25" sourceendlinenumber="25"><a href="https://github.com/domaindrivendev/Swashbuckle.AspNetCore" data-raw-source="[Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="25" sourceendlinenumber="25">Swashbuckle.AspNetCore</a> is an open source project for generating Swagger documents for ASP.NET Core Web APIs.</p>
</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="27" sourceendlinenumber="27"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="27" sourceendlinenumber="27"><a href="https://swagger.io/" data-raw-source="[Swagger](https://swagger.io/)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="27" sourceendlinenumber="27">Swagger</a> is a machine-readable representation of a RESTful API that enables support for interactive documentation, client SDK generation, and discoverability.</p>
</li>
</ul>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="29" sourceendlinenumber="29">This tutorial builds on the sample on <a class="xref" href="first-web-api.html" data-raw-source="[Building Your First Web API with ASP.NET Core MVC and Visual Studio](xref:tutorials/first-web-api)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="29" sourceendlinenumber="29">Building Your First Web API with ASP.NET Core MVC and Visual Studio</a>. If you&#39;d like to follow along, download the sample at <a href="https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample" data-raw-source="[https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="29" sourceendlinenumber="29">https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample</a>.</p>
<h2 id="getting-started" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="31" sourceendlinenumber="31">Getting Started</h2>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="33" sourceendlinenumber="33">There are three main components to Swashbuckle:</p>
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="35" sourceendlinenumber="39">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="35" sourceendlinenumber="35"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="35" sourceendlinenumber="35"><code>Swashbuckle.AspNetCore.Swagger</code>: a Swagger object model and middleware to expose <code>SwaggerDocument</code> objects as JSON endpoints.</p>
</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="37" sourceendlinenumber="37"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="37" sourceendlinenumber="37"><code>Swashbuckle.AspNetCore.SwaggerGen</code>: a Swagger generator that builds <code>SwaggerDocument</code> objects directly from your routes, controllers, and models. It&#39;s typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.</p>
</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="39" sourceendlinenumber="39"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="39" sourceendlinenumber="39"><code>Swashbuckle.AspNetCore.SwaggerUI</code>: an embedded version of the Swagger UI tool which interprets Swagger JSON to build a rich, customizable experience for describing the Web API functionality. It includes built-in test harnesses for the public methods.</p>
</li>
</ul>
<h2 id="nuget-packages" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="41" sourceendlinenumber="41">NuGet Packages</h2>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="43" sourceendlinenumber="43">Swashbuckle can be added with the following approaches:</p>
<div class="tabGroup" id="tabgroup_9fKY8SstIr" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="45" sourceendlinenumber="79">
<ul role="tablist">
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr_visual-studio" role="tab" aria-controls="tabpanel_9fKY8SstIr_visual-studio" data-tab="visual-studio" tabindex="0" aria-selected="true" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="45" sourceendlinenumber="45">Visual Studio</a>
</li>
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr_visual-studio-mac" role="tab" aria-controls="tabpanel_9fKY8SstIr_visual-studio-mac" data-tab="visual-studio-mac" tabindex="-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="60" sourceendlinenumber="60">Visual Studio for Mac</a>
</li>
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr_visual-studio-code" role="tab" aria-controls="tabpanel_9fKY8SstIr_visual-studio-code" data-tab="visual-studio-code" tabindex="-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="67" sourceendlinenumber="67">Visual Studio Code</a>
</li>
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr_netcore-cli" role="tab" aria-controls="tabpanel_9fKY8SstIr_netcore-cli" data-tab="netcore-cli" tabindex="-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="75" sourceendlinenumber="75">.NET Core CLI</a>
</li>
</ul>
<section id="tabpanel_9fKY8SstIr_visual-studio" role="tabpanel" data-tab="visual-studio">
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="47" sourceendlinenumber="58">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="47" sourceendlinenumber="51"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="47" sourceendlinenumber="47">From the <strong>Package Manager Console</strong> window:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="49" sourceendlinenumber="51"><code class="lang-powershell">Install-Package Swashbuckle.AspNetCore
</code></pre></li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="53" sourceendlinenumber="58"><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="53" sourceendlinenumber="53">From the <strong>Manage NuGet Packages</strong> dialog:</p>
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="55" sourceendlinenumber="58">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="55" sourceendlinenumber="55">Right-click your project in <strong>Solution Explorer</strong> &gt; <strong>Manage NuGet Packages</strong></li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="56" sourceendlinenumber="56">Set the <strong>Package source</strong> to &quot;nuget.org&quot;</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="57" sourceendlinenumber="57">Enter &quot;Swashbuckle.AspNetCore&quot; in the search box</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="58" sourceendlinenumber="58">Select the &quot;Swashbuckle.AspNetCore&quot; package from the <strong>Browse</strong> tab and click <strong>Install</strong></li>
</ul>
</li>
</ul>
</section>
<section id="tabpanel_9fKY8SstIr_visual-studio-mac" role="tabpanel" data-tab="visual-studio-mac" aria-hidden="true" hidden="hidden">
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="62" sourceendlinenumber="65">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="62" sourceendlinenumber="62">Right-click the <em>Packages</em> folder in <strong>Solution Pad</strong> &gt; <strong>Add Packages...</strong></li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="63" sourceendlinenumber="63">Set the <strong>Add Packages</strong> window&#39;s <strong>Source</strong> drop-down to &quot;nuget.org&quot;</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="64" sourceendlinenumber="64">Enter Swashbuckle.AspNetCore in the search box</li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="65" sourceendlinenumber="65">Select the Swashbuckle.AspNetCore package from the results pane and click <strong>Add Package</strong></li>
</ul>
</section>
<section id="tabpanel_9fKY8SstIr_visual-studio-code" role="tabpanel" data-tab="visual-studio-code" aria-hidden="true" hidden="hidden">
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="69" sourceendlinenumber="69">Run the following command from the <strong>Integrated Terminal</strong>:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="71" sourceendlinenumber="73"><code class="lang-console">dotnet add TodoApi.csproj package Swashbuckle.AspNetCore
</code></pre></section>
<section id="tabpanel_9fKY8SstIr_netcore-cli" role="tabpanel" data-tab="netcore-cli" aria-hidden="true" hidden="hidden">
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="77" sourceendlinenumber="77">Run the following command:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="79" sourceendlinenumber="81"><code class="lang-console">dotnet add TodoApi.csproj package Swashbuckle.AspNetCore
</code></pre></section>
</div>
<h2 id="add-and-configure-swagger-to-the-middleware" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="85" sourceendlinenumber="85">Add and configure Swagger to the middleware</h2>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="87" sourceendlinenumber="87">Add the Swagger generator to the services collection in the <code>ConfigureServices</code> method of <em>Startup.cs</em>:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="89" sourceendlinenumber="89"><code class="lang-csharp" name="Main" highlight-lines="7-10">public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext&lt;TodoContext&gt;(opt =&gt; opt.UseInMemoryDatabase(&quot;TodoList&quot;));
    services.AddMvc();

    // Register the Swagger generator, defining one or more Swagger documents
    services.AddSwaggerGen(c =&gt;
    {
        c.SwaggerDoc(&quot;v1&quot;, new Info { Title = &quot;My API&quot;, Version = &quot;v1&quot; });
    });
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="91" sourceendlinenumber="91">Add the following using statement for the <code>Info</code> class:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="93" sourceendlinenumber="95"><code class="lang-csharp">using Swashbuckle.AspNetCore.Swagger;
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="97" sourceendlinenumber="97">In the <code>Configure</code> method of <em>Startup.cs</em>, enable the middleware for serving the generated JSON document and the SwaggerUI:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="99" sourceendlinenumber="99"><code class="lang-csharp" name="Main" highlight-lines="4,7-10">public void Configure(IApplicationBuilder app)
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =&gt;
    {
        c.SwaggerEndpoint(&quot;/swagger/v1/swagger.json&quot;, &quot;My API V1&quot;);
    });

    app.UseMvc();
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="101" sourceendlinenumber="101">Launch the app, and navigate to <code>http://localhost:&lt;random_port&gt;/swagger/v1/swagger.json</code>. The generated document describing the endpoints appears.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="103" sourceendlinenumber="103"><strong>Note:</strong> Microsoft Edge, Google Chrome, and Firefox display JSON documents natively. There are extensions for Chrome that format the document for easier reading. <em>The following example is reduced for brevity.</em></p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="105" sourceendlinenumber="172"><code class="lang-json">{
   &quot;swagger&quot;: &quot;2.0&quot;,
   &quot;info&quot;: {
       &quot;version&quot;: &quot;v1&quot;,
       &quot;title&quot;: &quot;API V1&quot;
   },
   &quot;basePath&quot;: &quot;/&quot;,
   &quot;paths&quot;: {
       &quot;/api/Todo&quot;: {
           &quot;get&quot;: {
               &quot;tags&quot;: [
                   &quot;Todo&quot;
               ],
               &quot;operationId&quot;: &quot;ApiTodoGet&quot;,
               &quot;consumes&quot;: [],
               &quot;produces&quot;: [
                   &quot;text/plain&quot;,
                   &quot;application/json&quot;,
                   &quot;text/json&quot;
               ],
               &quot;responses&quot;: {
                   &quot;200&quot;: {
                       &quot;description&quot;: &quot;Success&quot;,
                       &quot;schema&quot;: {
                           &quot;type&quot;: &quot;array&quot;,
                           &quot;items&quot;: {
                               &quot;$ref&quot;: &quot;#/definitions/TodoItem&quot;
                           }
                       }
                   }
                }
           },
           &quot;post&quot;: {
               ...
           }
       },
       &quot;/api/Todo/{id}&quot;: {
           &quot;get&quot;: {
               ...
           },
           &quot;put&quot;: {
               ...
           },
           &quot;delete&quot;: {
               ...
   },
   &quot;definitions&quot;: {
       &quot;TodoItem&quot;: {
           &quot;type&quot;: &quot;object&quot;,
            &quot;properties&quot;: {
                &quot;id&quot;: {
                    &quot;format&quot;: &quot;int64&quot;,
                    &quot;type&quot;: &quot;integer&quot;
                },
                &quot;name&quot;: {
                    &quot;type&quot;: &quot;string&quot;
                },
                &quot;isComplete&quot;: {
                    &quot;default&quot;: false,
                    &quot;type&quot;: &quot;boolean&quot;
                }
            }
       }
   },
   &quot;securityDefinitions&quot;: {}
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="174" sourceendlinenumber="174">This document drives the Swagger UI, which can be viewed by navigating to <code>http://localhost:&lt;random_port&gt;/swagger</code>:</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="176" sourceendlinenumber="176"><img src="web-api-help-pages-using-swagger/_static/swagger-ui.png" alt="Swagger UI" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="176" sourceendlinenumber="176"></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="178" sourceendlinenumber="178">Each public action method in <code>TodoController</code> can be tested from the UI. Click a method name to expand the section. Add any necessary parameters, and click &quot;Try it out!&quot;.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="180" sourceendlinenumber="180"><img src="web-api-help-pages-using-swagger/_static/get-try-it-out.png" alt="Example Swagger GET test" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="180" sourceendlinenumber="180"></p>
<h2 id="customization--extensibility" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="182" sourceendlinenumber="182">Customization &amp; Extensibility</h2>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="184" sourceendlinenumber="184">Swagger provides options for documenting the object model and customizing the UI to match your theme.</p>
<h3 id="api-info-and-description" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="186" sourceendlinenumber="186">API Info and Description</h3>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="188" sourceendlinenumber="188">The configuration action passed to the <code>AddSwaggerGen</code> method can be used to add information such as the author, license, and description:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="190" sourceendlinenumber="190"><code class="lang-csharp" name="Main">services.AddSwaggerGen(c =&gt;
{
    c.SwaggerDoc(&quot;v1&quot;, new Info
    {
        Version = &quot;v1&quot;,
        Title = &quot;ToDo API&quot;,
        Description = &quot;A simple example ASP.NET Core Web API&quot;,
        TermsOfService = &quot;None&quot;,
        Contact = new Contact { Name = &quot;Shayne Boyer&quot;, Email = &quot;&quot;, Url = &quot;https://twitter.com/spboyer&quot; },
        License = new License { Name = &quot;Use under LICX&quot;, Url = &quot;https://example.com/license&quot; }
    });
});
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="192" sourceendlinenumber="192">The following image depicts the Swagger UI displaying the version information:</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="194" sourceendlinenumber="194"><img src="web-api-help-pages-using-swagger/_static/custom-info.png" alt="Swagger UI with version information: description, author, and see more link" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="194" sourceendlinenumber="194"></p>
<h3 id="xml-comments" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="196" sourceendlinenumber="196">XML Comments</h3>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="198" sourceendlinenumber="198">XML comments can be enabled with the following approaches:</p>
<div class="tabGroup" id="tabgroup_9fKY8SstIr-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="200" sourceendlinenumber="217">
<ul role="tablist">
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr-1_visual-studio" role="tab" aria-controls="tabpanel_9fKY8SstIr-1_visual-studio" data-tab="visual-studio" tabindex="0" aria-selected="true" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="200" sourceendlinenumber="200">Visual Studio</a>
</li>
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr-1_visual-studio-mac" role="tab" aria-controls="tabpanel_9fKY8SstIr-1_visual-studio-mac" data-tab="visual-studio-mac" tabindex="-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="207" sourceendlinenumber="207">Visual Studio for Mac</a>
</li>
<li role="presentation">
<a href="#tabpanel_9fKY8SstIr-1_visual-studio-code" role="tab" aria-controls="tabpanel_9fKY8SstIr-1_visual-studio-code" data-tab="visual-studio-code" tabindex="-1" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="214" sourceendlinenumber="214">Visual Studio Code</a>
</li>
</ul>
<section id="tabpanel_9fKY8SstIr-1_visual-studio" role="tabpanel" data-tab="visual-studio">
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="202" sourceendlinenumber="203">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="202" sourceendlinenumber="202">Right-click the project in <strong>Solution Explorer</strong> and select <strong>Properties</strong></li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="203" sourceendlinenumber="203">Check the <strong>XML documentation file</strong> box under the <strong>Output</strong> section of the <strong>Build</strong> tab:</li>
</ul>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="205" sourceendlinenumber="205"><img src="web-api-help-pages-using-swagger/_static/swagger-xml-comments.png" alt="Build tab of project properties" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="205" sourceendlinenumber="205"></p>
</section>
<section id="tabpanel_9fKY8SstIr-1_visual-studio-mac" role="tabpanel" data-tab="visual-studio-mac" aria-hidden="true" hidden="hidden">
<ul sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="209" sourceendlinenumber="210">
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="209" sourceendlinenumber="209">Open the <strong>Project Options</strong> dialog &gt; <strong>Build</strong> &gt; <strong>Compiler</strong></li>
<li sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="210" sourceendlinenumber="210">Check the <strong>Generate xml documentation</strong> box under the <strong>General Options</strong> section:</li>
</ul>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="212" sourceendlinenumber="212"><img src="web-api-help-pages-using-swagger/_static/swagger-xml-comments-mac.png" alt="General Options section of project options" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="212" sourceendlinenumber="212"></p>
</section>
<section id="tabpanel_9fKY8SstIr-1_visual-studio-code" role="tabpanel" data-tab="visual-studio-code" aria-hidden="true" hidden="hidden">
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="216" sourceendlinenumber="216">Manually add the following snippet to the <em>.csproj</em> file:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="218" sourceendlinenumber="218"><code class="lang-xml" name="Main">&lt;PropertyGroup Condition=&quot;&#39;$(Configuration)|$(Platform)&#39;==&#39;Debug|AnyCPU&#39;&quot;&gt;
  &lt;DocumentationFile&gt;bin\Debug\netcoreapp2.0\TodoApi.xml&lt;/DocumentationFile&gt;
&lt;/PropertyGroup&gt;
</code></pre></section>
</div>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="222" sourceendlinenumber="222">Configure Swagger to use the generated XML file. For Linux or non-Windows operating systems, file names and paths can be case sensitive. For example, a <em>ToDoApi.XML</em> file would be found on Windows but not CentOS.</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="224" sourceendlinenumber="224"><code class="lang-csharp" name="Main" highlight-lines="20-22">public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext&lt;TodoContext&gt;(opt =&gt; opt.UseInMemoryDatabase(&quot;TodoList&quot;));
    services.AddMvc();

    // Register the Swagger generator, defining one or more Swagger documents
    services.AddSwaggerGen(c =&gt;
    {
        c.SwaggerDoc(&quot;v1&quot;, new Info
        {
            Version = &quot;v1&quot;,
            Title = &quot;ToDo API&quot;,
            Description = &quot;A simple example ASP.NET Core Web API&quot;,
            TermsOfService = &quot;None&quot;,
            Contact = new Contact { Name = &quot;Shayne Boyer&quot;, Email = &quot;&quot;, Url = &quot;https://twitter.com/spboyer&quot; },
            License = new License { Name = &quot;Use under LICX&quot;, Url = &quot;https://example.com/license&quot; }
        });

        // Set the comments path for the Swagger JSON and UI.
        var basePath = PlatformServices.Default.Application.ApplicationBasePath;
        var xmlPath = Path.Combine(basePath, &quot;TodoApi.xml&quot;); 
        c.IncludeXmlComments(xmlPath);                
    });
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="226" sourceendlinenumber="226">In the preceding code, <code>ApplicationBasePath</code> gets the base path of the app. The base path is used to locate the XML comments file. <em>TodoApi.xml</em> only works for this example, since the name of the generated XML comments file is based on the application name.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="228" sourceendlinenumber="228">Adding the triple-slash comments to the method enhances the Swagger UI by adding the description to the section header:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="230" sourceendlinenumber="230"><code class="lang-csharp" name="Main" highlight-lines="2">/// &lt;summary&gt;
/// Deletes a specific TodoItem.
/// &lt;/summary&gt;
/// &lt;param name=&quot;id&quot;&gt;&lt;/param&gt;        
[HttpDelete(&quot;{id}&quot;)]
public IActionResult Delete(long id)
{
    var todo = _context.TodoItems.FirstOrDefault(t =&gt; t.Id == id);
    if (todo == null)
    {
        return NotFound();
    }

    _context.TodoItems.Remove(todo);
    _context.SaveChanges();
    return new NoContentResult();
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="232" sourceendlinenumber="232"><img src="web-api-help-pages-using-swagger/_static/triple-slash-comments.png" alt="Swagger UI showing XML comment &#39;Deletes a specific TodoItem.&#39; for the DELETE method" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="232" sourceendlinenumber="232"></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="234" sourceendlinenumber="234">The UI is driven by the generated JSON file, which also contains these comments:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="236" sourceendlinenumber="261"><code class="lang-json">&quot;delete&quot;: {
    &quot;tags&quot;: [
        &quot;Todo&quot;
    ],
    &quot;summary&quot;: &quot;Deletes a specific TodoItem.&quot;,
    &quot;operationId&quot;: &quot;ApiTodoByIdDelete&quot;,
    &quot;consumes&quot;: [],
    &quot;produces&quot;: [],
    &quot;parameters&quot;: [
        {
            &quot;name&quot;: &quot;id&quot;,
            &quot;in&quot;: &quot;path&quot;,
            &quot;description&quot;: &quot;&quot;,
            &quot;required&quot;: true,
            &quot;type&quot;: &quot;integer&quot;,
            &quot;format&quot;: &quot;int64&quot;
        }
    ],
    &quot;responses&quot;: {
        &quot;200&quot;: {
            &quot;description&quot;: &quot;Success&quot;
        }
    }
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="263" sourceendlinenumber="263">Add a <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/xmldoc/remarks" data-raw-source="[&lt;remarks&gt;](https://docs.microsoft.com/dotnet/csharp/programming-guide/xmldoc/remarks)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="263" sourceendlinenumber="263"><remarks></remarks></a> tag to the <code>Create</code> action method documentation. It supplements information specified in the <code>&lt;summary&gt;</code> tag and provides a more robust Swagger UI. The <code>&lt;remarks&gt;</code> tag content can consist of text, JSON, or XML.</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="265" sourceendlinenumber="265"><code class="lang-csharp" name="Main" highlight-lines="4-14">/// &lt;summary&gt;
/// Creates a TodoItem.
/// &lt;/summary&gt;
/// &lt;remarks&gt;
/// Sample request:
///
///     POST /Todo
///     {
///        &quot;id&quot;: 1,
///        &quot;name&quot;: &quot;Item1&quot;,
///        &quot;isComplete&quot;: true
///     }
///
/// &lt;/remarks&gt;
/// &lt;param name=&quot;item&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;A newly-created TodoItem&lt;/returns&gt;
/// &lt;response code=&quot;201&quot;&gt;Returns the newly-created item&lt;/response&gt;
/// &lt;response code=&quot;400&quot;&gt;If the item is null&lt;/response&gt;            
[HttpPost]
[ProducesResponseType(typeof(TodoItem), 201)]
[ProducesResponseType(typeof(TodoItem), 400)]
public IActionResult Create([FromBody] TodoItem item)
{
    if (item == null)
    {
        return BadRequest();
    }

    _context.TodoItems.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute(&quot;GetTodo&quot;, new { id = item.Id }, item);
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="267" sourceendlinenumber="267">Notice the UI enhancements with these additional comments.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="269" sourceendlinenumber="269"><img src="web-api-help-pages-using-swagger/_static/xml-comments-extended.png" alt="Swagger UI with additional comments shown" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="269" sourceendlinenumber="269"></p>
<h3 id="data-annotations" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="271" sourceendlinenumber="271">Data Annotations</h3>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="273" sourceendlinenumber="273">Decorate the model with attributes, found in <code>System.ComponentModel.DataAnnotations</code>, to help drive the Swagger UI components.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="275" sourceendlinenumber="275">Add the <code>[Required]</code> attribute to the <code>Name</code> property of the <code>TodoItem</code> class:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="277" sourceendlinenumber="277"><code class="lang-csharp" name="Main" highlight-lines="10">using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="279" sourceendlinenumber="279">The presence of this attribute changes the UI behavior and alters the underlying JSON schema:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="281" sourceendlinenumber="303"><code class="lang-json">&quot;definitions&quot;: {
    &quot;TodoItem&quot;: {
        &quot;required&quot;: [
            &quot;name&quot;
        ],
        &quot;type&quot;: &quot;object&quot;,
        &quot;properties&quot;: {
            &quot;id&quot;: {
                &quot;format&quot;: &quot;int64&quot;,
                &quot;type&quot;: &quot;integer&quot;
            },
            &quot;name&quot;: {
                &quot;type&quot;: &quot;string&quot;
            },
            &quot;isComplete&quot;: {
                &quot;default&quot;: false,
                &quot;type&quot;: &quot;boolean&quot;
            }
        }
    }
},
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="305" sourceendlinenumber="305">Add the <code>[Produces(&quot;application/json&quot;)]</code> attribute to the API controller. Its purpose is to declare that the controller&#39;s actions support a return a content type of <em>application/json</em>:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="307" sourceendlinenumber="307"><code class="lang-csharp" name="Main" highlight-lines="3">namespace TodoApi.Controllers
{
    [Produces(&quot;application/json&quot;)]
    [Route(&quot;api/[controller]&quot;)]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="309" sourceendlinenumber="309">The <strong>Response Content Type</strong> drop-down selects this content type as the default for the controller&#39;s GET actions:</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="311" sourceendlinenumber="311"><img src="web-api-help-pages-using-swagger/_static/json-response-content-type.png" alt="Swagger UI with default response content type" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="311" sourceendlinenumber="311"></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="313" sourceendlinenumber="313">As the usage of data annotations in the Web API increases, the UI and API help pages become more descriptive and useful.</p>
<h3 id="describing-response-types" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="315" sourceendlinenumber="315">Describing Response Types</h3>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="317" sourceendlinenumber="317">Consuming developers are most concerned with what is returned &mdash; specifically response types and error codes (if not standard). These are handled in the XML comments and data annotations.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="319" sourceendlinenumber="319">The <code>Create</code> action returns <code>201 Created</code> on success or <code>400 Bad Request</code> when the posted request body is null. Without proper documentation in the Swagger UI, the consumer lacks knowledge of these expected outcomes. That problem is fixed by adding the highlighted lines in the following example:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="321" sourceendlinenumber="321"><code class="lang-csharp" name="Main" highlight-lines="17,18,20,21">/// &lt;summary&gt;
/// Creates a TodoItem.
/// &lt;/summary&gt;
/// &lt;remarks&gt;
/// Sample request:
///
///     POST /Todo
///     {
///        &quot;id&quot;: 1,
///        &quot;name&quot;: &quot;Item1&quot;,
///        &quot;isComplete&quot;: true
///     }
///
/// &lt;/remarks&gt;
/// &lt;param name=&quot;item&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;A newly-created TodoItem&lt;/returns&gt;
/// &lt;response code=&quot;201&quot;&gt;Returns the newly-created item&lt;/response&gt;
/// &lt;response code=&quot;400&quot;&gt;If the item is null&lt;/response&gt;            
[HttpPost]
[ProducesResponseType(typeof(TodoItem), 201)]
[ProducesResponseType(typeof(TodoItem), 400)]
public IActionResult Create([FromBody] TodoItem item)
{
    if (item == null)
    {
        return BadRequest();
    }

    _context.TodoItems.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute(&quot;GetTodo&quot;, new { id = item.Id }, item);
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="323" sourceendlinenumber="323">The Swagger UI now clearly documents the expected HTTP response codes:</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="325" sourceendlinenumber="325"><img src="web-api-help-pages-using-swagger/_static/data-annotations-response-types.png" alt="Swagger UI showing POST Response Class description &#39;Returns the newly created Todo item&#39; and &#39;400 - If the item is null&#39; for status code and reason under Response Messages" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="325" sourceendlinenumber="325"></p>
<h3 id="customizing-the-ui" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="327" sourceendlinenumber="327">Customizing the UI</h3>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="329" sourceendlinenumber="329">The stock UI is both functional and presentable; however, when building documentation pages for your API, you want it to represent your brand or theme. Accomplishing that task with the Swashbuckle components requires adding the resources to serve static files and then building the folder structure to host those files.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="331" sourceendlinenumber="331">If targeting .NET Framework, add the <code>Microsoft.AspNetCore.StaticFiles</code> NuGet package to the project:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="333" sourceendlinenumber="335"><code class="lang-xml">&lt;PackageReference Include=&quot;Microsoft.AspNetCore.StaticFiles&quot; Version=&quot;2.0.0&quot; /&gt;
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="337" sourceendlinenumber="337">Enable the static files middleware:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="339" sourceendlinenumber="339"><code class="lang-csharp" name="Main" highlight-lines="3">public void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =&gt;
    {
        c.SwaggerEndpoint(&quot;/swagger/v1/swagger.json&quot;, &quot;My API V1&quot;);
    });

    app.UseMvc();
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="341" sourceendlinenumber="341">Acquire the contents of the <em>dist</em> folder from the <a href="https://github.com/swagger-api/swagger-ui/tree/2.x/dist" data-raw-source="[Swagger UI GitHub repository](https://github.com/swagger-api/swagger-ui/tree/2.x/dist)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="341" sourceendlinenumber="341">Swagger UI GitHub repository</a>. This folder contains the necessary assets for the Swagger UI page.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="343" sourceendlinenumber="343">Create a <em>wwwroot/swagger/ui</em> folder, and copy into it the contents of the <em>dist</em> folder.</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="345" sourceendlinenumber="345">Create a <em>wwwroot/swagger/ui/css/custom.css</em> file with the following CSS to customize the page header:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="347" sourceendlinenumber="347"><code class="lang-css" name="Main">.swagger-section #header
{
    border-bottom: 1px solid #000000;
    font-style: normal;
    font-weight: 400;
    font-family: &quot;Segoe UI Light&quot;,&quot;Segoe WP Light&quot;,&quot;Segoe UI&quot;,&quot;Segoe WP&quot;,Tahoma,Arial,sans-serif;
    background-color: black;
}

.swagger-section #header h1
{
    text-align: center;
    font-size: 20px;
    color: white;
}
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="349" sourceendlinenumber="349">Reference <em>custom.css</em> in the <em>index.html</em> file:</p>
<pre sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="351" sourceendlinenumber="351"><code class="lang-html" name="Main">&lt;link href=&#39;css/custom.css&#39; media=&#39;screen&#39; rel=&#39;stylesheet&#39; type=&#39;text/css&#39; /&gt;
</code></pre><p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="353" sourceendlinenumber="353">Browse to the <em>index.html</em> page at <code>http://localhost:&lt;random_port&gt;/swagger/ui/index.html</code>. Enter <code>http://localhost:&lt;random_port&gt;/swagger/v1/swagger.json</code> in the header&#39;s textbox, and click the <strong>Explore</strong> button. The resulting page looks as follows:</p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="355" sourceendlinenumber="355"><img src="web-api-help-pages-using-swagger/_static/custom-header.png" alt="Swagger UI with custom header title" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="355" sourceendlinenumber="355"></p>
<p sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="357" sourceendlinenumber="357">There is much more you can do with the page. See the full capabilities for the UI resources at the <a href="https://github.com/swagger-api/swagger-ui" data-raw-source="[Swagger UI GitHub repository](https://github.com/swagger-api/swagger-ui)" sourcefile="tutorials/web-api-help-pages-using-swagger.md" sourcestartlinenumber="357" sourceendlinenumber="357">Swagger UI GitHub repository</a>.</p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/aspnet/Docs/blob/w/riande/RP-EF/aspnetcore/tutorials/web-api-help-pages-using-swagger.md/#L1" class="contribution-link">Improve this Doc</a>
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
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>
