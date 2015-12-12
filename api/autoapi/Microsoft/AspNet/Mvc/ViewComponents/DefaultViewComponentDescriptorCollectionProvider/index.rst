

DefaultViewComponentDescriptorCollectionProvider Class
======================================================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentDescriptorCollectionProvider : IViewComponentDescriptorCollectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentDescriptorCollectionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider.DefaultViewComponentDescriptorCollectionProvider(Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider`\.
    
        
        
        
        :param descriptorProvider: The .
        
        :type descriptorProvider: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentDescriptorCollectionProvider(IViewComponentDescriptorProvider descriptorProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider.ViewComponents
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection
    
        
        .. code-block:: csharp
    
           public ViewComponentDescriptorCollection ViewComponents { get; }
    

