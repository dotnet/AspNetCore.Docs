

uv_alloc_cb Delegate
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_alloc_cb(IntPtr server, int suggested_size, out Libuv.uv_buf_t buf);








.. dn:delegate:: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_alloc_cb
    :hidden:

.. dn:delegate:: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv.uv_alloc_cb

