

IViewEngine Interface
=====================



.. contents:: 
   :local:



Summary
-------

Defines the contract for a view engine.











Syntax
------

.. code-block:: csharp

   public interface IViewEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewEngines/IViewEngine.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine.FindPartialView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
    
        Finds the specified partial view by using the specified action context.
    
        
        
        
        :param context: The action context.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param partialViewName: The name or full path to the view.
        
        :type partialViewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
        :return: A result representing the result of locating the view.
    
        
        .. code-block:: csharp
    
           ViewEngineResult FindPartialView(ActionContext context, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine.FindView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
    
        Finds the specified view by using the specified action context.
    
        
        
        
        :param context: The action context.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param viewName: The name or full path to the view.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
        :return: A result representing the result of locating the view.
    
        
        .. code-block:: csharp
    
           ViewEngineResult FindView(ActionContext context, string viewName)
    

