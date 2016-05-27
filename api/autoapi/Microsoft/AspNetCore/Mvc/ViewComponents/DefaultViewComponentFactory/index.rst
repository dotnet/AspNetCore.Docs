

DefaultViewComponentFactory Class
=================================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentFactory : IViewComponentFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory.DefaultViewComponentFactory(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory`
    
        
    
        
        :param activator: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator` used to create new view component instances.
        
        :type activator: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentFactory(IViewComponentActivator activator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory.CreateViewComponent(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object CreateViewComponent(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory.ReleaseViewComponent(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        :type component: System.Object
    
        
        .. code-block:: csharp
    
            public void ReleaseViewComponent(ViewComponentContext context, object component)
    

