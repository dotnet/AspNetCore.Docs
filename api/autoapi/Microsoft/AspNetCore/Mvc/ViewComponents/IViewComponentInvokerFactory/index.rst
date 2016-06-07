

IViewComponentInvokerFactory Interface
======================================





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

    public interface IViewComponentInvokerFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory.CreateInstance(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker
    
        
        .. code-block:: csharp
    
            IViewComponentInvoker CreateInstance(ViewComponentContext context)
    

