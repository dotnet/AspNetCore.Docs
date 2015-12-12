

IControllerTypeProvider Interface
=================================



.. contents:: 
   :local:



Summary
-------

Provides methods for discovery of controller types.











Syntax
------

.. code-block:: csharp

   public interface IControllerTypeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/IControllerTypeProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider.ControllerTypes
    
        
    
        Gets a :any:`System.Collections.Generic.IEnumerable\`1` of controller :any:`System.Reflection.TypeInfo`\s.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           IEnumerable<TypeInfo> ControllerTypes { get; }
    

