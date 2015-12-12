

TagHelperScopeManager Class
===========================



.. contents:: 
   :local:



Summary
-------

Class that manages :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scopes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager`








Syntax
------

.. code-block:: csharp

   public class TagHelperScopeManager





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperScopeManager.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager.TagHelperScopeManager()
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager`\.
    
        
    
        
        .. code-block:: csharp
    
           public TagHelperScopeManager()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager.Begin(System.String, Microsoft.AspNet.Razor.TagHelpers.TagMode, System.String, System.Func<System.Threading.Tasks.Task>, System.Action, System.Func<Microsoft.AspNet.Razor.TagHelpers.TagHelperContent>)
    
        
    
        Starts a :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scope.
    
        
        
        
        :param tagName: The HTML tag name that the scope is associated with.
        
        :type tagName: System.String
        
        
        :param tagMode: HTML syntax of the element in the Razor source.
        
        :type tagMode: Microsoft.AspNet.Razor.TagHelpers.TagMode
        
        
        :param uniqueId: An identifier unique to the HTML element this scope is for.
        
        :type uniqueId: System.String
        
        
        :param executeChildContentAsync: A delegate used to execute the child content asynchronously.
        
        :type executeChildContentAsync: System.Func{System.Threading.Tasks.Task}
        
        
        :param startTagHelperWritingScope: A delegate used to start a writing scope in a Razor page.
        
        :type startTagHelperWritingScope: System.Action
        
        
        :param endTagHelperWritingScope: A delegate used to end a writing scope in a Razor page.
        
        :type endTagHelperWritingScope: System.Func{Microsoft.AspNet.Razor.TagHelpers.TagHelperContent}
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :return: A <see cref="T:Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext" /> to use.
    
        
        .. code-block:: csharp
    
           public TagHelperExecutionContext Begin(string tagName, TagMode tagMode, string uniqueId, Func<Task> executeChildContentAsync, Action startTagHelperWritingScope, Func<TagHelperContent> endTagHelperWritingScope)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager.End()
    
        
    
        Ends a :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scope.
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :return: If the current scope is nested, the parent <see cref="T:Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext" />.
            <c>null</c> otherwise.
    
        
        .. code-block:: csharp
    
           public TagHelperExecutionContext End()
    

