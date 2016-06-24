

DefaultViewComponentDescriptorCollectionProvider Class
======================================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentDescriptorCollectionProvider : IViewComponentDescriptorCollectionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider.DefaultViewComponentDescriptorCollectionProvider(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider`\.
    
        
    
        
        :param descriptorProvider: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider`\.
        
        :type descriptorProvider: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentDescriptorCollectionProvider(IViewComponentDescriptorProvider descriptorProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider.ViewComponents
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection
    
        
        .. code-block:: csharp
    
            public ViewComponentDescriptorCollection ViewComponents { get; }
    

