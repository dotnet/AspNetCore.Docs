

DefaultActionConstraintProvider Class
=====================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultActionConstraintProvider : IActionConstraintProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(ActionConstraintProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(ActionConstraintProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.DefaultActionConstraintProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

