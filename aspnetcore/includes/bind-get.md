> [!WARNING]
> For security reasons, you must opt in to binding `GET` request data to page model properties. Verify user input before mapping it to properties. Opting in to `GET` binding is useful when addressing scenarios which rely on query string or route values.
>
> To bind a property on `GET` requests, set the [[BindProperty]](/dotnet/api/microsoft.aspnetcore.mvc.bindpropertyattribute) attribute's `SupportsGet` property to `true`:
> `[BindProperty(SupportsGet = true)]`
