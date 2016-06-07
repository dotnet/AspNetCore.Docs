

ApiDescriptionProviderContext Class
===================================






A context object for :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` providers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext`








Syntax
------

.. code-block:: csharp

    public class ApiDescriptionProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext.Actions
    
        
    
        
        The list of actions.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ActionDescriptor> Actions
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext.Results
    
        
    
        
        The list of resulting :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription>}
    
        
        .. code-block:: csharp
    
            public IList<ApiDescription> Results
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext.ApiDescriptionProviderContext(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext`\.
    
        
    
        
        :param actions: The list of actions.
        
        :type actions: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>}
    
        
        .. code-block:: csharp
    
            public ApiDescriptionProviderContext(IReadOnlyList<ActionDescriptor> actions)
    

