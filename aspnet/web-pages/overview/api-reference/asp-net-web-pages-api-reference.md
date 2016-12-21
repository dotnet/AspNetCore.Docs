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

[!code[Main](asp-net-web-pages-api-reference/samples/sample1.xml)]

### `AsBool(), AsBool(true|false)`

Converts a string value to a Boolean value (true/false). Returns false or the specified value if the string does not represent true/false.

[!code[Main](asp-net-web-pages-api-reference/samples/sample2.xml)]

### `AsDateTime(), AsDateTime(value)`

Converts a string value to date/time. Returns `DateTime.MinValue` or the specified value if the string does not represent a date/time.

[!code[Main](asp-net-web-pages-api-reference/samples/sample3.xml)]

### `AsDecimal(), AsDecimal(value)`

Converts a string value to a decimal value. Returns 0.0 or the specified value if the string does not represent a decimal value.

[!code[Main](asp-net-web-pages-api-reference/samples/sample4.xml)]

### `AsFloat(), AsFloat(value)`

Converts a string value to a float. Returns 0.0 or the specified value if the string does not represent a decimal value.

[!code[Main](asp-net-web-pages-api-reference/samples/sample5.xml)]

### `AsInt(), AsInt(value)`

Converts a string value to an integer. Returns 0 or the specified value if the string does not represent an integer.

[!code[Main](asp-net-web-pages-api-reference/samples/sample6.xml)]

### `Href(path [, param1 [, param2]])`

Creates a browser-compatible URL from a local file path, with optional additional path parts.

[!code[Main](asp-net-web-pages-api-reference/samples/sample7.xml)]

### `Html.Raw(value)`

Renders *value* as HTML markup instead of rendering it as HTML-encoded output.

[!code[Main](asp-net-web-pages-api-reference/samples/sample8.xml)]

### `IsBool(), IsDateTime(), IsDecimal(), IsFloat(), IsInt()`

Returns true if the value can be converted from a string to the specified type.

[!code[Main](asp-net-web-pages-api-reference/samples/sample9.xml)]

### `IsEmpty()`

Returns true if the object or variable has no value.

[!code[Main](asp-net-web-pages-api-reference/samples/sample10.xml)]

### `IsPost`

Returns true if the request is a POST. (Initial requests are usually a GET.)

[!code[Main](asp-net-web-pages-api-reference/samples/sample11.xml)]

### `Layout`

Specifies the path of a layout page to apply to this page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample12.xml)]

### `PageData[key], PageData[index],Page`

Contains data shared between the page, layout pages, and partial pages in the current request. You can use the dynamic `Page` property to access the same data, as in the following example:

[!code[Main](asp-net-web-pages-api-reference/samples/sample13.xml)]

### `RenderBody()`

(Layout pages) Renders the content of a content page that is not in any named sections.

[!code[Main](asp-net-web-pages-api-reference/samples/sample14.xml)]

### `RenderPage(path, values)`  
`RenderPage(path[,param1 [, param2]])`

Renders a content page using the specified path and optional extra data. You can get the values of the extra parameters from `PageData` by position (example 1) or key (example 2).

[!code[Main](asp-net-web-pages-api-reference/samples/sample15.xml)]

### `RenderSection(sectionName [, required = true|false])`

(Layout pages) Renders a content section that has a name. Set *required* to false to make a section optional.

[!code[Main](asp-net-web-pages-api-reference/samples/sample16.xml)]

### `Request.Cookies[key]`

Gets or sets the value of an HTTP cookie.

[!code[Main](asp-net-web-pages-api-reference/samples/sample17.xml)]

### `Request.Files[key]`

Gets the files that were uploaded in the current request.

[!code[Main](asp-net-web-pages-api-reference/samples/sample18.xml)]

### `Request.Form[key]`

Gets data that was posted in a form (as strings). `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

[!code[Main](asp-net-web-pages-api-reference/samples/sample19.xml)]

### `Request.QueryString[key]`

Gets data that was specified in the URL query string. `Request[key]` checks both the `Request.Form` and the `Request.QueryString` collections.

[!code[Main](asp-net-web-pages-api-reference/samples/sample20.xml)]

### `Request.Unvalidated(key)`  
`Request.Unvalidated().QueryString|Form|Cookies|Headers[key]`

Selectively disables request validation for a form element, query-string value, cookie, or header value. Request validation is enabled by default and prevents users from posting markup or other potentially dangerous content.

[!code[Main](asp-net-web-pages-api-reference/samples/sample21.xml)]

### `Response.AddHeader(name, value)`

Adds an HTTP server header to the response.

[!code[Main](asp-net-web-pages-api-reference/samples/sample22.xml)]

### `Response.OutputCache(seconds [, sliding] [, varyByParams])`

Caches the page output for a specified time. Optionally set *sliding* to reset the timeout on each page access and *varyByParams* to cache different versions of the page for each different query string in the page request.

[!code[Main](asp-net-web-pages-api-reference/samples/sample23.xml)]

### `Response.Redirect(path)`

Redirects the browser request to a new location.

[!code[Main](asp-net-web-pages-api-reference/samples/sample24.xml)]

### `Response.SetStatus(httpStatusCode)`

Sets the HTTP status code sent to the browser.

[!code[Main](asp-net-web-pages-api-reference/samples/sample25.xml)]

### `Response.WriteBinary(data [, mimetype])`

Writes the contents of *data* to the response with an optional MIME type.

[!code[Main](asp-net-web-pages-api-reference/samples/sample26.xml)]

### `Response.WriteFile(file)`

Writes the contents of a file to the response.

[!code[Main](asp-net-web-pages-api-reference/samples/sample27.xml)]

### `@section(sectionName) {content }`

(Layout pages) Defines a content section that has a name.

[!code[Main](asp-net-web-pages-api-reference/samples/sample28.xml)]

### `Server.HtmlDecode(htmlText)`

Decodes a string that is HTML encoded.

[!code[Main](asp-net-web-pages-api-reference/samples/sample29.xml)]

### `Server.HtmlEncode(text)`

Encodes a string for rendering in HTML markup.

[!code[Main](asp-net-web-pages-api-reference/samples/sample30.xml)]

### `Server.MapPath(virtualPath)`

Returns the server physical path for the specified virtual path.

[!code[Main](asp-net-web-pages-api-reference/samples/sample31.xml)]

### `Server.UrlDecode(urlText)`

Decodes text from a URL.

[!code[Main](asp-net-web-pages-api-reference/samples/sample32.xml)]

### `Server.UrlEncode(text)`

Encodes text to put in a URL.

[!code[Main](asp-net-web-pages-api-reference/samples/sample33.xml)]

### `Session[key]`

Gets or sets a value that exists until the user closes the browser.

[!code[Main](asp-net-web-pages-api-reference/samples/sample34.xml)]

### `ToString()`

Displays a string representation of the object's value.

[!code[Main](asp-net-web-pages-api-reference/samples/sample35.xml)]

### `UrlData[index]`

Gets additional data from the URL (for example, */MyPage/ExtraData*).

[!code[Main](asp-net-web-pages-api-reference/samples/sample36.xml)]

### `WebSecurity.ChangePassword(userName,currentPassword,newPassword)`

Changes the password for the specified user.

[!code[Main](asp-net-web-pages-api-reference/samples/sample37.xml)]

### `WebSecurity.ConfirmAccount(accountConfirmationToken)`

Confirms an account using the account confirmation token.

[!code[Main](asp-net-web-pages-api-reference/samples/sample38.xml)]

### `WebSecurity.CreateAccount(userName, password`  
 `[, requireConfirmationToken = true|false])`

Creates a new user account with the specified user name and password. To require a confirmation token, pass true for *requireConfirmationToken.*

[!code[Main](asp-net-web-pages-api-reference/samples/sample39.xml)]

### `WebSecurity.CurrentUserId`

Gets the integer identifier for the currently logged-in user.

[!code[Main](asp-net-web-pages-api-reference/samples/sample40.xml)]

### `WebSecurity.CurrentUserName`

Gets the name for the currently logged-in user.

[!code[Main](asp-net-web-pages-api-reference/samples/sample41.xml)]

### `WebSecurity.GeneratePasswordResetToken(username`  
 `[, tokenExpirationInMinutesFromNow])`

Generates a password-reset token that can be sent in email to a user so that the user can reset the password.

[!code[Main](asp-net-web-pages-api-reference/samples/sample42.xml)]

### `WebSecurity.GetUserId(userName)`

Returns the user ID from the user name.

[!code[Main](asp-net-web-pages-api-reference/samples/sample43.xml)]

### `WebSecurity.IsAuthenticated`

Returns true if the current user is logged in.

[!code[Main](asp-net-web-pages-api-reference/samples/sample44.xml)]

### `WebSecurity.IsConfirmed(userName)`

Returns true if the user has been confirmed (for example, through a confirmation email).

[!code[Main](asp-net-web-pages-api-reference/samples/sample45.xml)]

### `WebSecurity.IsCurrentUser(userName)`

Returns true if the current user's name matches the specified user name.

[!code[Main](asp-net-web-pages-api-reference/samples/sample46.xml)]

### `WebSecurity.Login(userName,password[, persistCookie])`

Logs the user in by setting an authentication token in the cookie.

[!code[Main](asp-net-web-pages-api-reference/samples/sample47.xml)]

### `WebSecurity.Logout()`

Logs the user out by removing the authentication token cookie.

[!code[Main](asp-net-web-pages-api-reference/samples/sample48.xml)]

### `WebSecurity.RequireAuthenticatedUser()`

If the user is not authenticated, sets the HTTP status to 401 (Unauthorized).

[!code[Main](asp-net-web-pages-api-reference/samples/sample49.xml)]

### `WebSecurity.RequireRoles(roles)`

If the current user is not a member of one of the specified roles, sets the HTTP status to 401 (Unauthorized).

[!code[Main](asp-net-web-pages-api-reference/samples/sample50.xml)]

### `WebSecurity.RequireUser(userId)`  
`WebSecurity.RequireUser(userName)`

If the current user is not the user specified by *username*, sets the HTTP status to 401 (Unauthorized).

[!code[Main](asp-net-web-pages-api-reference/samples/sample51.xml)]

### `WebSecurity.ResetPassword(passwordResetToken,newPassword)`

If the password reset token is valid, changes the user's password to the new password.

[!code[Main](asp-net-web-pages-api-reference/samples/sample52.xml)]

<a id="Data"></a>
## Data

### `Database.Execute(SQLstatement [,parameters]`

Executes *SQLstatement* (with optional parameters) such as INSERT, DELETE, or UPDATE and returns a count of affected records.

[!code[Main](asp-net-web-pages-api-reference/samples/sample53.xml)]

### `Database.GetLastInsertId()`

Returns the identity column from the most recently inserted row.

[!code[Main](asp-net-web-pages-api-reference/samples/sample54.xml)]

### `Database.Open(filename)`  
`Database.Open(connectionStringName)`

Opens either the specified database file or the database specified using a named connection string from the *Web.config* file.

[!code[Main](asp-net-web-pages-api-reference/samples/sample55.xml)]

### `Database.OpenConnectionString(connectionString)`

Opens a database using the connection string. (This contrasts with `Database.Open`, which uses a connection string name.)

[!code[Main](asp-net-web-pages-api-reference/samples/sample56.xml)]

### `Database.Query(SQLstatement[,parameters])`

Queries the database using *SQLstatement* (optionally passing parameters) and returns the results as a collection.

[!code[Main](asp-net-web-pages-api-reference/samples/sample57.xml)]

### `Database.QuerySingle(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single record.

[!code[Main](asp-net-web-pages-api-reference/samples/sample58.xml)]

### `Database.QueryValue(SQLstatement [, parameters])`

Executes *SQLstatement* (with optional parameters) and returns a single value.

[!code[Main](asp-net-web-pages-api-reference/samples/sample59.xml)]

<a id="Helpers"></a>
## Helpers

### `Analytics.GetGoogleHtml(webPropertyId)`

Renders the Google Analytics JavaScript code for the specified ID.

[!code[Main](asp-net-web-pages-api-reference/samples/sample60.xml)]

### `Analytics.GetStatCounterHtml(project,security)`

Renders the StatCounter Analytics JavaScript code for the specified project.

[!code[Main](asp-net-web-pages-api-reference/samples/sample61.xml)]

### `Analytics.GetYahooHtml(account)`

Renders the Yahoo Analytics JavaScript code for the specified account.

[!code[Main](asp-net-web-pages-api-reference/samples/sample62.xml)]

### `Bing.SearchBox([boxWidth])`

Passes a search to Bing. To specify the site to search and a title for the search box, you can set the `Bing.SiteUrl` and `Bing.SiteTitle` properties. Normally you set these properties in the *\_AppStart* page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample63.xml)]

