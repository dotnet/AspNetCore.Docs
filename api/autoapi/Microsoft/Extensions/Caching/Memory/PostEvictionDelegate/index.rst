

PostEvictionDelegate Delegate
=============================






Signature of the callback which gets called when a cache entry expires.


Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public delegate void PostEvictionDelegate(object key, object value, EvictionReason reason, object state);








.. dn:delegate:: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
    :hidden:

.. dn:delegate:: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate

