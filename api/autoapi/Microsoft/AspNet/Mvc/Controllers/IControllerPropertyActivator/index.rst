

IControllerPropertyActivator Interface
======================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IControllerPropertyActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/IControllerPropertyActivator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator.Activate(Microsoft.AspNet.Mvc.ActionContext, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           void Activate(ActionContext actionContext, object controller)
    

