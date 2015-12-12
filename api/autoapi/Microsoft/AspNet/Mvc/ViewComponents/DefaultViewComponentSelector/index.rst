

DefaultViewComponentSelector Class
==================================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentSelector : IViewComponentSelector





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentSelector.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector.DefaultViewComponentSelector(Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector`\.
    
        
        
        
        :param descriptorProvider: The .
        
        :type descriptorProvider: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentSelector(IViewComponentDescriptorCollectionProvider descriptorProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector.SelectComponent(System.String)
    
        
        
        
        :type componentName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
    
        
        .. code-block:: csharp
    
           public ViewComponentDescriptor SelectComponent(string componentName)
    

