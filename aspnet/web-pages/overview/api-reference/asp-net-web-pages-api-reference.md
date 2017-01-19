---
title: "ASP.NET Web Pages (Razor) API Quick Reference | Microsoft Docs"
author: tfitzmac
description: "This page contains a list with brief examples of the most commonly used objects, properties, and methods for programming ASP.NET Web Pages with Razor syntax."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/10/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/api-reference/asp-net-web-pages-api-reference
msc.type: authoredcontent
---
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

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-1.unknown)]

### `AsBool(), AsBool(true|false)`

Converts a string value to a Boolean value (true/false). Returns false or the specified value if the string does not represent true/false.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample2.cs)]

### `AsDateTime(), AsDateTime(value)`

Converts a string value to date/time. Returns `DateTime.MinValue` or the specified value if the string does not represent a date/time.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-3.unknown)]

### `AsDecimal(), AsDecimal(value)`

Converts a string value to a decimal value. Returns 0.0 or the specified value if the string does not represent a decimal value.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-4.unknown)]

### `AsFloat(), AsFloat(value)`

Converts a string value to a float. Returns 0.0 or the specified value if the string does not represent a decimal value.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-5.unknown)]

### `AsInt(), AsInt(value)`

Converts a string value to an integer. Returns 0 or the specified value if the string does not represent an integer.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-6.unknown)]

### `Href(path [, param1 [, param2]])`

Creates a browser-compatible URL from a local file path, with optional additional path parts.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample7.cshtml)]

### `Html.Raw(value)`

Renders *value* as HTML markup instead of rendering it as HTML-encoded output.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample8.cshtml)]

### `IsBool(), IsDateTime(), IsDecimal(), IsFloat(), IsInt()`

Returns true if the value can be converted from a string to the specified type.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample9.cs)]

### `IsEmpty()`

Returns true if the object or variable has no value.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample10.cs)]

### `IsPost`

Returns true if the request is a POST. (Initial requests are usually a GET.)

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample11.cs)]

### `Layout`

Specifies the path of a layout page to apply to this page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-12.unknown)]

### `PageData[key], PageData[index],Page`

Contains data shared between the page, layout pages, and partial pages in the current request. You can use the dynamic `Page` property to access the same data, as in the following example:

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-13.unknown)]

### `RenderBody()`

(Layout pages) Renders the content of a content page that is not in any named sections.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-14.unknown)]

### `RenderPage(path, values)`  
`RenderPage(path[,param1 [, param2]])`

Renders a content page using the specified path and optional extra data. You can get the values of the extra parameters from `PageData` by position (example 1) or key (example 2).

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-15.unknown)]

### `RenderSection(sectionName [, required = true|false])`

(Layout pages) Renders a content section that has a name. Set *required* to false to make a section optional.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-16.unknown)]

### `Request.Cookies[key]`

Gets or sets the value of an HTTP cookie.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample17.cs)]

### `Request.Files[key]`

Gets the files that were uploaded in the current request.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-18.unknown)]

### `Request.Form[key]`

Gets data that was posted in a form (as strings). `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample19.cs)]

### `Request.QueryString[key]`

Gets data that was specified in the URL query string. `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample20.cs)]

### `Request.Unvalidated(key)`  
`Request.Unvalidated().QueryString|Form|Cookies|Headers[key]`

Selectively disables request validation for a form element, query-string value, cookie, or header value. Request validation is enabled by default and prevents users from posting markup or other potentially dangerous content.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample21.cs)]

### `Response.AddHeader(name, value)`

Adds an HTTP server header to the response.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample22.cs)]

### `Response.OutputCache(seconds [, sliding] [, varyByParams])`

Caches the page output for a specified time. Optionally set *sliding* to reset the timeout on each page access and *varyByParams* to cache different versions of the page for each different query string in the page request.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-23.unknown)]

### `Response.Redirect(path)`

Redirects the browser request to a new location.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-24.unknown)]

### `Response.SetStatus(httpStatusCode)`

Sets the HTTP status code sent to the browser.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-25.unknown)]

### `Response.WriteBinary(data [, mimetype])`

Writes the contents of *data* to the response with an optional MIME type.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-26.unknown)]

### `Response.WriteFile(file)`

Writes the contents of a file to the response.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-27.unknown)]

### `@section(sectionName) {content }`

