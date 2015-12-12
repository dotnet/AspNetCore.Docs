

IActionConstraintFactory Interface
==================================



.. contents:: 
   :local:



Summary
-------

A factory for :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.











Syntax
------

.. code-block:: csharp

   public interface IActionConstraintFactory : IActionConstraintMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/IActionConstraintFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraintFactory.CreateInstance(System.IServiceProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint`\.
    
        
        
        
        :param services: The per-request services.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint
        :return: An <see cref="T:Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint" />.
    
        
        .. code-block:: csharp
    
           IActionConstraint CreateInstance(IServiceProvider services)
    

