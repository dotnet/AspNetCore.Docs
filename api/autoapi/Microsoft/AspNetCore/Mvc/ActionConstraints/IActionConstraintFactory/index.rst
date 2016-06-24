

IActionConstraintFactory Interface
==================================






A factory for :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ActionConstraints`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionConstraintFactory : IActionConstraintMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory.CreateInstance(System.IServiceProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.
    
        
    
        
        :param services: The per-request services.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint
        :return: An :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint`\.
    
        
        .. code-block:: csharp
    
            IActionConstraint CreateInstance(IServiceProvider services)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory.IsReusable
    
        
    
        
        Gets a value that indicates if the result of :dn:meth:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraintFactory.CreateInstance(System.IServiceProvider)`
        can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsReusable { get; }
    

