

TagHelperScopeManager Class
===========================






Class that manages :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scopes.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager`








Syntax
------

.. code-block:: csharp

    public class TagHelperScopeManager








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager.TagHelperScopeManager(System.Action<System.Text.Encodings.Web.HtmlEncoder>, System.Func<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager`\.
    
        
    
        
        :param startTagHelperWritingScope: 
            A delegate used to start a writing scope in a Razor page and optionally override the page's 
            :any:`System.Text.Encodings.Web.HtmlEncoder` within that scope.
        
        :type startTagHelperWritingScope: System.Action<System.Action`1>{System.Text.Encodings.Web.HtmlEncoder<System.Text.Encodings.Web.HtmlEncoder>}
    
        
        :param endTagHelperWritingScope: A delegate used to end a writing scope in a Razor page.
        
        :type endTagHelperWritingScope: System.Func<System.Func`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent>}
    
        
        .. code-block:: csharp
    
            public TagHelperScopeManager(Action<HtmlEncoder> startTagHelperWritingScope, Func<TagHelperContent> endTagHelperWritingScope)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager.Begin(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagMode, System.String, System.Func<System.Threading.Tasks.Task>)
    
        
    
        
        Starts a :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scope.
    
        
    
        
        :param tagName: The HTML tag name that the scope is associated with.
        
        :type tagName: System.String
    
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        :param uniqueId: An identifier unique to the HTML element this scope is for.
        
        :type uniqueId: System.String
    
        
        :param executeChildContentAsync: A delegate used to execute the child content asynchronously.
        
        :type executeChildContentAsync: System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
        :rtype: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :return: A :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` to use.
    
        
        .. code-block:: csharp
    
            public TagHelperExecutionContext Begin(string tagName, TagMode tagMode, string uniqueId, Func<Task> executeChildContentAsync)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager.End()
    
        
    
        
        Ends a :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scope.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :return: If the current scope is nested, the parent :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext`\.
            <code>null</code> otherwise.
    
        
        .. code-block:: csharp
    
            public TagHelperExecutionContext End()
    

