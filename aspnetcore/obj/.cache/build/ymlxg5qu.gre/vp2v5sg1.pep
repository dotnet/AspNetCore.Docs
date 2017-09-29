<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core ">
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
            <article class="content wrap" id="_content" data-uid="security/anti-request-forgery">
<h1 id="preventing-cross-site-request-forgery-xsrfcsrf-attacks-in-aspnet-core" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="14" sourceendlinenumber="14">Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core</h1>

<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="16" sourceendlinenumber="16"><a href="https://ardalis.com/" data-raw-source="[Steve Smith](https://ardalis.com/)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="16" sourceendlinenumber="16">Steve Smith</a>, <a href="https://twitter.com/FiyazBinHasan" data-raw-source="[Fiyaz Hasan](https://twitter.com/FiyazBinHasan)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="16" sourceendlinenumber="16">Fiyaz Hasan</a>, and <a href="https://twitter.com/RickAndMSFT" data-raw-source="[Rick Anderson](https://twitter.com/RickAndMSFT)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="16" sourceendlinenumber="16">Rick Anderson</a></p>
<h2 id="what-attack-does-anti-forgery-prevent" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="18" sourceendlinenumber="18">What attack does anti-forgery prevent?</h2>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="20" sourceendlinenumber="20">Cross-site request forgery (also known as XSRF or CSRF, pronounced <em>see-surf</em>) is an attack against web-hosted applications whereby a malicious web site can influence the interaction between a client browser and a web site that trusts that browser. These attacks are made possible because web browsers send some types of authentication tokens automatically with every request to a web site. This form of exploit is also known as a <em>one-click attack</em> or as <em>session riding</em>, because the attack takes advantage of the user&#39;s previously authenticated session.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="22" sourceendlinenumber="22">An example of a CSRF attack:</p>
<ol sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="24" sourceendlinenumber="28">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="24" sourceendlinenumber="24">A user logs into <code>www.example.com</code>, using forms authentication.</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="25" sourceendlinenumber="25">The server authenticates the user and issues a response that includes an authentication cookie.</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="26" sourceendlinenumber="28"><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="26" sourceendlinenumber="26">The user visits a malicious site.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="28" sourceendlinenumber="28">The malicious site contains an HTML form similar to the following:</p>
</li>
</ol>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="30" sourceendlinenumber="37"><code class="lang-html">   &lt;h1&gt;You Are a Winner!&lt;/h1&gt;
     &lt;form action=&quot;http://example.com/api/account&quot; method=&quot;post&quot;&gt;
       &lt;input type=&quot;hidden&quot; name=&quot;Transaction&quot; value=&quot;withdraw&quot; /&gt;
       &lt;input type=&quot;hidden&quot; name=&quot;Amount&quot; value=&quot;1000000&quot; /&gt;
     &lt;input type=&quot;submit&quot; value=&quot;Click Me&quot;/&gt;
   &lt;/form&gt;
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="39" sourceendlinenumber="39">Notice that the form action posts to the vulnerable site, not to the malicious site. This is the “cross-site” part of CSRF.</p>
<ol sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="41" sourceendlinenumber="42">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="41" sourceendlinenumber="41">The user clicks the submit button. The browser automatically includes the authentication cookie for the requested domain (the vulnerable site in this case) with the request.</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="42" sourceendlinenumber="42">The request runs on the server with the user’s authentication context and can do anything that an authenticated user is allowed to do.</li>
</ol>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="44" sourceendlinenumber="44">This example requires the user to click the form button. The malicious page could:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="46" sourceendlinenumber="48">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="46" sourceendlinenumber="46">Run a script that automatically submits the form.</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="47" sourceendlinenumber="47">Sends a form submission as an AJAX request. </li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="48" sourceendlinenumber="48">Use a hidden form with CSS. </li>
</ul>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="50" sourceendlinenumber="50">Using SSL does not prevent a CSRF attack, the malicious site can send an <code>https://</code> request. </p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="52" sourceendlinenumber="52">Some attacks  target site endpoints that respond to <code>GET</code> requests, in which case an image tag can be used to perform the action (this form of attack is common on forum sites that permit images but block JavaScript). Applications that change state with <code>GET</code> requests are  vulnerable from malicious attacks.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="54" sourceendlinenumber="54">CSRF attacks are possible against web sites that use cookies for authentication, because browsers send all relevant cookies to the destination web site. However, CSRF attacks are not limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user logs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="56" sourceendlinenumber="56">Note: In this context, <em>session</em> refers to the client-side session during which the user is authenticated. It is unrelated to server-side sessions or <a class="xref" href="../fundamentals/app-state.html" data-raw-source="[session middleware](xref:fundamentals/app-state)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="56" sourceendlinenumber="56">session middleware</a>.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="58" sourceendlinenumber="58">Users can guard against CSRF vulnerabilities by:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="59" sourceendlinenumber="60">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="59" sourceendlinenumber="59">Logging off of web sites when they have finished using them.</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="60" sourceendlinenumber="60">Clearing their browser&#39;s cookies periodically.</li>
</ul>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="62" sourceendlinenumber="62">However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.</p>
<h2 id="how-does-aspnet-core-mvc-address-csrf" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="64" sourceendlinenumber="64">How does ASP.NET Core MVC address CSRF?</h2>
<div class="WARNING" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="66" sourceendlinenumber="66"><h5>Warning</h5><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="67" sourceendlinenumber="67">ASP.NET Core implements anti-request-forgery using the <a class="xref" href="data-protection/introduction.html" data-raw-source="[ASP.NET Core data protection stack](xref:security/data-protection/introduction)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="67" sourceendlinenumber="67">ASP.NET Core data protection stack</a>. ASP.NET Core data protection must be configured to work in a server farm. See <a class="xref" href="data-protection/configuration/overview.html" data-raw-source="[Configuring data protection](xref:security/data-protection/configuration/overview)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="67" sourceendlinenumber="67">Configuring data protection</a> for more information.</p>
</div>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="69" sourceendlinenumber="69">ASP.NET Core anti-request-forgery  default data protection configuration </p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="71" sourceendlinenumber="71">In ASP.NET Core MVC 2.0 the <a class="xref" href="../mvc/views/working-with-forms.html#the-form-tag-helper" data-raw-source="[FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="71" sourceendlinenumber="71">FormTagHelper</a> injects anti-forgery tokens for HTML form elements. For example, the following markup in a Razor file will automatically generate anti-forgery tokens:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="73" sourceendlinenumber="77"><code class="lang-html">&lt;form method=&quot;post&quot;&gt;
  &lt;!-- form markup --&gt;
