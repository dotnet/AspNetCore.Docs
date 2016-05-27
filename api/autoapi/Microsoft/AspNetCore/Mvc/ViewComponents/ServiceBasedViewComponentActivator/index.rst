

ServiceBasedViewComponentActivator Class
========================================






A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator` that retrieves view components as services from the request's
:any:`System.IServiceProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator`








Syntax
------

.. code-block:: csharp

    public class ServiceBasedViewComponentActivator : IViewComponentActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator.Create(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Create(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator.Release(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        :type viewComponent: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void Release(ViewComponentContext context, object viewComponent)
    

