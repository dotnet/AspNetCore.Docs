

ControllerContext Class
=======================






The context associated with the current request for a controller.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ControllerContext`








Syntax
------

.. code-block:: csharp

    public class ControllerContext : ActionContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ControllerContext.ControllerContext()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ControllerContext`\.
    
        
    
        
        .. code-block:: csharp
    
            public ControllerContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ControllerContext.ControllerContext(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ControllerContext`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ControllerContext(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.ActionDescriptor
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor` associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    
        
        .. code-block:: csharp
    
            public ControllerActionDescriptor ActionDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.ValueProviderFactories
    
        
    
        
        Gets or sets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` instances for the current request.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        .. code-block:: csharp
    
            public virtual IList<IValueProviderFactory> ValueProviderFactories { get; set; }
    

