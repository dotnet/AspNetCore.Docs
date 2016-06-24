

ICompilationReferencesProvider Interface
========================================






Exposes one or more reference paths from an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.


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

    public interface ICompilationReferencesProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.ICompilationReferencesProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.ICompilationReferencesProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.ICompilationReferencesProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationParts.ICompilationReferencesProvider.GetReferencePaths()
    
        
    
        
        Gets reference paths used to perform runtime compilation.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IEnumerable<string> GetReferencePaths()
    

