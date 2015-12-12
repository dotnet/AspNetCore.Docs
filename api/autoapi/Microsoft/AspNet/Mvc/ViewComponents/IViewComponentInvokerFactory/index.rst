

IViewComponentInvokerFactory Interface
======================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IViewComponentInvokerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentInvokerFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory.CreateInstance(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker
    
        
        .. code-block:: csharp
    
           IViewComponentInvoker CreateInstance(ViewComponentContext context)
    

