

TagHelperOutput Class
=====================



.. contents:: 
   :local:



Summary
-------

Class used to represent the output of an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput`








Syntax
------

.. code-block:: csharp

   public class TagHelperOutput





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperOutput.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.TagHelperOutput(System.String, Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList, System.Func<System.Boolean, System.Threading.Tasks.Task<Microsoft.AspNet.Razor.TagHelpers.TagHelperContent>>)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput`\.
    
        
        
        
        :param tagName: The HTML element's tag name.
        
        :type tagName: System.String
        
        
        :param attributes: The HTML attributes.
        
        :type attributes: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
        
        
        :param getChildContentAsync: A delegate used to execute and retrieve the rendered child content
            asynchronously.
        
        :type getChildContentAsync: System.Func{System.Boolean,System.Threading.Tasks.Task{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}}
    
        
        .. code-block:: csharp
    
           public TagHelperOutput(string tagName, TagHelperAttributeList attributes, Func<bool, Task<TagHelperContent>> getChildContentAsync)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync()
    
        
    
        A delegate used to execute children asynchronously.
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
           public Task<TagHelperContent> GetChildContentAsync()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.GetChildContentAsync(System.Boolean)
    
        
    
        A delegate used to execute children asynchronously.
    
        
        
        
        :param useCachedResult: If true multiple calls to this method will not cause re-execution
            of child content; cached content will be returned.
        
        :type useCachedResult: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns content rendered by children.
    
        
        .. code-block:: csharp
    
           public Task<TagHelperContent> GetChildContentAsync(bool useCachedResult)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.SuppressOutput()
    
        
    
        Changes :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput` to generate nothing.
    
        
    
        
        .. code-block:: csharp
    
           public void SuppressOutput()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Attributes
    
        
    
        The HTML element's attributes.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeList Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Content
    
        
    
        The HTML element's main content.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.IsContentModified
    
        
    
        <c>true</c> if :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Content` has been set, <c>false</c> otherwise.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsContentModified { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.PostContent
    
        
    
        The HTML element's post content.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent PostContent { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.PostElement
    
        
    
        Content that follows the HTML element.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent PostElement { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.PreContent
    
        
    
        The HTML element's pre content.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent PreContent { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.PreElement
    
        
    
        Content that precedes the HTML element.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent PreElement { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.TagMode
    
        
    
        Syntax of the element in the generated HTML.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
           public TagMode TagMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.TagName
    
        
    
        The HTML element's tag name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; set; }
    

