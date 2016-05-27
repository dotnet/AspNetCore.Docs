

IControllerFactory Interface
============================






Provides methods for creation and disposal of controllers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IControllerFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory.CreateController(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        Creates a new controller for the specified <em>context</em>.
    
        
    
        
        :param context: :any:`Microsoft.AspNetCore.Mvc.ControllerContext` for the action to execute.
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Object
        :return: The controller.
    
        
        .. code-block:: csharp
    
            object CreateController(ControllerContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory.ReleaseController(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        Releases a controller instance.
    
        
    
        
        :param context: :any:`Microsoft.AspNetCore.Mvc.ControllerContext` for the executing action.
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :param controller: The controller.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            void ReleaseController(ControllerContext context, object controller)
    

