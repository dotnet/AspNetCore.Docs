

IViewComponentInvoker Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IViewComponentInvoker





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/IViewComponentInvoker.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker.Invoke(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           void Invoke(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker.InvokeAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task InvokeAsync(ViewComponentContext context)
    