&lt;/form&gt;
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="79" sourceendlinenumber="79">The automatic generation of anti-forgery tokens for HTML form elements happens when:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="81" sourceendlinenumber="84">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="81" sourceendlinenumber="84"><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="81" sourceendlinenumber="81">The <code>form</code> tag contains the <code>method=&quot;post&quot;</code> attribute AND</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="83" sourceendlinenumber="84">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="83" sourceendlinenumber="83">The action attribute is empty. ( <code>action=&quot;&quot;</code>) OR</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="84" sourceendlinenumber="84">The action attribute is not supplied. (<code>&lt;form method=&quot;post&quot;&gt;</code>)</li>
</ul>
</li>
</ul>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="86" sourceendlinenumber="86">You can disable automatic generation of anti-forgery tokens for HTML form elements by:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="88" sourceendlinenumber="106">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="88" sourceendlinenumber="93"><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="88" sourceendlinenumber="88">Explicitly disabling <code>asp-antiforgery</code>. For example</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="90" sourceendlinenumber="93"><code class="lang-html">&lt;form method=&quot;post&quot; asp-antiforgery=&quot;false&quot;&gt;
&lt;/form&gt;
</code></pre></li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="95" sourceendlinenumber="100"><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="95" sourceendlinenumber="95">Opt the form element out of Tag Helpers by using the Tag Helper <a class="xref" href="../mvc/views/tag-helpers/intro.html#opt-out" data-raw-source="[! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="95" sourceendlinenumber="95">! opt-out symbol</a>.</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="97" sourceendlinenumber="100"><code class="lang-html">&lt;!form method=&quot;post&quot;&gt;
&lt;/!form&gt;
</code></pre></li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="102" sourceendlinenumber="106"><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="102" sourceendlinenumber="102">Remove the <code>FormTagHelper</code> from the view. You can remove the <code>FormTagHelper</code> from a view by adding the following directive to the Razor view:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="104" sourceendlinenumber="106"><code class="lang-html">@removeTagHelper Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper, Microsoft.AspNetCore.Mvc.TagHelpers
</code></pre></li>
</ul>
<div class="NOTE" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="108" sourceendlinenumber="108"><h5>Note</h5><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="109" sourceendlinenumber="109"><a class="xref" href="../mvc/razor-pages/index.html" data-raw-source="[Razor Pages](xref:mvc/razor-pages/index)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="109" sourceendlinenumber="109">Razor Pages</a> are automatically protected from XSRF/CSRF. You don&#39;t have to write any additional code. See <a class="xref" href="../mvc/razor-pages/index.html#xsrf" data-raw-source="[XSRF/CSRF and Razor Pages](xref:mvc/razor-pages/index#xsrf)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="109" sourceendlinenumber="109">XSRF/CSRF and Razor Pages</a> for more information.</p>
</div>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="111" sourceendlinenumber="111">The most common approach to defending against CSRF attacks is the synchronizer token pattern (STP). STP is a technique used when the user requests a page with form data. The server sends a token associated with the current user&#39;s identity to the client. The client sends back the token to the server for verification. If the server receives a token that doesn&#39;t match the authenticated user&#39;s identity, the request is rejected. The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (ensuring page 1 precedes page 2 which precedes page 3). All the forms in ASP.NET Core MVC templates generate antiforgery tokens. The following two examples of view logic generate antiforgery tokens:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="113" sourceendlinenumber="122"><code class="lang-html">&lt;form asp-controller=&quot;Manage&quot; asp-action=&quot;ChangePassword&quot; method=&quot;post&quot;&gt;

&lt;/form&gt;

@using (Html.BeginForm(&quot;ChangePassword&quot;, &quot;Manage&quot;))
{

}
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="124" sourceendlinenumber="124">You can explicitly add an antiforgery token to a <code>&lt;form&gt;</code> element without using tag helpers with the HTML helper <code>@Html.AntiForgeryToken</code>:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="127" sourceendlinenumber="131"><code class="lang-html">&lt;form action=&quot;/&quot; method=&quot;post&quot;&gt;
    @Html.AntiForgeryToken()
&lt;/form&gt;
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="133" sourceendlinenumber="133">In each of the preceding cases, ASP.NET Core will add a hidden form field similar to the following:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="134" sourceendlinenumber="136"><code class="lang-html">&lt;input name=&quot;__RequestVerificationToken&quot; type=&quot;hidden&quot; value=&quot;CfDJ8NrAkSldwD9CpLRyOtm6FiJB1Jr_F3FQJQDvhlHoLNJJrLA6zaMUmhjMsisu2D2tFkAiYgyWQawJk9vNm36sYP1esHOtamBEPvSk1_x--Sg8Ey2a-d9CV2zHVWIN9MVhvKHOSyKqdZFlYDVd69XYx-rOWPw3ilHGLN6K0Km-1p83jZzF0E4WU5OGg5ns2-m9Yw&quot; /&gt;
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="138" sourceendlinenumber="138">ASP.NET Core includes three <a class="xref" href="../mvc/controllers/filters.html" data-raw-source="[filters](xref:mvc/controllers/filters)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="138" sourceendlinenumber="138">filters</a> for working with antiforgery tokens: <code>ValidateAntiForgeryToken</code>, <code>AutoValidateAntiforgeryToken</code>, and <code>IgnoreAntiforgeryToken</code>.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="140" sourceendlinenumber="140"><a name="vaft"></a></p>
<h3 id="validateantiforgerytoken" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="142" sourceendlinenumber="142">ValidateAntiForgeryToken</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="144" sourceendlinenumber="144">The <code>ValidateAntiForgeryToken</code> is an action filter that can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied will be blocked unless the request includes a valid antiforgery token.</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="146" sourceendlinenumber="164"><code class="lang-c#">[HttpPost]
[ValidateAntiForgeryToken]
public async Task&lt;IActionResult&gt; RemoveLogin(RemoveLoginViewModel account)
{
    ManageMessageId? message = ManageMessageId.Error;
    var user = await GetCurrentUserAsync();
    if (user != null)
    {
        var result = await _userManager.RemoveLoginAsync(user, account.LoginProvider, account.ProviderKey);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            message = ManageMessageId.RemoveLoginSuccess;
        }
    }
    return RedirectToAction(nameof(ManageLogins), new { Message = message });
}
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="166" sourceendlinenumber="166">The <code>ValidateAntiForgeryToken</code> attribute requires a token for requests to action methods it decorates, including <code>HTTP GET</code> requests. If you apply it broadly, you can override it with the <code>IgnoreAntiforgeryToken</code> attribute.</p>
<h3 id="autovalidateantiforgerytoken" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="168" sourceendlinenumber="168">AutoValidateAntiforgeryToken</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="170" sourceendlinenumber="170">ASP.NET Core apps generally do not generate antiforgery tokens for HTTP safe methods (GET, HEAD, OPTIONS, and TRACE). Instead of broadly applying the <code>ValidateAntiForgeryToken</code> attribute and then overriding it with <code>IgnoreAntiforgeryToken</code> attributes, you can use the <code>AutoValidateAntiforgeryToken</code> attribute. This attribute works identically to the <code>ValidateAntiForgeryToken</code> attribute, except that it doesn&#39;t require tokens for requests made using the following HTTP methods:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="172" sourceendlinenumber="175">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="172" sourceendlinenumber="172">GET</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="173" sourceendlinenumber="173">HEAD</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="174" sourceendlinenumber="174">OPTIONS</li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="175" sourceendlinenumber="175">TRACE</li>
</ul>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="177" sourceendlinenumber="177">We recommend you use <code>AutoValidateAntiforgeryToken</code> broadly for non-API scenarios. This ensures your POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless <code>ValidateAntiForgeryToken</code> is applied to the individual action method. It&#39;s more likely in this scenario for a POST action method to be left unprotected, leaving your app vulnerable to CSRF attacks. Even anonymous POSTS should send the antiforgery token.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="179" sourceendlinenumber="179">Note: APIs don&#39;t have an automatic mechanism for sending the non-cookie part of the token; your implementation will likely depend on your client code implementation. Some examples are shown below.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="182" sourceendlinenumber="182">Example (class level):</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="184" sourceendlinenumber="189"><code class="lang-c#">[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="191" sourceendlinenumber="191">Example (global):</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="193" sourceendlinenumber="196"><code class="lang-c#">services.AddMvc(options =&gt; 
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="198" sourceendlinenumber="198"><a name="iaft"></a></p>
<h3 id="ignoreantiforgerytoken" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="200" sourceendlinenumber="200">IgnoreAntiforgeryToken</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="202" sourceendlinenumber="202">The <code>IgnoreAntiforgeryToken</code> filter is used to eliminate the need for an antiforgery token to be present for a given action (or controller). When applied, this filter will override <code>ValidateAntiForgeryToken</code> and/or <code>AutoValidateAntiforgeryToken</code> filters specified at a higher level (globally or on a controller).</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="204" sourceendlinenumber="216"><code class="lang-c#">[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
  [HttpPost]
  [IgnoreAntiforgeryToken]
  public async Task&lt;IActionResult&gt; DoSomethingSafe(SomeViewModel model)
  {
    // no antiforgery token required
  }
}
</code></pre><h2 id="javascript-ajax-and-spas" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="218" sourceendlinenumber="218">JavaScript, AJAX, and SPAs</h2>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="220" sourceendlinenumber="220">In traditional HTML-based applications, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and single page applications (SPAs), many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token. If cookies are used to store authentication tokens and to authenticate API requests on the server, then CSRF will be a potential problem. However, if local storage is used to store the token, CSRF vulnerability may be mitigated, since values from local storage are not sent automatically to the server with every new request. Thus, using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.</p>
<h3 id="angularjs" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="222" sourceendlinenumber="222">AngularJS</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="224" sourceendlinenumber="224">AngularJS uses a convention to address CSRF. If the server sends a cookie with the name <code>XSRF-TOKEN</code>, the Angular <code>$http</code> service will add the value from this cookie to a header when it sends a request to this server. This process is automatic; you don&#39;t need to set the header explicitly. The header name is <code>X-XSRF-TOKEN</code>. The server should detect this header and validate its contents.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="226" sourceendlinenumber="226">For ASP.NET Core API work with this convention:</p>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="228" sourceendlinenumber="229">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="228" sourceendlinenumber="228">Configure your app to provide a token in a cookie called <code>XSRF-TOKEN</code></li>
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="229" sourceendlinenumber="229">Configure the antiforgery service to look for a header named <code>X-XSRF-TOKEN</code></li>
</ul>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="231" sourceendlinenumber="233"><code class="lang-c#">services.AddAntiforgery(options =&gt; options.HeaderName = &quot;X-XSRF-TOKEN&quot;);
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="235" sourceendlinenumber="235"><a href="https://github.com/aspnet/Docs/tree/master/aspnetcore/security/anti-request-forgery/sample/AngularSample" data-raw-source="[View sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/anti-request-forgery/sample/AngularSample)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="235" sourceendlinenumber="235">View sample</a>.</p>
<h3 id="javascript" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="237" sourceendlinenumber="237">JavaScript</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="239" sourceendlinenumber="239">Using JavaScript with views, you can create the token using a service from within your view. To do so, you inject the <code>Microsoft.AspNetCore.Antiforgery.IAntiforgery</code> service into the view and call <code>GetAndStoreTokens</code>, as shown:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="241" sourceendlinenumber="241"><code class="lang-csharp" name="Main" highlight-lines="4-10,24">@{
    ViewData[&quot;Title&quot;] = &quot;AJAX Demo&quot;;
}
@inject Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf
@functions{
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Context).RequestToken;
    }
}
&lt;h2&gt;@ViewData[&quot;Title&quot;].&lt;/h2&gt;
&lt;h3&gt;@ViewData[&quot;Message&quot;]&lt;/h3&gt;

