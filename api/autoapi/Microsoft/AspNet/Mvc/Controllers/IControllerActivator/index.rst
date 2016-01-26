

IControllerActivator Interface
==============================



.. contents:: 
   :local:



Summary
-------

Provides methods to create a controller.











Syntax
------

.. code-block:: csharp

   public interface IControllerActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/IControllerActivator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerActivator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.IControllerActivator.Create(Microsoft.AspNet.Mvc.ActionContext, System.Type)
    
        
    
        Creates a controller.
    
        
        
        
        :param context: The  for the executing action.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type controllerType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object Create(ActionContext context, Type controllerType)
    

