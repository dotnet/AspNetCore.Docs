

PostEvictionDelegate Delegate
=============================



.. contents:: 
   :local:



Summary
-------

Signature of the callback which gets called when a cache entry expires.











Syntax
------

.. code-block:: csharp

   public delegate void PostEvictionDelegate(object key, object value, EvictionReason reason, object state);





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Abstractions/PostEvictionDelegate.cs>`_





.. dn:delegate:: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate

