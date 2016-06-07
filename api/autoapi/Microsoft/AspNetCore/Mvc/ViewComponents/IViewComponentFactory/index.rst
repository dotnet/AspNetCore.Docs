

IViewComponentFactory Interface
===============================






Provides methods for creation and disposal of view components.


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

    public interface IViewComponentFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory.CreateViewComponent(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Creates a new controller for the specified <em>context</em>.
    
        
    
        
        :param context: :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the view component.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Object
        :return: The view component.
    
        
        .. code-block:: csharp
    
            object CreateViewComponent(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory.ReleaseViewComponent(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
    
        
        Releases a view component instance.
    
        
    
        
        :param context: The context associated with the <em>component</em>.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        :param component: The view component.
        
        :type component: System.Object
    
        
        .. code-block:: csharp
    
            void ReleaseViewComponent(ViewComponentContext context, object component)
    

