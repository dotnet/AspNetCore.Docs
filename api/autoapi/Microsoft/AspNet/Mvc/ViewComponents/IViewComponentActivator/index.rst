

IViewComponentActivator Interface
=================================



.. contents:: 
   :local:



Summary
-------

Provides methods to activate an instantiated ViewComponent











Syntax
------

.. code-block:: csharp

   public interface IViewComponentActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentActivator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator.Activate(System.Object, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        When implemented in a type, activates an instantiated ViewComponent.
    
        
        
        
        :param viewComponent: The ViewComponent to activate.
        
        :type viewComponent: System.Object
        
        
        :param context: The  for the executing .
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           void Activate(object viewComponent, ViewComponentContext context)
    

