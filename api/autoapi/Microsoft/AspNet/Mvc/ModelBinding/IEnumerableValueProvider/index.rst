

IEnumerableValueProvider Interface
==================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IEnumerableValueProvider : IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/IEnumerableValueProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IEnumerableValueProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IEnumerableValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IEnumerableValueProvider.GetKeysFromPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           IDictionary<string, string> GetKeysFromPrefix(string prefix)
    

