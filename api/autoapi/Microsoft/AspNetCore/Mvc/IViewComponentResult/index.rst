

IViewComponentResult Interface
==============================






Result type of a :any:`Microsoft.AspNetCore.Mvc.ViewComponent`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewComponentResult








.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentResult
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentResult

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IViewComponentResult.Execute(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Executes the result of a :any:`Microsoft.AspNetCore.Mvc.ViewComponent` using the specified <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the current component execution.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
            void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IViewComponentResult.ExecuteAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Asynchronously executes the result of a :any:`Microsoft.AspNetCore.Mvc.ViewComponent` using the specified
        <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the current component execution.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that represents the asynchronous execution.
    
        
        .. code-block:: csharp
    
            Task ExecuteAsync(ViewComponentContext context)
    

