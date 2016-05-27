

TagHelperExecutionContext Class
===============================






Class used to store information about a :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s execution lifetime.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext`








Syntax
------

.. code-block:: csharp

    public class TagHelperExecutionContext








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.ChildContentRetrieved
    
        
    
        
        Indicates if :dn:meth:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.GetChildContentAsync(System.Boolean,System.Text.Encodings.Web.HtmlEncoder)` has been called.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ChildContentRetrieved
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Context
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s context.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            public TagHelperContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Items
    
        
    
        
        Gets the collection of items used to communicate with other :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Items
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Output
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s output.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public TagHelperOutput Output
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagHelpers
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s that should be run.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper<Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper>}
    
        
        .. code-block:: csharp
    
            public IList<ITagHelper> TagHelpers
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagHelperExecutionContext(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode, System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String, System.Func<System.Threading.Tasks.Task>, System.Action<System.Text.Encodings.Web.HtmlEncoder>, System.Func<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext`\.
    
        
    
        
        :param tagName: The HTML tag name in the Razor source.
        
        :type tagName: System.String
    
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        :param items: The collection of items used to communicate with other 
            :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :param uniqueId: An identifier unique to the HTML element this context is for.
        
        :type uniqueId: System.String
    
        
        :param executeChildContentAsync: A delegate used to execute the child content asynchronously.
        
        :type executeChildContentAsync: System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :param startTagHelperWritingScope: 
            A delegate used to start a writing scope in a Razor page and optionally override the page's
            :any:`System.Text.Encodings.Web.HtmlEncoder` within that scope.
        
        :type startTagHelperWritingScope: System.Action<System.Action`1>{System.Text.Encodings.Web.HtmlEncoder<System.Text.Encodings.Web.HtmlEncoder>}
    
        
        :param endTagHelperWritingScope: A delegate used to end a writing scope in a Razor page.
        
        :type endTagHelperWritingScope: System.Func<System.Func`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
    
        
        .. code-block:: csharp
    
            public TagHelperExecutionContext(string tagName, TagMode tagMode, IDictionary<object, object> items, string uniqueId, Func<Task> executeChildContentAsync, Action<HtmlEncoder> startTagHelperWritingScope, Func<TagHelperContent> endTagHelperWritingScope)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Add(Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper)
    
        
    
        
        Tracks the given <em>tagHelper</em>.
    
        
    
        
        :param tagHelper: The tag helper to track.
        
        :type tagHelper: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper
    
        
        .. code-block:: csharp
    
            public void Add(ITagHelper tagHelper)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddHtmlAttribute(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        Tracks the HTML attribute.
    
        
    
        
        :param attribute: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to track.
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
            public void AddHtmlAttribute(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddHtmlAttribute(System.String, System.Object)
    
        
    
        
        Tracks the HTML attribute.
    
        
    
        
        :param name: The HTML attribute name.
        
        :type name: System.String
    
        
        :param value: The HTML attribute value.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void AddHtmlAttribute(string name, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddMinimizedHtmlAttribute(System.String)
    
        
    
        
        Tracks the minimized HTML attribute.
    
        
    
        
        :param name: The minimized HTML attribute name.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public void AddMinimizedHtmlAttribute(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddTagHelperAttribute(System.String, System.Object)
    
        
    
        
        Tracks the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` bound attribute.
    
        
    
        
        :param name: The bound attribute name.
        
        :type name: System.String
    
        
        :param value: The attribute value.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void AddTagHelperAttribute(string name, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Reinitialize(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode, System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String, System.Func<System.Threading.Tasks.Task>)
    
        
    
        
        Clears the :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` and updates its state with the provided values.
    
        
    
        
        :param tagName: The tag name to use.
        
        :type tagName: System.String
    
        
        :param tagMode: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagMode` to use.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        :param items: The :any:`System.Collections.Generic.IDictionary\`2` to use.
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :param uniqueId: The unique id to use.
        
        :type uniqueId: System.String
    
        
        :param executeChildContentAsync: The :any:`System.Func\`1` to use.
        
        :type executeChildContentAsync: System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public void Reinitialize(string tagName, TagMode tagMode, IDictionary<object, object> items, string uniqueId, Func<Task> executeChildContentAsync)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.SetOutputContentAsync()
    
        
    
        
        Executes children asynchronously with the page's :any:`System.Text.Encodings.Web.HtmlEncoder` in scope and
        sets :dn:prop:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Output`\'s :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Content` to the rendered results.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion sets :dn:prop:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Output`\'s 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Content` to the children's rendered content.
    
        
        .. code-block:: csharp
    
            public Task SetOutputContentAsync()
    