(Layout pages) Defines a content section that has a name.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample28.cshtml)]

### `Server.HtmlDecode(htmlText)`

Decodes a string that is HTML encoded.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample29.cs)]

### `Server.HtmlEncode(text)`

Encodes a string for rendering in HTML markup.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample30.cs)]

### `Server.MapPath(virtualPath)`

Returns the server physical path for the specified virtual path.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample31.cs)]

### `Server.UrlDecode(urlText)`

Decodes text from a URL.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample32.cs)]

### `Server.UrlEncode(text)`

Encodes text to put in a URL.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample33.cs)]

### `Session[key]`

Gets or sets a value that exists until the user closes the browser.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-34.unknown)]

### `ToString()`

Displays a string representation of the object's value.

[!code-html[Main](asp-net-web-pages-api-reference/samples/sample35.html)]

### `UrlData[index]`

Gets additional data from the URL (for example, */MyPage/ExtraData*).

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample36.cs)]

### `WebSecurity.ChangePassword(userName,currentPassword,newPassword)`

Changes the password for the specified user.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample37.cs)]

### `WebSecurity.ConfirmAccount(accountConfirmationToken)`

Confirms an account using the account confirmation token.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample38.cs)]

### `WebSecurity.CreateAccount(userName, password`  
 `[, requireConfirmationToken = true|false])`

Creates a new user account with the specified user name and password. To require a confirmation token, pass true for *requireConfirmationToken.*

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-39.unknown)]

### `WebSecurity.CurrentUserId`

Gets the integer identifier for the currently logged-in user.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample40.cs)]

### `WebSecurity.CurrentUserName`

Gets the name for the currently logged-in user.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample41.cs)]

### `WebSecurity.GeneratePasswordResetToken(username`  
 `[, tokenExpirationInMinutesFromNow])`

Generates a password-reset token that can be sent in email to a user so that the user can reset the password.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample42.cs)]

### `WebSecurity.GetUserId(userName)`

Returns the user ID from the user name.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample43.cs)]

### `WebSecurity.IsAuthenticated`

Returns true if the current user is logged in.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample44.cs)]

### `WebSecurity.IsConfirmed(userName)`

Returns true if the user has been confirmed (for example, through a confirmation email).

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample45.cs)]

### `WebSecurity.IsCurrentUser(userName)`

Returns true if the current user's name matches the specified user name.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample46.cs)]

### `WebSecurity.Login(userName,password[, persistCookie])`

Logs the user in by setting an authentication token in the cookie.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample47.cs)]

### `WebSecurity.Logout()`

Logs the user out by removing the authentication token cookie.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-48.unknown)]

### `WebSecurity.RequireAuthenticatedUser()`

If the user is not authenticated, sets the HTTP status to 401 (Unauthorized).

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-49.unknown)]

### `WebSecurity.RequireRoles(roles)`

If the current user is not a member of one of the specified roles, sets the HTTP status to 401 (Unauthorized).

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-50.unknown)]

### `WebSecurity.RequireUser(userId)`  
`WebSecurity.RequireUser(userName)`

If the current user is not the user specified by *username*, sets the HTTP status to 401 (Unauthorized).

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-51.unknown)]

### `WebSecurity.ResetPassword(passwordResetToken,newPassword)`

If the password reset token is valid, changes the user's password to the new password.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-52.unknown)]

<a id="Data"></a>
## Data

### `Database.Execute(SQLstatement [,parameters]`

Executes *SQLstatement* (with optional parameters) such as INSERT, DELETE, or UPDATE and returns a count of affected records.

[!code-sql[Main](asp-net-web-pages-api-reference/samples/sample53.sql)]

### `Database.GetLastInsertId()`

Returns the identity column from the most recently inserted row.

[!code-sql[Main](asp-net-web-pages-api-reference/samples/sample54.sql)]

### `Database.Open(filename)`  
`Database.Open(connectionStringName)`

Opens either the specified database file or the database specified using a named connection string from the *Web.config* file.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample55.cs)]

### `Database.OpenConnectionString(connectionString)`

Opens a database using the connection string. (This contrasts with `Database.Open`, which uses a connection string name.)

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample56.cs)]

### `Database.Query(SQLstatement[,parameters])`

Queries the database using *SQLstatement* (optionally passing parameters) and returns the results as a collection.