[!code[Main](asp-net-web-pages-api-reference/samples/sample64.xml)]

### `Chart(width,height [, template] [, templatePath])`

Initializes a chart.

[!code[Main](asp-net-web-pages-api-reference/samples/sample65.xml)]

### `Chart.AddLegend([title] [, name])`

Adds a legend to a chart.

[!code[Main](asp-net-web-pages-api-reference/samples/sample66.xml)]

### `Chart.AddSeries([name] [, chartType] [, chartArea]`  
 `[, axisLabel] [, legend] [, markerStep] [, xValue]`  
 `[, xField] [, yValues] [, yFields] [, options])`

Adds a series of values to the chart.

[!code[Main](asp-net-web-pages-api-reference/samples/sample67.xml)]

### `Crypto.Hash(string [, algorithm])`  
`Crypto.Hash(bytes [, algorithm])`

Returns a hash for the specified data. The default algorithm is `sha256`.

[!code[Main](asp-net-web-pages-api-reference/samples/sample68.xml)]

### `Facebook.LikeButton(href [, buttonLayout] [, showFaces] [, width] [, height]`   
 `[, action] [, font] [, colorScheme] [, refLabel])`

Lets Facebook users make a connection to pages.

[!code[Main](asp-net-web-pages-api-reference/samples/sample69.xml)]

