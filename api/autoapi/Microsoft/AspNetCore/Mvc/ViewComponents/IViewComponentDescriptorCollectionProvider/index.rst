

IViewComponentDescriptorCollectionProvider Interface
====================================================






Provides the currently cached collection of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewComponentDescriptorCollectionProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider.ViewComponents
    
        
    
        
        Returns the current cached :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection
    
        
        .. code-block:: csharp
    
            ViewComponentDescriptorCollection ViewComponents { get; }
    

