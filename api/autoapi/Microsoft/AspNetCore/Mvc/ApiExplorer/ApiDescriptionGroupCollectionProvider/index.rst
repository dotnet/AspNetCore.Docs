

ApiDescriptionGroupCollectionProvider Class
===========================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider`








Syntax
------

.. code-block:: csharp

    public class ApiDescriptionGroupCollectionProvider : IApiDescriptionGroupCollectionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroupCollectionProvider(Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider`\.
    
        
    
        
        :param actionDescriptorCollectionProvider: 
            The :any:`Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider`\.
        
        :type actionDescriptorCollectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        :param apiDescriptionProviders: 
            The :any:`System.Collections.Generic.IEnumerable\`1`\.
        
        :type apiDescriptionProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider>}
    
        
        .. code-block:: csharp
    
            public ApiDescriptionGroupCollectionProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IEnumerable<IApiDescriptionProvider> apiDescriptionProviders)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    
        
        .. code-block:: csharp
    
            public ApiDescriptionGroupCollection ApiDescriptionGroups { get; }
    