### `FileUpload.GetHtml([initialNumberOfFiles] [, allowMoreFilesToBeAdded]`  
 `[, includeFormTag] [, addText] [, uploadText])`

Renders UI for uploading files.

[!code[Main](asp-net-web-pages-api-reference/samples/sample70.xml)]

### `GamerCard.GetHtml(gamerTag)`

Renders the specified Xbox gamer tag.

[!code[Main](asp-net-web-pages-api-reference/samples/sample71.xml)]

### `Gravatar.GetHtml(email [, imageSize] [, defaultImage] [, rating]`  
 `[, imageExtension] [, attributes])`

Renders the Gravatar image for the specified email address.

[!code[Main](asp-net-web-pages-api-reference/samples/sample72.xml)]

### `Json.Encode(object)`

Converts a data object to a string in the JavaScript Object Notation (JSON) format.

[!code[Main](asp-net-web-pages-api-reference/samples/sample73.xml)]

### `Json.Decode(string)`

Converts a JSON-encoded input string to a data object that you can iterate over or insert into a database.

[!code[Main](asp-net-web-pages-api-reference/samples/sample74.xml)]

### `LinkShare.GetHtml(pageTitle[, pageLinkBack] [, twitterUserName]`  
 `[, additionalTweetText] [, linkSites])`

Renders social networking links using the specified title and optional URL.

[!code[Main](asp-net-web-pages-api-reference/samples/sample75.xml)]

### `ModelStateDictionary.AddError(key, errorMessage)`

Associates an error message with a form field. Use the `ModelState` helper to access this member.

[!code[Main](asp-net-web-pages-api-reference/samples/sample76.xml)]

### `ModelStateDictionary.AddFormError(errorMessage)`

Associates an error message with a form. Use the `ModelState` helper to access this member.

[!code[Main](asp-net-web-pages-api-reference/samples/sample77.xml)]

### `ModelStateDictionary.IsValid`

Returns true if there are no validation errors. Use the `ModelState` helper to access this member.

[!code[Main](asp-net-web-pages-api-reference/samples/sample78.xml)]

### `ObjectInfo.Print(value [, depth] [, enumerationLength])`

Renders the properties and values of an object and any child objects.

[!code[Main](asp-net-web-pages-api-reference/samples/sample79.xml)]

### `Recaptcha.GetHtml([, publicKey] [, theme] [, language] [, tabIndex])`

Renders the reCAPTCHA verification test.

[!code[Main](asp-net-web-pages-api-reference/samples/sample80.xml)]

### `ReCaptcha.PublicKey`  
 `ReCaptcha.PrivateKey`

Sets public and private keys for the reCAPTCHA service. Normally you set these properties in the *\_AppStart* page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample81.xml)]

### `ReCaptcha.Validate([, privateKey])`

Returns the result of the reCAPTCHA test.

[!code[Main](asp-net-web-pages-api-reference/samples/sample82.xml)]

### `ServerInfo.GetHtml()`

Renders status information about ASP.NET Web Pages.

[!code[Main](asp-net-web-pages-api-reference/samples/sample83.xml)]

### `Twitter.Profile(twitterUserName)`

Renders a Twitter stream for the specified user.

[!code[Main](asp-net-web-pages-api-reference/samples/sample84.xml)]

### `Twitter.Search(searchQuery)`

Renders a Twitter stream for the specified search text.

[!code[Main](asp-net-web-pages-api-reference/samples/sample85.xml)]

### `Video.Flash(filename [, width, height])`

Renders a Flash video player for the specified file with optional width and height.

[!code[Main](asp-net-web-pages-api-reference/samples/sample86.xml)]

### `Video.MediaPlayer(filename [, width, height])`

Renders a Windows Media player for the specified file with optional width and height.

[!code[Main](asp-net-web-pages-api-reference/samples/sample87.xml)]

### `Video.Silverlight(filename, width, height)`

Renders a Silverlight player for the specified *.xap* file with required width and height.

[!code[Main](asp-net-web-pages-api-reference/samples/sample88.xml)]

### `WebCache.Get(key)`

Returns the object specified by *key*, or null if the object is not found.

[!code[Main](asp-net-web-pages-api-reference/samples/sample89.xml)]

### `WebCache.Remove(key)`

Removes the object specified by *key* from the cache.

[!code[Main](asp-net-web-pages-api-reference/samples/sample90.xml)]

### `WebCache.Set(key, value [, minutesToCache] [, slidingExpiration])`

Puts *value* into the cache under the name specified by *key*.

[!code[Main](asp-net-web-pages-api-reference/samples/sample91.xml)]

### `WebGrid(data)`

Creates a new `WebGrid` object using data from a query.

[!code[Main](asp-net-web-pages-api-reference/samples/sample92.xml)]

### `WebGrid.GetHtml()`

Renders markup to display data in an HTML table.

[!code[Main](asp-net-web-pages-api-reference/samples/sample93.xml)]

### `WebGrid.Pager()`

Renders a pager for the `WebGrid` object.

[!code[Main](asp-net-web-pages-api-reference/samples/sample94.xml)]

### `WebImage(path)`

