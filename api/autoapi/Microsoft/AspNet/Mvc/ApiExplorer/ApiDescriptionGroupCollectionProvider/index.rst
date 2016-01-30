

ApiDescriptionGroupCollectionProvider Class
===========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider`








Syntax
------

.. code-block:: csharp

   public class ApiDescriptionGroupCollectionProvider : IApiDescriptionGroupCollectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescriptionGroupCollectionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroupCollectionProvider(Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider`\.
    
        
        
        
        :param actionDescriptorCollectionProvider: The .
        
        :type actionDescriptorCollectionProvider: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider
        
        
        :param apiDescriptionProviders: The .
        
        :type apiDescriptionProviders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider}
    
        
        .. code-block:: csharp
    
           public ApiDescriptionGroupCollectionProvider(IActionDescriptorsCollectionProvider actionDescriptorCollectionProvider, IEnumerable<IApiDescriptionProvider> apiDescriptionProviders)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups
    
        
        :rtype: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection
    
        
        .. code-block:: csharp
    
           public ApiDescriptionGroupCollection ApiDescriptionGroups { get; }
    

