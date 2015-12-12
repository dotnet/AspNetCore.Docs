

IControllerFactory Interface
============================



.. contents:: 
   :local:



Summary
-------

Provides methods for creation and disposal of controllers.











Syntax
------

.. code-block:: csharp

   public interface IControllerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/IControllerFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.IControllerFactory.CreateController(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        Creates a new controller for the specified ``actionContext``.
    
        
        
        
        :param actionContext: for the action to execute.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Object
        :return: The controller.
    
        
        .. code-block:: csharp
    
           object CreateController(ActionContext actionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.IControllerFactory.ReleaseController(System.Object)
    
        
    
        Releases a controller instance.
    
        
        
        
        :param controller: The controller.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           void ReleaseController(object controller)
    