Loads an image from the specified path.

[!code[Main](asp-net-web-pages-api-reference/samples/sample95.xml)]

### `WebImage.AddImagesWatermark(image)`

Adds the specified image as a watermark.

[!code[Main](asp-net-web-pages-api-reference/samples/sample96.xml)]

### `WebImage.AddTextWatermark(text)`

Adds the specified text to the image.

[!code[Main](asp-net-web-pages-api-reference/samples/sample97.xml)]

### `WebImage.FlipHorizontal()`  
`WebImage.FlipVertical()`

Flips the image horizontally or vertically.

[!code[Main](asp-net-web-pages-api-reference/samples/sample98.xml)]

### `WebImage.GetImageFromRequest()`

Loads an image when an image is posted to a page during a file upload.

[!code[Main](asp-net-web-pages-api-reference/samples/sample99.xml)]

### `WebImage.Resize(width,height)`

Resizes an the image.

[!code[Main](asp-net-web-pages-api-reference/samples/sample100.xml)]

### `WebImage.RotateLeft()`  
`WebImage.RotateRight()`

Rotates the image to the left or the right.

[!code[Main](asp-net-web-pages-api-reference/samples/sample101.xml)]

### `WebImage.Save(path [, imageFormat])`

Saves the image to the specified path.

[!code[Main](asp-net-web-pages-api-reference/samples/sample102.xml)]

### `WebMail.Password`

Sets the password for the SMTP server. Normally you set this property in the *\_AppStart* page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample103.xml)]

### `WebMail.Send(to, subject, body [, from] [, cc] [, filesToAttach] [, isBodyHtml]`  
 `[, additionalHeaders])`

Sends an email message.

[!code[Main](asp-net-web-pages-api-reference/samples/sample104.xml)]

### `WebMail.SmtpServer`

Sets the SMTP server name. Normally you set this property in the*\_AppStart* page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample105.xml)]

### `WebMail.UserName`

Sets the user name for the SMTP server. Normally you should set this property in the *\_AppStart* page.

[!code[Main](asp-net-web-pages-api-reference/samples/sample106.xml)]

<a id="Validation"></a>
## Validation

### `Html.ValidationMessage(field)`

(v2) Renders a validation error message for the specified field.

[!code[Main](asp-net-web-pages-api-reference/samples/sample107.xml)]

### `Html.ValidationSummary([message])`

(v2) Displays a list of all validation errors.

[!code[Main](asp-net-web-pages-api-reference/samples/sample108.xml)]

### `Validation.Add(field, validationType)`

(v2) Registers a user input element for the specified type of validation.

[!code[Main](asp-net-web-pages-api-reference/samples/sample109.xml)]

### `Validation.ClassFor(field)`

(v2) Dynamically renders CSS class attributes for client-side validation so that you can format validation error messages. (Requires that you reference the appropriate client-script libraries and that you define CSS classes.)

[!code[Main](asp-net-web-pages-api-reference/samples/sample110.xml)]

### `Validation.For(field)`

(v2) Enables client-side validation for the user input field. (Requires that you reference the appropriate client-script libraries.)

[!code[Main](asp-net-web-pages-api-reference/samples/sample111.xml)]

### `Validation.IsValid()`

(v2) Returns true if all user input elements that are registred for validation contain valid values.

[!code[Main](asp-net-web-pages-api-reference/samples/sample112.xml)]

### `Validation.RequireField(field[, errorMessage])`

(v2) Specifies that users must provide a value for the user input element.

[!code[Main](asp-net-web-pages-api-reference/samples/sample113.xml)]

### `Validation.RequireFields(field1[, field12, field3, ...])`

(v2) Specifies that users must provide values for each of the user input elements. This method does not let you specify a custom error message.

[!code[Main](asp-net-web-pages-api-reference/samples/sample114.xml)]

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

[!code[Main](asp-net-web-pages-api-reference/samples/sample115.xml)]