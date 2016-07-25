

ServiceBasedControllerActivator Class
=====================================






A :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` that retrieves controllers as services from the request's 
:any:`System.IServiceProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator`








Syntax
------

.. code-block:: csharp

    public class ServiceBasedControllerActivator : IControllerActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator.Create(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Create(ControllerContext actionContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator.Release(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void Release(ControllerContext context, object controller)
    

