

IViewComponentResult Interface
==============================



.. contents:: 
   :local:



Summary
-------

Result type of a :any:`Microsoft.AspNet.Mvc.ViewComponent`\.











Syntax
------

.. code-block:: csharp

   public interface IViewComponentResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/IViewComponentResult.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.IViewComponentResult

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.IViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentResult.Execute(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Executes the result of a :any:`Microsoft.AspNet.Mvc.ViewComponent` using the specified ``context``.
    
        
        
        
        :param context: The  for the current component execution.
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.IViewComponentResult.ExecuteAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Asynchronously executes the result of a :any:`Microsoft.AspNet.Mvc.ViewComponent` using the specified
        ``context``.
    
        
        
        
        :param context: The  for the current component execution.
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous execution.
    
        
        .. code-block:: csharp
    
           Task ExecuteAsync(ViewComponentContext context)
    

