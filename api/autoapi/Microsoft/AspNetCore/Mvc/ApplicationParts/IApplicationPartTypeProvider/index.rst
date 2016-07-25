

IApplicationPartTypeProvider Interface
======================================






Exposes a set of types from an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationParts`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationPartTypeProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationPartTypeProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationPartTypeProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationPartTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationPartTypeProvider.Types
    
        
    
        
        Gets the list of available types in the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            IEnumerable<TypeInfo> Types { get; }
    

