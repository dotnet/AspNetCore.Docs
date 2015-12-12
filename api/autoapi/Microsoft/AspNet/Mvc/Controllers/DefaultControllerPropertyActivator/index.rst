

DefaultControllerPropertyActivator Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator`








Syntax
------

.. code-block:: csharp

   public class DefaultControllerPropertyActivator : IControllerPropertyActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/DefaultControllerPropertyActivator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator.DefaultControllerPropertyActivator(Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor)
    
        
        
        
        :type actionBindingContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor
    
        
        .. code-block:: csharp
    
           public DefaultControllerPropertyActivator(IActionBindingContextAccessor actionBindingContextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator.Activate(Microsoft.AspNet.Mvc.ActionContext, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public void Activate(ActionContext actionContext, object controller)
    

