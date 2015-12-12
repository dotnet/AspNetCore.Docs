

RazorPage Class
===============



.. contents:: 
   :local:



Summary
-------

Represents properties and methods that are needed in order to render a view that uses Razor syntax.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorPage`








Syntax
------

.. code-block:: csharp

   public abstract class RazorPage : IRazorPage





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorPage.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorPage.RazorPage()
    
        
    
        
        .. code-block:: csharp
    
           public RazorPage()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.AddHtmlAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type prefix: System.String
        
        
        :type prefixOffset: System.Int32
        
        
        :type value: System.Object
        
        
        :type valueOffset: System.Int32
        
        
        :type valueLength: System.Int32
        
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
           public void AddHtmlAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.BeginAddHtmlAttributeValues(Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext, System.String, System.Int32)
    
        
        
        
        :type executionContext: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        
        
        :type attributeName: System.String
        
        
        :type attributeValuesCount: System.Int32
    
        
        .. code-block:: csharp
    
           public void BeginAddHtmlAttributeValues(TagHelperExecutionContext executionContext, string attributeName, int attributeValuesCount)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.BeginContext(System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type position: System.Int32
        
        
        :type length: System.Int32
        
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
           public void BeginContext(int position, int length, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.BeginWriteAttribute(System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
        
        
        :type name: System.String
        
        
        :type prefix: System.String
        
        
        :type prefixOffset: System.Int32
        
        
        :type suffix: System.String
        
        
        :type suffixOffset: System.Int32
        
        
        :type attributeValuesCount: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void BeginWriteAttribute(string name, string prefix, int prefixOffset, string suffix, int suffixOffset, int attributeValuesCount)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.BeginWriteAttributeTo(System.IO.TextWriter, System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type name: System.String
        
        
        :type prefix: System.String
        
        
        :type prefixOffset: System.Int32
        
        
        :type suffix: System.String
        
        
        :type suffixOffset: System.Int32
        
        
        :type attributeValuesCount: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void BeginWriteAttributeTo(TextWriter writer, string name, string prefix, int prefixOffset, string suffix, int suffixOffset, int attributeValuesCount)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.CreateTagHelper<TTagHelper>()
    
        
    
        Creates and activates a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\.
    
        
        :rtype: {TTagHelper}
        :return: The activated <see cref="T:Microsoft.AspNet.Razor.TagHelpers.ITagHelper" />.
    
        
        .. code-block:: csharp
    
           public TTagHelper CreateTagHelper<TTagHelper>()where TTagHelper : ITagHelper
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.DefineSection(System.String, Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate)
    
        
    
        Creates a named content section in the page that can be invoked in a Layout page using 
        :dn:meth:`Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSection(System.String)` or :dn:meth:`Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSectionAsync(System.String,System.Boolean)`\.
    
        
        
        
        :param name: The name of the section to create.
        
        :type name: System.String
        
        
        :param section: The  to execute when rendering the section.
        
        :type section: Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate
    
        
        .. code-block:: csharp
    
           public void DefineSection(string name, RenderAsyncDelegate section)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EndAddHtmlAttributeValues(Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
        
        
        :type executionContext: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    
        
        .. code-block:: csharp
    
           public void EndAddHtmlAttributeValues(TagHelperExecutionContext executionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EndContext()
    
        
    
        
        .. code-block:: csharp
    
           public void EndContext()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EndTagHelperWritingScope()
    
        
    
        Ends the current writing scope that was started by calling :dn:meth:`Microsoft.AspNet.Mvc.Razor.RazorPage.StartTagHelperWritingScope`\.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: The <see cref="T:System.IO.TextWriter" /> that contains the content written to the <see cref="P:Microsoft.AspNet.Mvc.Razor.RazorPage.Output" /> or
            <see cref="P:Microsoft.AspNet.Mvc.Rendering.ViewContext.Writer" /> during the writing scope.
    
        
        .. code-block:: csharp
    
           public TagHelperContent EndTagHelperWritingScope()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EndWriteAttribute()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void EndWriteAttribute()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EndWriteAttributeTo(System.IO.TextWriter)
    
        
        
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public virtual void EndWriteAttributeTo(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.EnsureRenderedBodyOrSections()
    
        
    
        
        .. code-block:: csharp
    
           public void EnsureRenderedBodyOrSections()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.FlushAsync()
    
        
    
        Invokes :dn:meth:`System.IO.TextWriter.FlushAsync` on :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage.Output` writing out any buffered
        content to the :dn:prop:`Microsoft.AspNet.Http.HttpResponse.Body`\.
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the asynchronous flush operation and on
            completion returns a <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" />.
    
        
        .. code-block:: csharp
    
           public Task<HtmlString> FlushAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.Href(System.String)
    
        
        
        
        :type contentPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Href(string contentPath)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.InvalidTagHelperIndexerAssignment(System.String, System.String, System.String)
    
        
    
        Format an error message about using an indexer when the tag helper property is <c>null</c>.
    
        
        
        
        :param attributeName: Name of the HTML attribute associated with the indexer.
        
        :type attributeName: System.String
        
        
        :param tagHelperTypeName: Full name of the tag helper .
        
        :type tagHelperTypeName: System.String
        
        
        :param propertyName: Dictionary property in the tag helper.
        
        :type propertyName: System.String
        :rtype: System.String
        :return: An error message about using an indexer when the tag helper property is <c>null</c>.
    
        
        .. code-block:: csharp
    
           public static string InvalidTagHelperIndexerAssignment(string attributeName, string tagHelperTypeName, string propertyName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.IsSectionDefined(System.String)
    
        
    
        Returns a value that indicates whether the specified section is defined in the content page.
    
        
        
        
        :param name: The section name to search for.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if the specified section is defined in the content page; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool IsSectionDefined(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderBody()
    
        
    
        In a Razor layout page, renders the portion of a content page that is not within a named section.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.HelperResult
        :return: The HTML content to render.
    
        
        .. code-block:: csharp
    
           protected virtual HelperResult RenderBody()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSection(System.String)
    
        
    
        In layout pages, renders the content of the section named ``name``.
    
        
        
        
        :param name: The name of the section to render.
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
        :return: Returns <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> to allow the <see cref="M:Microsoft.AspNet.Mvc.Razor.RazorPage.Write(System.Object)" /> call to
            succeed.
    
        
        .. code-block:: csharp
    
           public HtmlString RenderSection(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSection(System.String, System.Boolean)
    
        
    
        In layout pages, renders the content of the section named ``name``.
    
        
        
        
        :param name: The section to render.
        
        :type name: System.String
        
        
        :param required: Indicates if this section must be rendered.
        
        :type required: System.Boolean
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
        :return: Returns <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> to allow the <see cref="M:Microsoft.AspNet.Mvc.Razor.RazorPage.Write(System.Object)" /> call to
            succeed.
    
        
        .. code-block:: csharp
    
           public HtmlString RenderSection(string name, bool required)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSectionAsync(System.String)
    
        
    
        In layout pages, asynchronously renders the content of the section named ``name``.
    
        
        
        
        :param name: The section to render.
        
        :type name: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that on completion returns <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> that
            allows the <see cref="M:Microsoft.AspNet.Mvc.Razor.RazorPage.Write(System.Object)" /> call to succeed.
    
        
        .. code-block:: csharp
    
           public Task<HtmlString> RenderSectionAsync(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderSectionAsync(System.String, System.Boolean)
    
        
    
        In layout pages, asynchronously renders the content of the section named ``name``.
    
        
        
        
        :param name: The section to render.
        
        :type name: System.String
        
        
        :type required: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that on completion returns <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" /> that
            allows the <see cref="M:Microsoft.AspNet.Mvc.Razor.RazorPage.Write(System.Object)" /> call to succeed.
    
        
        .. code-block:: csharp
    
           public Task<HtmlString> RenderSectionAsync(string name, bool required)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.SetAntiforgeryCookieAndHeader()
    
        
    
        Sets antiforgery cookie and X-Frame-Options header on the response.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> that returns a <see cref="F:Microsoft.AspNet.Mvc.Rendering.HtmlString.Empty" />.
    
        
        .. code-block:: csharp
    
           public virtual HtmlString SetAntiforgeryCookieAndHeader()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.StartTagHelperWritingScope()
    
        
    
        Starts a new writing scope.
    
        
    
        
        .. code-block:: csharp
    
           public void StartTagHelperWritingScope()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.StartTagHelperWritingScope(System.IO.TextWriter)
    
        
    
        Starts a new writing scope with the given ``writer``.
    
        
        
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void StartTagHelperWritingScope(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.Write(System.Object)
    
        
    
        Writes the specified ``value`` with HTML encoding to :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage.Output`\.
    
        
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public virtual void Write(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type prefix: System.String
        
        
        :type prefixOffset: System.Int32
        
        
        :type value: System.Object
        
        
        :type valueOffset: System.Int32
        
        
        :type valueLength: System.Int32
        
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
           public void WriteAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteAttributeValueTo(System.IO.TextWriter, System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type prefix: System.String
        
        
        :type prefixOffset: System.Int32
        
        
        :type value: System.Object
        
        
        :type valueOffset: System.Int32
        
        
        :type valueLength: System.Int32
        
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
           public void WriteAttributeValueTo(TextWriter writer, string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteLiteral(System.Object)
    
        
    
        Writes the specified ``value`` without HTML encoding to :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage.Output`\.
    
        
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public virtual void WriteLiteral(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteLiteralTo(System.IO.TextWriter, System.Object)
    
        
    
        Writes the specified ``value`` without HTML encoding to the ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public virtual void WriteLiteralTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteLiteralTo(System.IO.TextWriter, System.String)
    
        
    
        Writes the specified ``value`` without HTML encoding to :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage.Output`\.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public virtual void WriteLiteralTo(TextWriter writer, string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteTagHelperAsync(Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
    
        Writes the content of a specified ``tagHelperExecutionContext``.
    
        
        
        
        :param tagHelperExecutionContext: The execution context containing the content.
        
        :type tagHelperExecutionContext: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion writes the <paramref name="tagHelperExecutionContext" /> content.
    
        
        .. code-block:: csharp
    
           public Task WriteTagHelperAsync(TagHelperExecutionContext tagHelperExecutionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteTagHelperToAsync(System.IO.TextWriter, Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
    
        Writes the content of a specified ``tagHelperExecutionContext`` to the specified
        ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param tagHelperExecutionContext: The execution context containing the content.
        
        :type tagHelperExecutionContext: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion writes the <paramref name="tagHelperExecutionContext" /> content
            to the <paramref name="writer" />.
    
        
        .. code-block:: csharp
    
           public Task WriteTagHelperToAsync(TextWriter writer, TagHelperExecutionContext tagHelperExecutionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder, System.Object, System.Boolean)
    
        
    
        Writes the specified ``value`` with HTML encoding to given ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param encoder: The  to use when encoding .
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :param value: The  to write.
        
        :type value: System.Object
        
        
        :param escapeQuotes: If true escapes double quotes in a  of type .
            Otherwise writes  values as-is.
        
        :type escapeQuotes: System.Boolean
    
        
        .. code-block:: csharp
    
           public static void WriteTo(TextWriter writer, IHtmlEncoder encoder, object value, bool escapeQuotes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, System.Object)
    
        
    
        Writes the specified ``value`` with HTML encoding to ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public virtual void WriteTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, System.String)
    
        
    
        Writes the specified ``value`` with HTML encoding to ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public virtual void WriteTo(TextWriter writer, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.Context
    
        
    
        An :any:`Microsoft.AspNet.Http.HttpContext` representing the current request execution.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.HtmlEncoder
    
        
    
        Gets the :any:`Microsoft.Extensions.WebEncoders.IHtmlEncoder` to be used for encoding HTML.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public IHtmlEncoder HtmlEncoder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.IsLayoutBeingRendered
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsLayoutBeingRendered { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.IsPartial
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPartial { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.Layout
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Layout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.Output
    
        
    
        Gets the :any:`System.IO.TextWriter` that the page is writing output to.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public virtual TextWriter Output { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.PageExecutionContext
    
        
        :rtype: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext
    
        
        .. code-block:: csharp
    
           public IPageExecutionContext PageExecutionContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.PreviousSectionWriters
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, RenderAsyncDelegate> PreviousSectionWriters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.RenderBodyDelegateAsync
    
        
        :rtype: System.Func{System.IO.TextWriter,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TextWriter, Task> RenderBodyDelegateAsync { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.SectionWriters
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, RenderAsyncDelegate> SectionWriters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.TempData
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` from the :dn:prop:`Microsoft.AspNet.Mvc.Razor.RazorPage.ViewContext`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.User
    
        
    
        Gets the :any:`System.Security.Claims.ClaimsPrincipal` of the current logged in user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public virtual ClaimsPrincipal User { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.ViewBag
    
        
    
        Gets the dynamic view data dictionary.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorPage.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

