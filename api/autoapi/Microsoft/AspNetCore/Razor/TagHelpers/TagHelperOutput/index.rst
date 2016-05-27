

TagHelperOutput Class
=====================






Class used to represent the output of an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput`








Syntax
------

.. code-block:: csharp

    public class TagHelperOutput : IHtmlContentContainer, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Attributes
    
        
    
        
        The HTML element's attributes.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeList Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Content
    
        
    
        
        Get or set the HTML element's main content.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public TagHelperContent Content
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.IsContentModified
    
        
    
        
        <code>true</code> if :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Content` has been set, <code>false</code> otherwise.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsContentModified
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.PostContent
    
        
    
        
        The HTML element's post content.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public TagHelperContent PostContent
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.PostElement
    
        
    
        
        Content that follows the HTML element.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public TagHelperContent PostElement
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.PreContent
    
        
    
        
        The HTML element's pre content.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public TagHelperContent PreContent
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.PreElement
    
        
    
        
        Content that precedes the HTML element.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public TagHelperContent PreElement
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.TagMode
    
        
    
        
        Syntax of the element in the generated HTML.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            public TagMode TagMode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.TagName
    
        
    
        
        The HTML element's tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.TagHelperOutput(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList, System.Func<System.Boolean, System.Text.Encodings.Web.HtmlEncoder, System.Threading.Tasks.Task<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>>)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput`\.
    
        
    
        
        :param tagName: The HTML element's tag name.
        
        :type tagName: System.String
    
        
        :param attributes: The HTML attributes.
        
        :type attributes: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    
        
        :param getChildContentAsync: 
            A delegate used to execute children asynchronously with the given :any:`System.Text.Encodings.Web.HtmlEncoder` in scope and
            return their rendered content.
        
        :type getChildContentAsync: System.Func<System.Func`3>{System.Boolean<System.Boolean>, System.Text.Encodings.Web.HtmlEncoder<System.Text.Encodings.Web.HtmlEncoder>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}}
    
        
        .. code-block:: csharp
    
            public TagHelperOutput(string tagName, TagHelperAttributeList attributes, Func<bool, HtmlEncoder, Task<TagHelperContent>> getChildContentAsync)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync()
    
        
    
        
        Executes children asynchronously and returns their rendered content.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
            public Task<TagHelperContent> GetChildContentAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync(System.Boolean)
    
        
    
        
        Executes children asynchronously and returns their rendered content.
    
        
    
        
        :param useCachedResult: 
            If <code>true</code>, multiple calls will not cause children to re-execute with the page's original
            :any:`System.Text.Encodings.Web.HtmlEncoder`\; returns cached content.
        
        :type useCachedResult: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
            public Task<TagHelperContent> GetChildContentAsync(bool useCachedResult)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync(System.Boolean, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Executes children asynchronously with the given <em>encoder</em> in scope and returns their
        rendered content.
    
        
    
        
        :param useCachedResult: 
            If <code>true</code>, multiple calls with the same :any:`System.Text.Encodings.Web.HtmlEncoder` will not cause children to
            re-execute; returns cached content.
        
        :type useCachedResult: System.Boolean
    
        
        :param encoder: 
            The :any:`System.Text.Encodings.Web.HtmlEncoder` to use when the page handles non- :any:`Microsoft.AspNetCore.Html.IHtmlContent` C# expressions.
            If <code>null</code>, executes children with the page's current :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
            public Task<TagHelperContent> GetChildContentAsync(bool useCachedResult, HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Executes children asynchronously with the given <em>encoder</em> in scope and returns their
        rendered content.
    
        
    
        
        :param encoder: 
            The :any:`System.Text.Encodings.Web.HtmlEncoder` to use when the page handles non- :any:`Microsoft.AspNetCore.Html.IHtmlContent` C# expressions.
            If <code>null</code>, executes children with the page's current :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
            public Task<TagHelperContent> GetChildContentAsync(HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Microsoft.AspNetCore.Html.IHtmlContentContainer.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            void IHtmlContentContainer.CopyTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Microsoft.AspNetCore.Html.IHtmlContentContainer.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            void IHtmlContentContainer.MoveTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Reinitialize(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode)
    
        
    
        
        Clears the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` and updates its state with the provided values.
    
        
    
        
        :param tagName: The tag name to use.
        
        :type tagName: System.String
    
        
        :param tagMode: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.TagMode` to use.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            public void Reinitialize(string tagName, TagMode tagMode)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.SuppressOutput()
    
        
    
        
        Changes :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` to generate nothing.
    
        
    
        
        .. code-block:: csharp
    
            public void SuppressOutput()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

