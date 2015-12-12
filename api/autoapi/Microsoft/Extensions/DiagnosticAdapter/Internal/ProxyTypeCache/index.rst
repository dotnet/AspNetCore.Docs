

ProxyTypeCache Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Concurrent.ConcurrentDictionary{System.Tuple{System.Type,System.Type},Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult}`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCache`








Syntax
------

.. code-block:: csharp

   public class ProxyTypeCache : ConcurrentDictionary<Tuple<Type, Type>, ProxyTypeCacheResult>, IDictionary<Tuple<Type, Type>, ProxyTypeCacheResult>, ICollection<KeyValuePair<Tuple<Type, Type>, ProxyTypeCacheResult>>, IEnumerable<KeyValuePair<Tuple<Type, Type>, ProxyTypeCacheResult>>, IDictionary, ICollection, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyTypeCache.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCache

