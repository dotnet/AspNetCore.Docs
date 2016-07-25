

RazorPage Class
===============






Represents properties and methods that are needed in order to render a view that uses Razor syntax.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`








Syntax
------

.. code-block:: csharp

    public abstract class RazorPage : IRazorPage








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RazorPage()
    
        
    
        
        .. code-block:: csharp
    
            public RazorPage()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.AddHtmlAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type prefix: System.String
    
        
        :type prefixOffset: System.Int32
    
        
        :type value: System.Object
    
        
        :type valueOffset: System.Int32
    
        
        :type valueLength: System.Int32
    
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
            public void AddHtmlAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginAddHtmlAttributeValues(Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext, System.String, System.Int32, Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle)
    
        
    
        
        :type executionContext: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    
        
        :type attributeName: System.String
    
        
        :type attributeValuesCount: System.Int32
    
        
        :type attributeValueStyle: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle
    
        
        .. code-block:: csharp
    
            public void BeginAddHtmlAttributeValues(TagHelperExecutionContext executionContext, string attributeName, int attributeValuesCount, HtmlAttributeValueStyle attributeValueStyle)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginContext(System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type position: System.Int32
    
        
        :type length: System.Int32
    
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
            public void BeginContext(int position, int length, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginWriteAttribute(System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
    
        
        :type name: System.String
    
        
        :type prefix: System.String
    
        
        :type prefixOffset: System.Int32
    
        
        :type suffix: System.String
    
        
        :type suffixOffset: System.Int32
    
        
        :type attributeValuesCount: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void BeginWriteAttribute(string name, string prefix, int prefixOffset, string suffix, int suffixOffset, int attributeValuesCount)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginWriteAttributeTo(System.IO.TextWriter, System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type name: System.String
    
        
        :type prefix: System.String
    
        
        :type prefixOffset: System.Int32
    
        
        :type suffix: System.String
    
        
        :type suffixOffset: System.Int32
    
        
        :type attributeValuesCount: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void BeginWriteAttributeTo(TextWriter writer, string name, string prefix, int prefixOffset, string suffix, int suffixOffset, int attributeValuesCount)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginWriteTagHelperAttribute()
    
        
    
        
        Starts a new scope for writing :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` attribute values.
    
        
    
        
        .. code-block:: csharp
    
            public void BeginWriteTagHelperAttribute()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.CreateTagHelper<TTagHelper>()
    
        
    
        
        Creates and activates a :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\.
    
        
        :rtype: TTagHelper
        :return: The activated :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\.
    
        
        .. code-block:: csharp
    
            public TTagHelper CreateTagHelper<TTagHelper>()where TTagHelper : ITagHelper
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.DefineSection(System.String, Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate)
    
        
    
        
        Creates a named content section in the page that can be invoked in a Layout page using 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSection(System.String)` or :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSectionAsync(System.String,System.Boolean)`\.
    
        
    
        
        :param name: The name of the section to create.
        
        :type name: System.String
    
        
        :param section: The :any:`Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate` to execute when rendering the section.
        
        :type section: Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate
    
        
        .. code-block:: csharp
    
            public void DefineSection(string name, RenderAsyncDelegate section)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndAddHtmlAttributeValues(Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
    
        
        :type executionContext: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    
        
        .. code-block:: csharp
    
            public void EndAddHtmlAttributeValues(TagHelperExecutionContext executionContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndContext()
    
        
    
        
        .. code-block:: csharp
    
            public void EndContext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndTagHelperWritingScope()
    
        
    
        
        Ends the current writing scope that was started by calling :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.StartTagHelperWritingScope(System.Text.Encodings.Web.HtmlEncoder)`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: The buffered :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`\.
    
        
        .. code-block:: csharp
    
            public TagHelperContent EndTagHelperWritingScope()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndWriteAttribute()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void EndWriteAttribute()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndWriteAttributeTo(System.IO.TextWriter)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public virtual void EndWriteAttributeTo(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EndWriteTagHelperAttribute()
    
        
    
        
        Ends the current writing scope that was started by calling :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.BeginWriteTagHelperAttribute`\.
    
        
        :rtype: System.String
        :return: The content buffered by the shared :any:`System.IO.StringWriter` of this :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`\.
    
        
        .. code-block:: csharp
    
            public string EndWriteTagHelperAttribute()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.EnsureRenderedBodyOrSections()
    
        
    
        
        .. code-block:: csharp
    
            public void EnsureRenderedBodyOrSections()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.FlushAsync()
    
        
    
        
        Invokes :dn:meth:`System.IO.TextWriter.FlushAsync` on :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Output` and :dn:meth:`Stream.FlushAsync`
        on the response stream, writing out any buffered content to the :dn:prop:`Microsoft.AspNetCore.Http.HttpResponse.Body`\.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.HtmlString<Microsoft.AspNetCore.Html.HtmlString>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the asynchronous flush operation and on
            completion returns :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty`\.
    
        
        .. code-block:: csharp
    
            public Task<HtmlString> FlushAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Href(System.String)
    
        
    
        
        :type contentPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Href(string contentPath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.IgnoreBody()
    
        
    
        
        In a Razor layout page, ignores rendering the portion of a content page that is not within a named section.
    
        
    
        
        .. code-block:: csharp
    
            public void IgnoreBody()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.IgnoreSection(System.String)
    
        
    
        
        In layout pages, ignores rendering the content of the section named <em>sectionName</em>.
    
        
    
        
        :param sectionName: The section to ignore.
        
        :type sectionName: System.String
    
        
        .. code-block:: csharp
    
            public void IgnoreSection(string sectionName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.InvalidTagHelperIndexerAssignment(System.String, System.String, System.String)
    
        
    
        
        Format an error message about using an indexer when the tag helper property is <code>null</code>.
    
        
    
        
        :param attributeName: Name of the HTML attribute associated with the indexer.
        
        :type attributeName: System.String
    
        
        :param tagHelperTypeName: Full name of the tag helper :any:`System.Type`\.
        
        :type tagHelperTypeName: System.String
    
        
        :param propertyName: Dictionary property in the tag helper.
        
        :type propertyName: System.String
        :rtype: System.String
        :return: An error message about using an indexer when the tag helper property is <code>null</code>.
    
        
        .. code-block:: csharp
    
            public static string InvalidTagHelperIndexerAssignment(string attributeName, string tagHelperTypeName, string propertyName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.IsSectionDefined(System.String)
    
        
    
        
        Returns a value that indicates whether the specified section is defined in the content page.
    
        
    
        
        :param name: The section name to search for.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the specified section is defined in the content page; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool IsSectionDefined(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderBody()
    
        
    
        
        In a Razor layout page, renders the portion of a content page that is not within a named section.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: The HTML content to render.
    
        
        .. code-block:: csharp
    
            protected virtual IHtmlContent RenderBody()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSection(System.String)
    
        
    
        
        In layout pages, renders the content of the section named <em>name</em>.
    
        
    
        
        :param name: The name of the section to render.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Html.HtmlString
        :return: Returns :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty` to allow the :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Write(System.Object)` call to
            succeed.
    
        
        .. code-block:: csharp
    
            public HtmlString RenderSection(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSection(System.String, System.Boolean)
    
        
    
        
        In layout pages, renders the content of the section named <em>name</em>.
    
        
    
        
        :param name: The section to render.
        
        :type name: System.String
    
        
        :param required: Indicates if this section must be rendered.
        
        :type required: System.Boolean
        :rtype: Microsoft.AspNetCore.Html.HtmlString
        :return: Returns :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty` to allow the :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Write(System.Object)` call to
            succeed.
    
        
        .. code-block:: csharp
    
            public HtmlString RenderSection(string name, bool required)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSectionAsync(System.String)
    
        
    
        
        In layout pages, asynchronously renders the content of the section named <em>name</em>.
    
        
    
        
        :param name: The section to render.
        
        :type name: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.HtmlString<Microsoft.AspNetCore.Html.HtmlString>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that on completion returns :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty` that
            allows the :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Write(System.Object)` call to succeed.
    
        
        .. code-block:: csharp
    
            public Task<HtmlString> RenderSectionAsync(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.RenderSectionAsync(System.String, System.Boolean)
    
        
    
        
        In layout pages, asynchronously renders the content of the section named <em>name</em>.
    
        
    
        
        :param name: The section to render.
        
        :type name: System.String
    
        
        :param required: Indicates the <em>name</em> section must be registered
            (using <code>@section</code>) in the page.
        
        :type required: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.HtmlString<Microsoft.AspNetCore.Html.HtmlString>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that on completion returns :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty` that
            allows the :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Write(System.Object)` call to succeed.
    
        
        .. code-block:: csharp
    
            public Task<HtmlString> RenderSectionAsync(string name, bool required)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.SetAntiforgeryCookieAndHeader()
    
        
    
        
        Sets antiforgery cookie and X-Frame-Options header on the response.
    
        
        :rtype: Microsoft.AspNetCore.Html.HtmlString
        :return: :dn:field:`Microsoft.AspNetCore.Html.HtmlString.Empty`\.
    
        
        .. code-block:: csharp
    
            public virtual HtmlString SetAntiforgeryCookieAndHeader()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.StartTagHelperWritingScope(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Starts a new writing scope and optionally overrides :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.HtmlEncoder` within that scope.
    
        
    
        
        :param encoder: 
            The :any:`System.Text.Encodings.Web.HtmlEncoder` to use when this :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage` handles
            non- :any:`Microsoft.AspNetCore.Html.IHtmlContent` C# expressions. If <code>null</code>, does not change :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.HtmlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void StartTagHelperWritingScope(HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Write(System.Object)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Output`\.
    
        
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void Write(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type prefix: System.String
    
        
        :type prefixOffset: System.Int32
    
        
        :type value: System.Object
    
        
        :type valueOffset: System.Int32
    
        
        :type valueLength: System.Int32
    
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
            public void WriteAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteAttributeValueTo(System.IO.TextWriter, System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type prefix: System.String
    
        
        :type prefixOffset: System.Int32
    
        
        :type value: System.Object
    
        
        :type valueOffset: System.Int32
    
        
        :type valueLength: System.Int32
    
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
            public void WriteAttributeValueTo(TextWriter writer, string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteLiteral(System.Object)
    
        
    
        
        Writes the specified <em>value</em> without HTML encoding to :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Output`\.
    
        
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void WriteLiteral(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteLiteralTo(System.IO.TextWriter, System.Object)
    
        
    
        
        Writes the specified <em>value</em> without HTML encoding to the <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void WriteLiteralTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteLiteralTo(System.IO.TextWriter, System.String)
    
        
    
        
        Writes the specified <em>value</em> without HTML encoding to :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.Output`\.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.String` to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public virtual void WriteLiteralTo(TextWriter writer, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, System.Object)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void WriteTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, System.String)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.String` to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public virtual void WriteTo(TextWriter writer, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder, System.Object)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to given <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param encoder: 
            The :any:`System.Text.Encodings.Web.HtmlEncoder` to use when encoding <em>value</em>.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public static void WriteTo(TextWriter writer, HtmlEncoder encoder, object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.BodyContent
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent BodyContent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Context
    
        
    
        
        An :any:`Microsoft.AspNetCore.Http.HttpContext` representing the current request execution.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.DiagnosticSource
    
        
    
        
        Gets or sets a :dn:meth:`System.Diagnostics.DiagnosticSource.#ctor` instance used to instrument the page execution.
    
        
        :rtype: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
            public DiagnosticSource DiagnosticSource { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.HtmlEncoder
    
        
    
        
        Gets the :any:`System.Text.Encodings.Web.HtmlEncoder` to use when this :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`
        handles non- :any:`Microsoft.AspNetCore.Html.IHtmlContent` C# expressions.
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public HtmlEncoder HtmlEncoder { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.IsLayoutBeingRendered
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsLayoutBeingRendered { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Layout
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Layout { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Output
    
        
    
        
        Gets the :any:`System.IO.TextWriter` that the page is writing output to.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public virtual TextWriter Output { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.PreviousSectionWriters
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate<Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, RenderAsyncDelegate> PreviousSectionWriters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.SectionWriters
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate<Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, RenderAsyncDelegate> SectionWriters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.TempData
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` from the :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage.ViewContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.User
    
        
    
        
        Gets the :any:`System.Security.Claims.ClaimsPrincipal` of the current logged in user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public virtual ClaimsPrincipal User { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.ViewBag
    
        
    
        
        Gets the dynamic view data dictionary.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public ViewContext ViewContext { get; set; }
    

