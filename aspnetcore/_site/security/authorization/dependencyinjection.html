<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Dependency Injection in requirement handlers </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Dependency Injection in requirement handlers ">
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
            <article class="content wrap" id="_content" data-uid="security/authorization/dependencyinjection">
<h1 id="dependency-injection-in-requirement-handlers">Dependency Injection in requirement handlers</h1>

<p><a name="security-authorization-di"></a></p>
<p><a href="policies.html#security-authorization-policies-based-handler-registration">Authorization handlers must be registered</a> in the service collection during configuration (using <a href="../../fundamentals/dependency-injection.html#fundamentals-dependency-injection">dependency injection</a>).</p>
<p>Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection.  Authorization will resolve and inject that into your constructor.</p>
<p>For example, if you wanted to use ASP.NET&#39;s logging infrastructure you would want to inject <code>ILoggerFactory</code> into your handler. Such a handler might look like:</p>
<pre><code class="lang-csharp">public class LoggingAuthorizationHandler : AuthorizationHandler&lt;MyRequirement&gt;
   {
       ILogger _logger;

       public LoggingAuthorizationHandler(ILoggerFactory loggerFactory)
       {
           _logger = loggerFactory.CreateLogger(this.GetType().FullName);
       }

       protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
       {
           _logger.LogInformation(&quot;Inside my handler&quot;);
           // Check if the requirement is fulfilled.
           return Task.CompletedTask;
       }
   }
</code></pre><p>You would register the handler with <code>services.AddSingleton()</code>:</p>
<pre><code class="lang-csharp">services.AddSingleton&lt;IAuthorizationHandler, LoggingAuthorizationHandler&gt;();
</code></pre><p>An instance of the handler will be created when your application starts, and DI will inject the registered <code>ILoggerFactory</code> into your constructor.</p>
<div class="NOTE"><h5>Note</h5><p>Handlers that use Entity Framework shouldn&#39;t be registered as singletons.</p>
</div>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/aspnet/Docs/blob/w/riande/RP-EF/aspnetcore/security/authorization/dependencyinjection.md/#L1" class="contribution-link">Improve this Doc</a>
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