[!code-html[Main](asp-net-web-pages-api-reference/samples/sample57.html)]

### `Database.QuerySingle(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single record.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample58.cs)]

### `Database.QueryValue(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single value.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample59.cs)]

<a id="Helpers"></a>
## Helpers

### `Analytics.GetGoogleHtml(webPropertyId)`

Renders the Google Analytics JavaScript code for the specified ID.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-60.unknown)]

### `Analytics.GetStatCounterHtml(project,security)`

Renders the StatCounter Analytics JavaScript code for the specified project.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-61.unknown)]

### `Analytics.GetYahooHtml(account)`

Renders the Yahoo Analytics JavaScript code for the specified account.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-62.unknown)]

### `Bing.SearchBox([boxWidth])`

Passes a search to Bing. To specify the site to search and a title for the search box, you can set the `Bing.SiteUrl` and `Bing.SiteTitle` properties. Normally you set these properties in the *\_AppStart* page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-63.unknown)]

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample64.cshtml)]

### `Chart(width,height [, template] [, templatePath])`

Initializes a chart.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample65.cshtml)]

### `Chart.AddLegend([title] [, name])`

Adds a legend to a chart.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample66.cshtml)]

### `Chart.AddSeries([name] [, chartType] [, chartArea]`  
 `[, axisLabel] [, legend] [, markerStep] [, xValue]`  
 `[, xField] [, yValues] [, yFields] [, options])`

Adds a series of values to the chart.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample67.cshtml)]

### `Crypto.Hash(string [, algorithm])`  
`Crypto.Hash(bytes [, algorithm])`

Returns a hash for the specified data. The default algorithm is `sha256`.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-68.unknown)]

### `Facebook.LikeButton(href [, buttonLayout] [, showFaces] [, width] [, height]`   
 `[, action] [, font] [, colorScheme] [, refLabel])`

Lets Facebook users make a connection to pages.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-69.unknown)]

### `FileUpload.GetHtml([initialNumberOfFiles] [, allowMoreFilesToBeAdded]`  
 `[, includeFormTag] [, addText] [, uploadText])`

Renders UI for uploading files.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-70.unknown)]

### `GamerCard.GetHtml(gamerTag)`

Renders the specified Xbox gamer tag.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-71.unknown)]

### `Gravatar.GetHtml(email [, imageSize] [, defaultImage] [, rating]`  
 `[, imageExtension] [, attributes])`

Renders the Gravatar image for the specified email address.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-72.unknown)]

### `Json.Encode(object)`

Converts a data object to a string in the JavaScript Object Notation (JSON) format.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample73.cs)]

### `Json.Decode(string)`

Converts a JSON-encoded input string to a data object that you can iterate over or insert into a database.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample74.cs)]

### `LinkShare.GetHtml(pageTitle[, pageLinkBack] [, twitterUserName]`  
 `[, additionalTweetText] [, linkSites])`

Renders social networking links using the specified title and optional URL.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-75.unknown)]

### `ModelStateDictionary.AddError(key, errorMessage)`

Associates an error message with a form field. Use the `ModelState` helper to access this member.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-76.unknown)]

### `ModelStateDictionary.AddFormError(errorMessage)`

Associates an error message with a form. Use the `ModelState` helper to access this member.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-77.unknown)]

### `ModelStateDictionary.IsValid`

Returns true if there are no validation errors. Use the `ModelState` helper to access this member.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample78.cs)]

### `ObjectInfo.Print(value [, depth] [, enumerationLength])`

Renders the properties and values of an object and any child objects.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-79.unknown)]

### `Recaptcha.GetHtml([, publicKey] [, theme] [, language] [, tabIndex])`

Renders the reCAPTCHA verification test.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-80.unknown)]

### `ReCaptcha.PublicKey`  
 `ReCaptcha.PrivateKey`

Sets public and private keys for the reCAPTCHA service. Normally you set these properties in the *\_AppStart* page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-81.unknown)]

### `ReCaptcha.Validate([, privateKey])`

Returns the result of the reCAPTCHA test.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample82.cs)]

### `ServerInfo.GetHtml()`

Renders status information about ASP.NET Web Pages.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample83.cshtml)]

### `Twitter.Profile(twitterUserName)`

Renders a Twitter stream for the specified user.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-84.unknown)]

