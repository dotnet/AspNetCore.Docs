

ApiDescriptionProviderContext Class
===================================



.. contents:: 
   :local:



Summary
-------

A context object for :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription` providers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext`








Syntax
------

.. code-block:: csharp

   public class ApiDescriptionProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescriptionProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext.ApiDescriptionProviderContext(System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext`\.
    
        
        
        
        :param actions: The list of actions.
        
        :type actions: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           public ApiDescriptionProviderContext(IReadOnlyList<ActionDescriptor> actions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext.Actions
    
        
    
        The list of actions.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ActionDescriptor> Actions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext.Results
    
        
    
        The list of resulting :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`\.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription}
    
        
        .. code-block:: csharp
    
           public IList<ApiDescription> Results { get; }
    

