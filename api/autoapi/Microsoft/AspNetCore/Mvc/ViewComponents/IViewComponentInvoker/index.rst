

IViewComponentInvoker Interface
===============================






Specifies the contract for execution of a view component.


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

    public interface IViewComponentInvoker








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker.InvokeAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Executes the view component specified by :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewComponentDescriptor`
        of <em>context</em> and writes the result to :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.Writer`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that represents the asynchronous operation of execution.
    
        
        .. code-block:: csharp
    
            Task InvokeAsync(ViewComponentContext context)
    