### `Twitter.Search(searchQuery)`

Renders a Twitter stream for the specified search text.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-85.unknown)]

### `Video.Flash(filename [, width, height])`

Renders a Flash video player for the specified file with optional width and height.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample86.cshtml)]

### `Video.MediaPlayer(filename [, width, height])`

Renders a Windows Media player for the specified file with optional width and height.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample87.cshtml)]

### `Video.Silverlight(filename, width, height)`

Renders a Silverlight player for the specified *.xap* file with required width and height.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample88.cshtml)]

### `WebCache.Get(key)`

Returns the object specified by *key*, or null if the object is not found.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample89.cs)]

### `WebCache.Remove(key)`

Removes the object specified by *key* from the cache.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-90.unknown)]

### `WebCache.Set(key, value [, minutesToCache] [, slidingExpiration])`

Puts *value* into the cache under the name specified by *key*.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-91.unknown)]

### `WebGrid(data)`

Creates a new `WebGrid` object using data from a query.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample92.cs)]

### `WebGrid.GetHtml()`

Renders markup to display data in an HTML table.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-93.unknown)]

### `WebGrid.Pager()`

Renders a pager for the `WebGrid` object.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-94.unknown)]

### `WebImage(path)`

Loads an image from the specified path.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample95.cs)]

### `WebImage.AddImagesWatermark(image)`

Adds the specified image as a watermark.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-96.unknown)]

### `WebImage.AddTextWatermark(text)`

Adds the specified text to the image.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-97.unknown)]

### `WebImage.FlipHorizontal()`  
`WebImage.FlipVertical()`

Flips the image horizontally or vertically.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-98.unknown)]

### `WebImage.GetImageFromRequest()`

Loads an image when an image is posted to a page during a file upload.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample99.cs)]

### `WebImage.Resize(width,height)`

Resizes an the image.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-100.unknown)]

### `WebImage.RotateLeft()`  
`WebImage.RotateRight()`

Rotates the image to the left or the right.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-101.unknown)]

### `WebImage.Save(path [, imageFormat])`

Saves the image to the specified path.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-102.unknown)]

### `WebMail.Password`

Sets the password for the SMTP server. Normally you set this property in the *\_AppStart* page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-103.unknown)]

### `WebMail.Send(to, subject, body [, from] [, cc] [, filesToAttach] [, isBodyHtml]`  
 `[, additionalHeaders])`

Sends an email message.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-104.unknown)]

### `WebMail.SmtpServer`

Sets the SMTP server name. Normally you set this property in the*\_AppStart* page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-105.unknown)]

### `WebMail.UserName`

Sets the user name for the SMTP server. Normally you should set this property in the *\_AppStart* page.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-106.unknown)]

<a id="Validation"></a>
## Validation

### `Html.ValidationMessage(field)`

(v2) Renders a validation error message for the specified field.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample107.cshtml)]

### `Html.ValidationSummary([message])`

(v2) Displays a list of all validation errors.

[!code-cshtml[Main](asp-net-web-pages-api-reference/samples/sample108.cshtml)]

### `Validation.Add(field, validationType)`

(v2) Registers a user input element for the specified type of validation.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-109.unknown)]

### `Validation.ClassFor(field)`

(v2) Dynamically renders CSS class attributes for client-side validation so that you can format validation error messages. (Requires that you reference the appropriate client-script libraries and that you define CSS classes.)

[!code-html[Main](asp-net-web-pages-api-reference/samples/sample110.html)]

### `Validation.For(field)`

(v2) Enables client-side validation for the user input field. (Requires that you reference the appropriate client-script libraries.)

[!code-html[Main](asp-net-web-pages-api-reference/samples/sample111.html)]

### `Validation.IsValid()`

(v2) Returns true if all user input elements that are registred for validation contain valid values.

[!code-csharp[Main](asp-net-web-pages-api-reference/samples/sample112.cs)]

### `Validation.RequireField(field[, errorMessage])`

(v2) Specifies that users must provide a value for the user input element.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-113.unknown)]

### `Validation.RequireFields(field1[, field12, field3, ...])`

(v2) Specifies that users must provide values for each of the user input elements. This method does not let you specify a custom error message.

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-114.unknown)]

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

[!code-unknown[Main](asp-net-web-pages-api-reference/samples/sample-38949-115.unknown)]