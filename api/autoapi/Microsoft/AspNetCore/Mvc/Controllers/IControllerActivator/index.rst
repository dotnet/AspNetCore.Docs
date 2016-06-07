

IControllerActivator Interface
==============================






Provides methods to create a controller.


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

    public interface IControllerActivator








.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator.Create(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        Creates a controller.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ControllerContext` for the executing action.
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object Create(ControllerContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator.Release(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        Releases a controller.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ControllerContext` for the executing action.
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :param controller: The controller to release.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            void Release(ControllerContext context, object controller)
    

