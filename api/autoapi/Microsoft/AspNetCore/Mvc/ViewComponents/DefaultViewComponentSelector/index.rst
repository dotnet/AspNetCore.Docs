

DefaultViewComponentSelector Class
==================================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentSelector : IViewComponentSelector








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector.DefaultViewComponentSelector(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector`\.
    
        
    
        
        :param descriptorProvider: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`\.
        
        :type descriptorProvider: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentSelector(IViewComponentDescriptorCollectionProvider descriptorProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector.SelectComponent(System.String)
    
        
    
        
        :type componentName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    
        
        .. code-block:: csharp
    
            public ViewComponentDescriptor SelectComponent(string componentName)
    

