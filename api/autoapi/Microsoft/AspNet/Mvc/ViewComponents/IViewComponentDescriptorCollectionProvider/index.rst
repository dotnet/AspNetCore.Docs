

IViewComponentDescriptorCollectionProvider Interface
====================================================



.. contents:: 
   :local:



Summary
-------

Provides the currently cached collection of :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.











Syntax
------

.. code-block:: csharp

   public interface IViewComponentDescriptorCollectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentDescriptorCollectionProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider.ViewComponents
    
        
    
        Returns the current cached :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection
    
        
        .. code-block:: csharp
    
           ViewComponentDescriptorCollection ViewComponents { get; }
    

