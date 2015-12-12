

TagHelperExecutionContext Class
===============================



.. contents:: 
   :local:



Summary
-------

Class used to store information about a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s execution lifetime.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext`








Syntax
------

.. code-block:: csharp

   public class TagHelperExecutionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperExecutionContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagHelperExecutionContext(System.String, Microsoft.AspNet.Razor.TagHelpers.TagMode, System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String, System.Func<System.Threading.Tasks.Task>, System.Action, System.Func<Microsoft.AspNet.Razor.TagHelpers.TagHelperContent>)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext`\.
    
        
        
        
        :param tagName: The HTML tag name in the Razor source.
        
        :type tagName: System.String
        
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNet.Razor.TagHelpers.TagMode
        
        
        :param items: The collection of items used to communicate with other
            s
        
        :type items: System.Collections.Generic.IDictionary{System.Object,System.Object}
        
        
        :param uniqueId: An identifier unique to the HTML element this context is for.
        
        :type uniqueId: System.String
        
        
        :param executeChildContentAsync: A delegate used to execute the child content asynchronously.
        
        :type executeChildContentAsync: System.Func{System.Threading.Tasks.Task}
        
        
        :param startTagHelperWritingScope: A delegate used to start a writing scope in a Razor page.
        
        :type startTagHelperWritingScope: System.Action
        
        
        :param endTagHelperWritingScope: A delegate used to end a writing scope in a Razor page.
        
        :type endTagHelperWritingScope: System.Func{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}
    
        
        .. code-block:: csharp
    
           public TagHelperExecutionContext(string tagName, TagMode tagMode, IDictionary<object, object> items, string uniqueId, Func<Task> executeChildContentAsync, Action startTagHelperWritingScope, Func<TagHelperContent> endTagHelperWritingScope)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Add(Microsoft.AspNet.Razor.TagHelpers.ITagHelper)
    
        
    
        Tracks the given ``tagHelper``.
    
        
        
        
        :param tagHelper: The tag helper to track.
        
        :type tagHelper: Microsoft.AspNet.Razor.TagHelpers.ITagHelper
    
        
        .. code-block:: csharp
    
           public void Add(ITagHelper tagHelper)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddHtmlAttribute(System.String, System.Object)
    
        
    
        Tracks the HTML attribute in :dn:prop:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AllAttributes` and :dn:prop:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.HTMLAttributes`\.
    
        
        
        
        :param name: The HTML attribute name.
        
        :type name: System.String
        
        
        :param value: The HTML attribute value.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void AddHtmlAttribute(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddMinimizedHtmlAttribute(System.String)
    
        
    
        Tracks the minimized HTML attribute in :dn:prop:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AllAttributes` and :dn:prop:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.HTMLAttributes`\.
    
        
        
        
        :param name: The minimized HTML attribute name.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public void AddMinimizedHtmlAttribute(string name)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AddTagHelperAttribute(System.String, System.Object)
    
        
    
        Tracks the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` bound attribute in :dn:prop:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AllAttributes`\.
    
        
        
        
        :param name: The bound attribute name.
        
        :type name: System.String
        
        
        :param value: The attribute value.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void AddTagHelperAttribute(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.ExecuteChildContentAsync()
    
        
    
        Executes the child content asynchronously.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which on completion executes all child content.
    
        
        .. code-block:: csharp
    
           public Task ExecuteChildContentAsync()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.GetChildContentAsync(System.Boolean)
    
        
    
        Execute and retrieve the rendered child content asynchronously.
    
        
        
        
        :type useCachedResult: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns the rendered child content.
    
        
        .. code-block:: csharp
    
           public Task<TagHelperContent> GetChildContentAsync(bool useCachedResult)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.AllAttributes
    
        
    
        :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` bound attributes and HTML attributes.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeList AllAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.ChildContentRetrieved
    
        
    
        Indicates if :dn:meth:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.GetChildContentAsync(System.Boolean)` has been called.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ChildContentRetrieved { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.HTMLAttributes
    
        
    
        HTML attributes.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeList HTMLAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Items
    
        
    
        Gets the collection of items used to communicate with other :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.Output
    
        
    
        The :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s' output.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public TagHelperOutput Output { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagHelpers
    
        
    
        :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s that should be run.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.TagHelpers.ITagHelper}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ITagHelper> TagHelpers { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagMode
    
        
    
        Gets the HTML syntax of the element in the Razor source.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
           public TagMode TagMode { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.TagName
    
        
    
        The HTML tag name in the Razor source.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext.UniqueId
    
        
    
        An identifier unique to the HTML element this context is for.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UniqueId { get; }
    

