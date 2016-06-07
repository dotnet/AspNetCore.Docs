

IControllerTypeProvider Interface
=================================






Provides methods for discovery of controller types.


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

    public interface IControllerTypeProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerTypeProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerTypeProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.IControllerTypeProvider.ControllerTypes
    
        
    
        
        Gets a :any:`System.Collections.Generic.IEnumerable\`1` of controller :any:`System.Reflection.TypeInfo`\s.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            IEnumerable<TypeInfo> ControllerTypes
            {
                get;
            }
    