&lt;div class=&quot;row&quot;&gt;
    &lt;input type=&quot;button&quot; id=&quot;antiforgery&quot; value=&quot;Antiforgery&quot; /&gt;
    &lt;script src=&quot;https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.1.4.min.js&quot;&gt;&lt;/script&gt;
    &lt;script&gt;
                $(&quot;#antiforgery&quot;).click(function () {
                    $.ajax({
                        type: &quot;post&quot;,
                        dataType: &quot;html&quot;,
                        headers:
                        {
                            &quot;RequestVerificationToken&quot;: &#39;@GetAntiXsrfRequestToken()&#39;
                        },
                        url: &#39;@Url.Action(&quot;Antiforgery&quot;, &quot;Home&quot;)&#39;,
                        success: function (result) {
                            alert(result);
                        },
                        error: function (err, scnd) {
                            alert(err.statusText);
                        }
                    });
                });
    &lt;/script&gt;
&lt;/div&gt;
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="243" sourceendlinenumber="243">This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="245" sourceendlinenumber="245">JavaScript can also access tokens provided in cookies, and then use the cookie&#39;s contents to create a header with the token&#39;s value, as shown below.</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="247" sourceendlinenumber="250"><code class="lang-c#">context.Response.Cookies.Append(&quot;CSRF-TOKEN&quot;, tokens.RequestToken, 
  new Microsoft.AspNetCore.Http.CookieOptions { HttpOnly = false });
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="252" sourceendlinenumber="252">Then, assuming you construct your script requests to send the token in a header called <code>X-CSRF-TOKEN</code>, configure the antiforgery service to look for the <code>X-CSRF-TOKEN</code> header:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="254" sourceendlinenumber="256"><code class="lang-c#">services.AddAntiforgery(options =&gt; options.HeaderName = &quot;X-CSRF-TOKEN&quot;);
</code></pre><p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="258" sourceendlinenumber="258">The following example uses jQuery to make an AJAX request with the appropriate header:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="260" sourceendlinenumber="272"><code class="lang-javascript">var csrfToken = $.cookie(&quot;CSRF-TOKEN&quot;);

