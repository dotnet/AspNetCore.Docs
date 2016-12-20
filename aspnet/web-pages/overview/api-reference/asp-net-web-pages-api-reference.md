---
title: "ASP.NET Web Pages (Razor) API Quick Reference | Microsoft Docs"
author: tfitzmac
description: "This page contains a list with brief examples of the most commonly used objects, properties, and methods for programming ASP.NET Web Pages with Razor syntax."
ms.author: riande
manager: wpickett
ms.date: 02/10/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/api-reference/asp-net-web-pages-api-reference
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-pages\overview\api-reference\asp-net-web-pages-api-reference.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/38949) | [View dev content](http://docs.aspdev.net/tutorials/web-pages/overview/api-reference/asp-net-web-pages-api-reference.html) | [View prod content](http://www.asp.net/web-pages/overview/api-reference/asp-net-web-pages-api-reference) | Picker: 38371

ASP.NET Web Pages (Razor) API Quick Reference
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This page contains a list with brief examples of the most commonly used objects, properties, and methods for programming ASP.NET Web Pages with Razor syntax.
> 
> Descriptions marked with "(v2)" were introduced in ASP.NET Web Pages version 2.
> 
> For API reference documentation, see the [ASP.NET Web Pages Reference Documentation](https://go.microsoft.com/fwlink/?LinkId=208659) on MSDN.
> 
> ## Software versions
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2 and ASP.NET Web Pages 1.0 (except for features marked v2).


This page contains reference information for the following:

- [Classes](#Classes)
- [Data](#Data)
- [Helpers](#Helpers)
- [Validation](#Validation)

<a id="Classes"></a>
## Classes

### `AppState[key], AppState[index],App`

Contains data that can be shared by any pages in the application. You can use the dynamic `App` property to access the same data, as in the following example:

    AppState["FavoriteColor"] = "red";
    AppState[1] = "apples";
    App.MyGreeting = "Good morning";
    // Displays the value assigned to AppData[1] in the page.
    @App[1]
    // Displays the value assigned to App.MyGreeting.
    @App.MyGreeting

### `AsBool(), AsBool(true|false)`

Converts a string value to a Boolean value (true/false). Returns false or the specified value if the string does not represent true/false.

    bool b = stringValue.AsBool();

### `AsDateTime(), AsDateTime(value)`

Converts a string value to date/time. Returns `DateTime.MinValue` or the specified value if the string does not represent a date/time.

    DateTime dt = stringValue.AsDateTime();

### `AsDecimal(), AsDecimal(value)`

Converts a string value to a decimal value. Returns 0.0 or the specified value if the string does not represent a decimal value.

    decimal d = stringValue.AsDecimal();

### `AsFloat(), AsFloat(value)`

Converts a string value to a float. Returns 0.0 or the specified value if the string does not represent a decimal value.

    float d = stringValue.AsFloat();

### `AsInt(), AsInt(value)`

Converts a string value to an integer. Returns 0 or the specified value if the string does not represent an integer.

    int i = stringValue.AsInt();

### `Href(path [, param1 [, param2]])`

Creates a browser-compatible URL from a local file path, with optional additional path parts.

    <a href="@Href("~/Folder/File")">Link to My File</a>
    <a href="@Href("~/Product", "Tea")">Link to Product</a>

### `Html.Raw(value)`

Renders *value* as HTML markup instead of rendering it as HTML-encoded output.

    @* Inserts markup into the page. *@
    @Html.Raw("<div>Hello <em>world</em>!</div>")

### `IsBool(), IsDateTime(), IsDecimal(), IsFloat(), IsInt()`

Returns true if the value can be converted from a string to the specified type.

    var isint = stringValue.IsInt();

### `IsEmpty()`

Returns true if the object or variable has no value.

    if (Request["companyname"].IsEmpty()) {
       @:Company name is required.<br />
    }

### `IsPost`

Returns true if the request is a POST. (Initial requests are usually a GET.)

    if (IsPost) { Response.Redirect("Posted"); }

### `Layout`

Specifies the path of a layout page to apply to this page.

    Layout = "_MyLayout.cshtml";

### `PageData[key], PageData[index],Page`

Contains data shared between the page, layout pages, and partial pages in the current request. You can use the dynamic `Page` property to access the same data, as in the following example:

    PageData["FavoriteColor"] = "red";
    PageData[1] = "apples";
    Page.MyGreeting = "Good morning";
    // Displays the value assigned to PageData[1] in the page.
    @Page[1]
    // Displays the value assigned to Page.MyGreeting.
    @Page.MyGreeting

### `RenderBody()`

(Layout pages) Renders the content of a content page that is not in any named sections.

    @RenderBody()

### `RenderPage(path, values)`  
`RenderPage(path[,param1 [, param2]])`

Renders a content page using the specified path and optional extra data. You can get the values of the extra parameters from `PageData` by position (example 1) or key (example 2).

    RenderPage("_MySubPage.cshtml", "red", 123, "apples")
    RenderPage("_MySubPage.cshtml", new { color = "red", number = 123, food = "apples" })

### `RenderSection(sectionName [, required = true|false])`

(Layout pages) Renders a content section that has a name. Set *required* to false to make a section optional.

    @RenderSection("header")

### `Request.Cookies[key]`

Gets or sets the value of an HTTP cookie.

    var cookieValue = Request.Cookies["myCookie"].Value;

### `Request.Files[key]`

Gets the files that were uploaded in the current request.

    Request.Files["postedFile"].SaveAs(@"MyPostedFile");

### `Request.Form[key]`

Gets data that was posted in a form (as strings). `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

    var formValue = Request.Form["myTextBox"];
    // This call produces the same result.
    var formValue = Request["myTextBox"];

### `Request.QueryString[key]`

Gets data that was specified in the URL query string. `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

    var queryValue = Request.QueryString["myTextBox"];
    // This call produces the same result.
    var queryValue = Request["myTextBox"];

### `Request.Unvalidated(key)`  
`Request.Unvalidated().QueryString|Form|Cookies|Headers[key]`

Selectively disables request validation for a form element, query-string value, cookie, or header value. Request validation is enabled by default and prevents users from posting markup or other potentially dangerous content.

    // Call the method directly to disable validation on the specified item from
    // one of the Request collections.
    Request.Unvalidated("userText");
    
    // You can optionally specify which collection the value is from.
    var prodID = Request.Unvalidated().QueryString["productID"];
    var richtextValue = Request.Unvalidated().Form["richTextBox1"];
    var cookie = Request.Unvalidated().Cookies["mostRecentVisit"];

### `Response.AddHeader(name, value)`

Adds an HTTP server header to the response.

    // Adds a header that requests client browsers to use basic authentication.
    Response.AddHeader("WWW-Authenticate", "BASIC");

### `Response.OutputCache(seconds [, sliding] [, varyByParams])`

Caches the page output for a specified time. Optionally set *sliding* to reset the timeout on each page access and *varyByParams* to cache different versions of the page for each different query string in the page request.

    Response.OutputCache(60);
    Response.OutputCache(3600, true);
    Response.OutputCache(10, varyByParams : new[] {"category","sortOrder"});

### `Response.Redirect(path)`

Redirects the browser request to a new location.

    Response.Redirect("~/Folder/File");

### `Response.SetStatus(httpStatusCode)`

Sets the HTTP status code sent to the browser.

    Response.SetStatus(HttpStatusCode.Unauthorized);
    Response.SetStatus(401);

### `Response.WriteBinary(data [, mimetype])`

Writes the contents of *data* to the response with an optional MIME type.

    Response.WriteBinary(image, "image/jpeg");

### `Response.WriteFile(file)`

Writes the contents of a file to the response.

    Response.WriteFile("file.ext");

### `@section(sectionName) {content }`

(Layout pages) Defines a content section that has a name.

    @section header { <div>Header text</div> }

### `Server.HtmlDecode(htmlText)`

Decodes a string that is HTML encoded.

    var htmlDecoded = Server.HtmlDecode("&lt;html&gt;");

### `Server.HtmlEncode(text)`

Encodes a string for rendering in HTML markup.

    var htmlEncoded = Server.HtmlEncode("<html>");

### `Server.MapPath(virtualPath)`

Returns the server physical path for the specified virtual path.

    var dataFile = Server.MapPath("~/App_Data/data.txt");

### `Server.UrlDecode(urlText)`

Decodes text from a URL.

    var urlDecoded = Server.UrlDecode("url%20data");

### `Server.UrlEncode(text)`

Encodes text to put in a URL.

    var urlEncoded = Server.UrlEncode("url data");

### `Session[key]`

Gets or sets a value that exists until the user closes the browser.

    Session["FavoriteColor"] = "red";

### `ToString()`

Displays a string representation of the object's value.

    <p>It is now @DateTime.Now.ToString()</p>

### `UrlData[index]`

Gets additional data from the URL (for example, */MyPage/ExtraData*).

    var pathInfo = UrlData[0];

### `WebSecurity.ChangePassword(userName,currentPassword,newPassword)`

Changes the password for the specified user.

    var success = WebSecurity.ChangePassword("my-username",
        "current-password", "new-password");

### `WebSecurity.ConfirmAccount(accountConfirmationToken)`

Confirms an account using the account confirmation token.

    var confirmationToken = Request.QueryString["ConfirmationToken"];
    if(WebSecurity.ConfirmAccount(confirmationToken)) {
          //...
    }

### `WebSecurity.CreateAccount(userName, password`  
 `[, requireConfirmationToken = true|false])`

Creates a new user account with the specified user name and password. To require a confirmation token, pass true for *requireConfirmationToken.*

    WebSecurity.CreateAccount("my-username", "secretpassword");

### `WebSecurity.CurrentUserId`

Gets the integer identifier for the currently logged-in user.

    var userId = WebSecurity.CurrentUserId;

### `WebSecurity.CurrentUserName`

Gets the name for the currently logged-in user.

    var welcome = "Hello " + WebSecurity.CurrentUserName;

### `WebSecurity.GeneratePasswordResetToken(username`  
 `[, tokenExpirationInMinutesFromNow])`

Generates a password-reset token that can be sent in email to a user so that the user can reset the password.

    var resetToken = WebSecurity.GeneratePasswordResetToken("my-username");
    var message = "Visit http://example.com/reset-password/" + resetToken +
        " to reset your password";
    WebMail.Send(..., message);

### `WebSecurity.GetUserId(userName)`

Returns the user ID from the user name.

    var userId = WebSecurity.GetUserId(userName);

### `WebSecurity.IsAuthenticated`

Returns true if the current user is logged in.

    if(WebSecurity.IsAuthenticated) {...}

### `WebSecurity.IsConfirmed(userName)`

Returns true if the user has been confirmed (for example, through a confirmation email).

    if(WebSecurity.IsConfirmed("joe@contoso.com")) { ... }

### `WebSecurity.IsCurrentUser(userName)`

Returns true if the current user's name matches the specified user name.

    if(WebSecurity.IsCurrentUser("joe@contoso.com")) { ... }

### `WebSecurity.Login(userName,password[, persistCookie])`

Logs the user in by setting an authentication token in the cookie.

    if(WebSecurity.Login("username", "password")) { ... }

### `WebSecurity.Logout()`

Logs the user out by removing the authentication token cookie.

    WebSecurity.Logout();

### `WebSecurity.RequireAuthenticatedUser()`

If the user is not authenticated, sets the HTTP status to 401 (Unauthorized).

    WebSecurity.RequireAuthenticatedUser();

### `WebSecurity.RequireRoles(roles)`

If the current user is not a member of one of the specified roles, sets the HTTP status to 401 (Unauthorized).

    WebSecurity.RequireRoles("Admin", "Power Users");

### `WebSecurity.RequireUser(userId)`  
`WebSecurity.RequireUser(userName)`

If the current user is not the user specified by *username*, sets the HTTP status to 401 (Unauthorized).

    WebSecurity.RequireUser("joe@contoso.com");

### `WebSecurity.ResetPassword(passwordResetToken,newPassword)`

If the password reset token is valid, changes the user's password to the new password.

    WebSecurity.ResetPassword( "A0F36BFD9313", "new-password")

<a id="Data"></a>
## Data

### `Database.Execute(SQLstatement [,parameters]`

Executes *SQLstatement* (with optional parameters) such as INSERT, DELETE, or UPDATE and returns a count of affected records.

    db.Execute("INSERT INTO Data (Name) VALUES ('Smith')");
    
    db.Execute("INSERT INTO Data (Name) VALUES (@0)", "Smith");

### `Database.GetLastInsertId()`

Returns the identity column from the most recently inserted row.

    db.Execute("INSERT INTO Data (Name) VALUES ('Smith')");
    var id = db.GetLastInsertId();

### `Database.Open(filename)`  
`Database.Open(connectionStringName)`

Opens either the specified database file or the database specified using a named connection string from the *Web.config* file.

    // Note that no filename extension is specified.
    var db = Database.Open("SmallBakery"); // Opens SmallBakery.sdf in App_Data
    // Opens a database by using a named connection string.
    var db = Database.Open("SmallBakeryConnectionString");

### `Database.OpenConnectionString(connectionString)`

Opens a database using the connection string. (This contrasts with `Database.Open`, which uses a connection string name.)

    var db = Database.OpenConnectionString("Data Source=|DataDirectory|\SmallBakery.sdf");

### `Database.Query(SQLstatement[,parameters])`

Queries the database using *SQLstatement* (optionally passing parameters) and returns the results as a collection.

    foreach (var result in db.Query("SELECT * FROM PRODUCT")) {<p>@result.Name</p>}
    
    foreach (var result = db.Query("SELECT * FROM PRODUCT WHERE Price > @0", 20))
       { <p>@result.Name</p> }

### `Database.QuerySingle(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single record.

    var product = db.QuerySingle("SELECT * FROM Product WHERE Id = 1");
    
    var product = db.QuerySingle("SELECT * FROM Product WHERE Id = @0", 1);

### `Database.QueryValue(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single value.

    var count = db.QueryValue("SELECT COUNT(*) FROM Product");
    
    var count = db.QueryValue("SELECT COUNT(*) FROM Product WHERE Price > @0", 20);

<a id="Helpers"></a>
## Helpers

### `Analytics.GetGoogleHtml(webPropertyId)`

Renders the Google Analytics JavaScript code for the specified ID.

    @Analytics.GetGoogleHtml("MyWebPropertyId")

### `Analytics.GetStatCounterHtml(project,security)`

Renders the StatCounter Analytics JavaScript code for the specified project.

    @Analytics.GetStatCounterHtml(89, "security")

### `Analytics.GetYahooHtml(account)`

Renders the Yahoo Analytics JavaScript code for the specified account.

    @Analytics.GetYahooHtml("myaccount")

### `Bing.SearchBox([boxWidth])`

Passes a search to Bing. To specify the site to search and a title for the search box, you can set the `Bing.SiteUrl` and `Bing.SiteTitle` properties. Normally you set these properties in the *\_AppStart* page.

    @Bing.SearchBox() @* Searches the web.*@

    @{
       Bing.SiteUrl = "www.asp.net";  @* Limits search to the www.asp.net site. *@
    }
    @Bing.SearchBox()

### `Chart(width,height [, template] [, templatePath])`

Initializes a chart.

    @{
       var myChart = new Chart(width: 600, height: 400);
    }

### `Chart.AddLegend([title] [, name])`

Adds a legend to a chart.

    @{
    var myChart = new Chart(width: 600, height: 400)
        .AddLegend("Basic Chart")
        .AddSeries(
            name: "Employee",
            xValue: new[] {  "Peter", "Andrew", "Julie", "Mary", "Dave" },
            yValues: new[] { "2", "6", "4", "5", "3" })
        .Write();
    }

### `Chart.AddSeries([name] [, chartType] [, chartArea]`  
 `[, axisLabel] [, legend] [, markerStep] [, xValue]`  
 `[, xField] [, yValues] [, yFields] [, options])`

Adds a series of values to the chart.

    @{
    var myChart = new Chart(width: 600, height: 400)
        .AddSeries(
            name: "Employee",
            xValue: new[] {  "Peter", "Andrew", "Julie", "Mary", "Dave" },
            yValues: new[] { "2", "6", "4", "5", "3" })
        .Write();
    }

### `Crypto.Hash(string [, algorithm])`  
`Crypto.Hash(bytes [, algorithm])`

Returns a hash for the specified data. The default algorithm is `sha256`.

    @Crypto.Hash("data")

### `Facebook.LikeButton(href [, buttonLayout] [, showFaces] [, width] [, height]`   
 `[, action] [, font] [, colorScheme] [, refLabel])`

Lets Facebook users make a connection to pages.

    @Facebook.LikeButton("www.asp.net")

### `FileUpload.GetHtml([initialNumberOfFiles] [, allowMoreFilesToBeAdded]`  
 `[, includeFormTag] [, addText] [, uploadText])`

Renders UI for uploading files.

    @FileUpload.GetHtml(initialNumberOfFiles:1, allowMoreFilesToBeAdded:false,
      includeFormTag:true, uploadText:"Upload")

### `GamerCard.GetHtml(gamerTag)`

Renders the specified Xbox gamer tag.

    @GamerCard.GetHtml("joe")

### `Gravatar.GetHtml(email [, imageSize] [, defaultImage] [, rating]`  
 `[, imageExtension] [, attributes])`

Renders the Gravatar image for the specified email address.

    @Gravatar.GetHtml("joe@contoso.com")

### `Json.Encode(object)`

Converts a data object to a string in the JavaScript Object Notation (JSON) format.

    var myJsonString = Json.Encode(dataObject);

### `Json.Decode(string)`

Converts a JSON-encoded input string to a data object that you can iterate over or insert into a database.

    var myJsonObj = Json.Decode(jsonString);

### `LinkShare.GetHtml(pageTitle[, pageLinkBack] [, twitterUserName]`  
 `[, additionalTweetText] [, linkSites])`

Renders social networking links using the specified title and optional URL.

    @LinkShare.GetHtml("ASP.NET Web Pages Samples")
    @LinkShare.GetHtml("ASP.NET Web Pages Samples", "https://www.asp.net")

### `ModelStateDictionary.AddError(key, errorMessage)`

Associates an error message with a form field. Use the `ModelState` helper to access this member.

    ModelState.AddError("email", "Enter an email address");

### `ModelStateDictionary.AddFormError(errorMessage)`

Associates an error message with a form. Use the `ModelState` helper to access this member.

    ModelState.AddFormError("Password and confirmation password do not match.");

### `ModelStateDictionary.IsValid`

Returns true if there are no validation errors. Use the `ModelState` helper to access this member.

    if (ModelState.IsValid) { // Save the form to the database }

### `ObjectInfo.Print(value [, depth] [, enumerationLength])`

Renders the properties and values of an object and any child objects.

    @ObjectInfo.Print(person)

### `Recaptcha.GetHtml([, publicKey] [, theme] [, language] [, tabIndex])`

Renders the reCAPTCHA verification test.

    @ReCaptcha.GetHtml()

### `ReCaptcha.PublicKey`  
 `ReCaptcha.PrivateKey`

Sets public and private keys for the reCAPTCHA service. Normally you set these properties in the *\_AppStart* page.

    ReCaptcha.PublicKey = "your-public-recaptcha-key";
    ReCaptcha.PrivateKey = "your-private-recaptcha-key";

### `ReCaptcha.Validate([, privateKey])`

Returns the result of the reCAPTCHA test.

    if (ReCaptcha.Validate()) {
       // Test passed.
    }

### `ServerInfo.GetHtml()`

Renders status information about ASP.NET Web Pages.

    @ServerInfo.GetHtml()

### `Twitter.Profile(twitterUserName)`

Renders a Twitter stream for the specified user.

    @Twitter.Profile("billgates")

### `Twitter.Search(searchQuery)`

Renders a Twitter stream for the specified search text.

    @Twitter.Search("asp.net")

### `Video.Flash(filename [, width, height])`

Renders a Flash video player for the specified file with optional width and height.

    @Video.Flash("test.swf", "100", "100")

### `Video.MediaPlayer(filename [, width, height])`

Renders a Windows Media player for the specified file with optional width and height.

    @Video.MediaPlayer("test.wmv", "100", "100")

### `Video.Silverlight(filename, width, height)`

Renders a Silverlight player for the specified *.xap* file with required width and height.

    @Video.Silverlight("test.xap", "100", "100")

### `WebCache.Get(key)`

Returns the object specified by *key*, or null if the object is not found.

    var username = WebCache.Get("username")

### `WebCache.Remove(key)`

Removes the object specified by *key* from the cache.

    WebCache.Remove("username")

### `WebCache.Set(key, value [, minutesToCache] [, slidingExpiration])`

Puts *value* into the cache under the name specified by *key*.

    WebCache.Set("username", "joe@contoso.com ")

### `WebGrid(data)`

Creates a new `WebGrid` object using data from a query.

    var db = Database.Open("SmallBakery");
    var grid = new WebGrid(db.Query("SELECT * FROM Product"));

### `WebGrid.GetHtml()`

Renders markup to display data in an HTML table.

    @grid.GetHtml()// The 'grid' variable is set when WebGrid is created.

### `WebGrid.Pager()`

Renders a pager for the `WebGrid` object.

    @grid.Pager() // The 'grid' variable is set when WebGrid is created.

### `WebImage(path)`

Loads an image from the specified path.

    var image = new WebImage("test.png");

### `WebImage.AddImagesWatermark(image)`

Adds the specified image as a watermark.

    WebImage photo = new WebImage("test.png");
    WebImage watermarkImage = new WebImage("logo.png");
    photo.AddImageWatermark(watermarkImage);

### `WebImage.AddTextWatermark(text)`

Adds the specified text to the image.

    image.AddTextWatermark("Copyright")

### `WebImage.FlipHorizontal()`  
`WebImage.FlipVertical()`

Flips the image horizontally or vertically.

    image.FlipHorizontal();
    image.FlipVertical();

### `WebImage.GetImageFromRequest()`

Loads an image when an image is posted to a page during a file upload.

    var image = WebImage.GetImageFromRequest();

### `WebImage.Resize(width,height)`

Resizes an the image.

    image.Resize(100, 100);

### `WebImage.RotateLeft()`  
`WebImage.RotateRight()`

Rotates the image to the left or the right.

    image.RotateLeft();
    image.RotateRight();

### `WebImage.Save(path [, imageFormat])`

Saves the image to the specified path.

    image.Save("test.png");

### `WebMail.Password`

Sets the password for the SMTP server. Normally you set this property in the *\_AppStart* page.

    WebMail.Password = "password";

### `WebMail.Send(to, subject, body [, from] [, cc] [, filesToAttach] [, isBodyHtml]`  
 `[, additionalHeaders])`

Sends an email message.

    WebMail.Send("touser@contoso.com", "subject", "body of message",
        "fromuser@contoso.com");

### `WebMail.SmtpServer`

Sets the SMTP server name. Normally you set this property in the*\_AppStart* page.

    WebMail.SmtpServer = "smtp.mailserver.com";

### `WebMail.UserName`

Sets the user name for the SMTP server. Normally you should set this property in the *\_AppStart* page.

    WebMail.UserName = "Joe";

<a id="Validation"></a>
## Validation

### `Html.ValidationMessage(field)`

(v2) Renders a validation error message for the specified field.

    <input type="text"
        name="dateOfBirth"
        value="" />
    @Html.ValidationMessage("dateOfBirth")

### `Html.ValidationSummary([message])`

(v2) Displays a list of all validation errors.

    @Html.ValidationSummary()
    
    @Html.ValidationSummary("The following validation errors occurred:")

### `Validation.Add(field, validationType)`

(v2) Registers a user input element for the specified type of validation.

    Validation.Add("dateOfBirth", Validator.DateTime("Date of birth was not valid"));
    Validation.Add("quantity", Validator.Integer("Enter a number"));
    Validation.Add("confirmPassword",
        Validator.EqualsTo("password", "Passwords must match."));

### `Validation.ClassFor(field)`

(v2) Dynamically renders CSS class attributes for client-side validation so that you can format validation error messages. (Requires that you reference the appropriate client-script libraries and that you define CSS classes.)

    <head>
      <script
        src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.js">
      </script>
      <script
        src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.8.1/jquery.validate.js">
      </script>
      <script
        src="~/Scripts/jquery.validate.unobtrusive.js">
      </script>
    
      <style>
        input-validation-error{ /* style rules  */ }
        field-validation-error{ /* style rules  */ }
        validation-summary-errors{ /* style rules  */ }
        field-validation-valid{ /* style rules  */ }
        input-validation-valid{ /* style rules  */ }
        validation-summary-valid{ /* style rules  */ }
      </style>
    </head>
    
    ...
    
    <input
        type="text"
        name="firstName"
        @Validation.For("firstName") @Validation.ClassFor("firstName")  />

### `Validation.For(field)`

(v2) Enables client-side validation for the user input field. (Requires that you reference the appropriate client-script libraries.)

    <head>
      <script
        src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.js">
      </script>
      <script
        src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.8.1/jquery.validate.js">
      </script>
      <script
        src="~/Scripts/jquery.validate.unobtrusive.js">
      </script>
    </head>
    
    ...
    
    <input
        type="text"
        name="firstName"
        @Validation.For("firstName") />

### `Validation.IsValid()`

(v2) Returns true if all user input elements that are registred for validation contain valid values.

    if(IsPost){
        if (Validation.IsValid()) {
            // Process input
        }
    }

### `Validation.RequireField(field[, errorMessage])`

(v2) Specifies that users must provide a value for the user input element.

    Validation.RequireField("dateOfBirth", "Date of birth is required");

### `Validation.RequireFields(field1[, field12, field3, ...])`

(v2) Specifies that users must provide values for each of the user input elements. This method does not let you specify a custom error message.

    Validation.RequireFields("firstName", "lastName", "dateOfBirth");

### `Validator.DateTime ([error message])`  
`Validator.Decimal([error message])`  
`Validator.EqualsTo(otherField,[error message])`  
`Validator.Float([error message])`  
`Validator.Integer([error message])`  
`Validator.Range(min,max [, error message])`  
`Validator.RegEx(pattern[, error message])`  
`Validator.Required([error message])`  
`Validator.StringLength(length)`  
`Validator.Url([error message])`

(v2) Specifies a validation test when you use the `Validation.Add` method.

    Validation.Add("dateOfBirth", Validator.DateTime("Date of birth was not valid"));
    Validation.Add("quantity", Validator.Integer("Enter a number"));
    Validation.Add("confirmPassword", Validator.EqualsTo("password",
        "Passwords must match."));