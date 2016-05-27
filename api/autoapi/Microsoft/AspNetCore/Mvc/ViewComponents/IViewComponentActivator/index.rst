

IViewComponentActivator Interface
=================================






Provides methods to instantiate and release a ViewComponent.


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

    public interface IViewComponentActivator








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator.Create(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Instantiates a ViewComponent.
    
        
    
        
        :param context: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the executing :any:`Microsoft.AspNetCore.Mvc.ViewComponent`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object Create(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator.Release(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
    
        
        Releases a ViewComponent instance.
    
        
    
        
        :param context: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` associated with the <em>viewComponent</em>.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        :param viewComponent: The :any:`Microsoft.AspNetCore.Mvc.ViewComponent` to release.
        
        :type viewComponent: System.Object
    
        
        .. code-block:: csharp
    
            void Release(ViewComponentContext context, object viewComponent)
    