$.ajax({
    url: &quot;/api/password/changepassword&quot;,
    contentType: &quot;application/json&quot;,
    data: JSON.stringify({ &quot;newPassword&quot;: &quot;ReallySecurePassword999$$$&quot; }),
    type: &quot;POST&quot;,
    headers: {
        &quot;X-CSRF-TOKEN&quot;: csrfToken
    }
});
</code></pre><h2 id="configuring-antiforgery" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="274" sourceendlinenumber="274">Configuring Antiforgery</h2>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="276" sourceendlinenumber="276"><code>IAntiforgery</code> provides the API to configure the antiforgery system. It can be requested in the <code>Configure</code> method of the <code>Startup</code> class. The following example uses middleware from the app&#39;s home page to generate an antiforgery token and send it in the response as a cookie (using the default Angular naming convention described above):</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="279" sourceendlinenumber="301"><code class="lang-c#">public void Configure(IApplicationBuilder app, 
    IAntiforgery antiforgery)
{
    app.Use(next =&gt; context =&gt;
    {
        string path = context.Request.Path.Value;
        if (
            string.Equals(path, &quot;/&quot;, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, &quot;/index.html&quot;, StringComparison.OrdinalIgnoreCase))
        {
            // We can send the request token as a JavaScript-readable cookie, 
            // and Angular will use it by default.
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append(&quot;XSRF-TOKEN&quot;, tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
    //
}
</code></pre><h3 id="options" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="303" sourceendlinenumber="303">Options</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="305" sourceendlinenumber="305">You can customize <a href="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.antiforgeryoptions#fields_summary" data-raw-source="[antiforgery options](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.antiforgeryoptions#fields_summary)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="305" sourceendlinenumber="305">antiforgery options</a> in <code>ConfigureServices</code>:</p>
<pre sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="307" sourceendlinenumber="318"><code class="lang-c#">services.AddAntiforgery(options =&gt; 
{
  options.CookieDomain = &quot;mydomain.com&quot;;
  options.CookieName = &quot;X-CSRF-TOKEN-COOKIENAME&quot;;
  options.CookiePath = &quot;Path&quot;;
  options.FormFieldName = &quot;AntiforgeryFieldname&quot;;
  options.HeaderName = &quot;X-CSRF-TOKEN-HEADERNAME&quot;;
  options.RequireSsl = false;
  options.SuppressXFrameOptionsHeader = false;
});
</code></pre><!-- QAfix fix table -->
<table sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="322" sourceendlinenumber="330">
<thead>
<tr>
<th>Option</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr>
<td>CookieDomain</td>
<td>The domain of the cookie. Defaults to <code>null</code>.</td>
</tr>
<tr>
<td>CookieName</td>
<td>The name of the cookie. If not set, the system will generate a unique name beginning with the <code>DefaultCookiePrefix</code> (&quot;.AspNetCore.Antiforgery.&quot;).</td>
</tr>
<tr>
<td>CookiePath</td>
<td>The path set on the cookie.</td>
</tr>
<tr>
<td>FormFieldName</td>
<td>The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views.</td>
</tr>
<tr>
<td>HeaderName</td>
<td>The name of the header used by the antiforgery system. If <code>null</code>, the system will consider only form data.</td>
</tr>
<tr>
<td>RequireSsl</td>
<td>Specifies whether SSL is required by the antiforgery system. Defaults to <code>false</code>. If <code>true</code>, non-SSL requests will fail.</td>
</tr>
<tr>
<td>SuppressXFrameOptionsHeader</td>
<td>Specifies whether to suppress generation of the <code>X-Frame-Options</code> header. By default, the header is generated with a value of &quot;SAMEORIGIN&quot;. Defaults to <code>false</code>.</td>
</tr>
</tbody>
</table>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="332" sourceendlinenumber="332">See <a href="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.cookieauthenticationoptions" data-raw-source="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.cookieauthenticationoptions" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="332" sourceendlinenumber="332">https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.cookieauthenticationoptions</a> for more info.</p>
<h3 id="extending-antiforgery" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="334" sourceendlinenumber="334">Extending Antiforgery</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="336" sourceendlinenumber="336">The <a href="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider" data-raw-source="[IAntiForgeryAdditionalDataProvider](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="336" sourceendlinenumber="336">IAntiForgeryAdditionalDataProvider</a> type allows developers to extend the behavior of the anti-XSRF system by round-tripping additional data in each token. The <a href="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_GetAdditionalData_Microsoft_AspNetCore_Http_HttpContext_" data-raw-source="[GetAdditionalData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_GetAdditionalData_Microsoft_AspNetCore_Http_HttpContext_)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="336" sourceendlinenumber="336">GetAdditionalData</a> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <a href="https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_ValidateAdditionalData_Microsoft_AspNetCore_Http_HttpContext_System_String_" data-raw-source="[ValidateAdditionalData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.antiforgery.iantiforgeryadditionaldataprovider#Microsoft_AspNetCore_Antiforgery_IAntiforgeryAdditionalDataProvider_ValidateAdditionalData_Microsoft_AspNetCore_Http_HttpContext_System_String_)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="336" sourceendlinenumber="336">ValidateAdditionalData</a> to validate this data when the token is validated. The client&#39;s username is already embedded in the generated tokens, so there is no need to include this information. If a token includes supplemental data but no <code>IAntiForgeryAdditionalDataProvider</code> has been configured, the supplemental data is not validated.</p>
<h2 id="fundamentals" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="338" sourceendlinenumber="338">Fundamentals</h2>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="340" sourceendlinenumber="340">CSRF attacks rely on the default browser behavior of sending cookies associated with a domain with every request made to that domain. These cookies are stored within the browser. They frequently include session cookies for authenticated users. Cookie-based authentication is a popular form of authentication. Token-based authentication systems have been growing in popularity, especially for SPAs and other &quot;smart client&quot; scenarios.</p>
<h3 id="cookie-based-authentication" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="342" sourceendlinenumber="342">Cookie-based authentication</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="344" sourceendlinenumber="344">Once a user has authenticated using their username and password, they are issued a token that can be used to identify them and validate that they have been authenticated. The token is stored as a cookie that accompanies every request the client makes. Generating and validating this cookie is done by the cookie authentication middleware. ASP.NET Core provides cookie <a href="../fundamentals/middleware.html" data-raw-source="[middleware](../fundamentals/middleware.md)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="344" sourceendlinenumber="344">middleware</a> which serializes a user principal into an encrypted cookie and then, on subsequent requests, validates the cookie, recreates the principal and assigns it to the <code>User</code> property on <code>HttpContext</code>.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="346" sourceendlinenumber="346">When a cookie is used, The authentication cookie is just a container for the forms authentication ticket. The ticket is passed as the value of the forms authentication cookie with each request and is used by forms authentication, on the server, to identify an authenticated user.</p>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="348" sourceendlinenumber="348">When a user is logged in to a system, a user session is created on the server-side and is stored in a database or some other persistent store. The system generates a session key that points to the actual session in the data store and it is sent as a client side cookie. The web server will check this session key any time a user requests a resource that requires authorization. The system checks whether the associated user session has the privilege to access the requested resource. If so, the request continues. Otherwise, the request returns as not authorized. In this approach, cookies are used to make the application appear to be stateful, since it is able to &quot;remember&quot; that the user has previously authenticated with the server.</p>
<h3 id="user-tokens" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="350" sourceendlinenumber="350">User tokens</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="352" sourceendlinenumber="352">Token-based authentication doesn’t store session on the server. Instead, when a user is logged in they are issued a token (not an antiforgery token). This token holds all the data that is required to validate the token. It also contains user information, in the form of <a href="https://docs.microsoft.com/dotnet/framework/security/claims-based-identity-model" data-raw-source="[claims](https://docs.microsoft.com/dotnet/framework/security/claims-based-identity-model)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="352" sourceendlinenumber="352">claims</a>. When a user wants to access a server resource requiring authentication, the token is sent to the server with an additional authorization header in form of Bearer {token}. This makes the application stateless since in each subsequent request the token is passed in the request for server-side validation. This token is not <em>encrypted</em>; rather it is <em>encoded</em>. On the server-side the token can be decoded to access the raw information within the token. To send the token in subsequent requests, you can either store it in browser’s local storage or in a cookie. You don’t have to worry about XSRF vulnerability if your token is stored in the local storage, but it is an issue if the token is stored in a cookie.</p>
<h3 id="multiple-applications-are-hosted-in-one-domain" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="354" sourceendlinenumber="354">Multiple applications are hosted in one domain</h3>
<p sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="356" sourceendlinenumber="356">Even though <code>example1.cloudapp.net</code> and <code>example2.cloudapp.net</code> are different hosts, there is an implicit trust relationship between all hosts under the <code>*.cloudapp.net</code> domain. This implicit trust relationship allows potentially untrusted hosts to affect each other’s cookies (the same-origin policies that govern AJAX requests do not necessarily apply to HTTP cookies). The ASP.NET Core runtime provides some mitigation in that the username is embedded into the field token, so even if a malicious subdomain is able to overwrite a session token it will be unable to generate a valid field token for the user. However, when hosted in such an environment the built-in anti-XSRF routines still cannot defend against session hijacking or login CSRF attacks. Shared hosting environments are vunerable to session hijacking, login CSRF, and other attacks.</p>
<h3 id="additional-resources" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="359" sourceendlinenumber="359">Additional Resources</h3>
<ul sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="361" sourceendlinenumber="361">
<li sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="361" sourceendlinenumber="361"><a href="https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)" data-raw-source="[XSRF](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF))" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="361" sourceendlinenumber="361">XSRF</a> on <a href="https://www.owasp.org/index.php/Main_Page" data-raw-source="[Open Web Application Security Project](https://www.owasp.org/index.php/Main_Page)" sourcefile="security/anti-request-forgery.md" sourcestartlinenumber="361" sourceendlinenumber="361">Open Web Application Security Project</a> (OWASP).</li>
</ul>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/aspnet/Docs/blob/w/riande/RP-EF/aspnetcore/security/anti-request-forgery.md/#L1" class="contribution-link">Improve this Doc</a>
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
