

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

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.ActionDescriptor
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor` associated with the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor
    
        
        .. code-block:: csharp
    
            public ControllerActionDescriptor ActionDescriptor
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.InputFormatters
    
        
    
        
        Gets or sets the list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter` instances for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        .. code-block:: csharp
    
            public virtual FormatterCollection<IInputFormatter> InputFormatters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.ValidatorProviders
    
        
    
        
        Gets or sets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances for the current request.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public virtual IList<IModelValidatorProvider> ValidatorProviders
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerContext.ValueProviders
    
        
    
        
        Gets or sets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instances for the current request.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider>}
    
        
        .. code-block:: csharp
    
            public virtual IList<IValueProvider> ValueProviders
            {
                get;
                set;
            }
    

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
    

