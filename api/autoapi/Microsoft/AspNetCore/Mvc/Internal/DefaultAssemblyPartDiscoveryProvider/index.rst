

DefaultAssemblyPartDiscoveryProvider Class
==========================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultAssemblyPartDiscoveryProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultAssemblyPartDiscoveryProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultAssemblyPartDiscoveryProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultAssemblyPartDiscoveryProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultAssemblyPartDiscoveryProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultAssemblyPartDiscoveryProvider.DiscoverAssemblyParts(System.String)
    
        
    
        
        :type entryPointAssemblyName: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<ApplicationPart> DiscoverAssemblyParts(string entryPointAssemblyName)
    

