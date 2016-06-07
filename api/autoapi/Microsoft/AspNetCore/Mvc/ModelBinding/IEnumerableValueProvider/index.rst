

IEnumerableValueProvider Interface
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IEnumerableValueProvider : IValueProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IEnumerableValueProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IEnumerableValueProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IEnumerableValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IEnumerableValueProvider.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IDictionary<string, string> GetKeysFromPrefix(string prefix)
    

