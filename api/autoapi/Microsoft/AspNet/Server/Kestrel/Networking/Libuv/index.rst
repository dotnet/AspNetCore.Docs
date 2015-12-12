

Libuv Class
===========



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.Libuv`








Syntax
------

.. code-block:: csharp

   public class Libuv





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Networking/Libuv.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.Libuv()
    
        
    
        
        .. code-block:: csharp
    
           public Libuv()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.Check(System.Int32)
    
        
        
        
        :type statusCode: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Check(int statusCode)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.Check(System.Int32, out System.Exception)
    
        
        
        
        :type statusCode: System.Int32
        
        
        :type error: System.Exception
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Check(int statusCode, out Exception error)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.accept(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type server: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type client: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           public void accept(UvStreamHandle server, UvStreamHandle client)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.async_init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_async_cb)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_async_cb
    
        
        .. code-block:: csharp
    
           public void async_init(UvLoopHandle loop, UvAsyncHandle handle, Libuv.uv_async_cb cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.async_send(Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvAsyncHandle
    
        
        .. code-block:: csharp
    
           public void async_send(UvAsyncHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.buf_init(System.IntPtr, System.Int32)
    
        
        
        
        :type memory: System.IntPtr
        
        
        :type len: System.Int32
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t
    
        
        .. code-block:: csharp
    
           public Libuv.uv_buf_t buf_init(IntPtr memory, int len)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.close(Microsoft.AspNet.Server.Kestrel.Networking.UvHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_close_cb)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle
        
        
        :type close_cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_close_cb
    
        
        .. code-block:: csharp
    
           public void close(UvHandle handle, Libuv.uv_close_cb close_cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.close(System.IntPtr, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_close_cb)
    
        
        
        
        :type handle: System.IntPtr
        
        
        :type close_cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_close_cb
    
        
        .. code-block:: csharp
    
           public void close(IntPtr handle, Libuv.uv_close_cb close_cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.err_name(System.Int32)
    
        
        
        
        :type err: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string err_name(int err)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.handle_size(Microsoft.AspNet.Server.Kestrel.Networking.Libuv.HandleType)
    
        
        
        
        :type handleType: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.HandleType
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int handle_size(Libuv.HandleType handleType)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.ip4_addr(System.String, System.Int32, out Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr, out System.Exception)
    
        
        
        
        :type ip: System.String
        
        
        :type port: System.Int32
        
        
        :type addr: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr
        
        
        :type error: System.Exception
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ip4_addr(string ip, int port, out Libuv.sockaddr addr, out Exception error)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.ip6_addr(System.String, System.Int32, out Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr, out System.Exception)
    
        
        
        
        :type ip: System.String
        
        
        :type port: System.Int32
        
        
        :type addr: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr
        
        
        :type error: System.Exception
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ip6_addr(string ip, int port, out Libuv.sockaddr addr, out Exception error)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.listen(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_connection_cb)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type backlog: System.Int32
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_connection_cb
    
        
        .. code-block:: csharp
    
           public void listen(UvStreamHandle handle, int backlog, Libuv.uv_connection_cb cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.loop_close(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void loop_close(UvLoopHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.loop_init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void loop_init(UvLoopHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.loop_size()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int loop_size()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.pipe_bind(Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle, System.String)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
        
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public void pipe_bind(UvPipeHandle handle, string name)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.pipe_connect(Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest, Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle, System.String, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_connect_cb)
    
        
        
        
        :type req: Microsoft.AspNet.Server.Kestrel.Networking.UvConnectRequest
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
        
        
        :type name: System.String
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_connect_cb
    
        
        .. code-block:: csharp
    
           public void pipe_connect(UvConnectRequest req, UvPipeHandle handle, string name, Libuv.uv_connect_cb cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.pipe_init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle, System.Boolean)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
        
        
        :type ipc: System.Boolean
    
        
        .. code-block:: csharp
    
           public void pipe_init(UvLoopHandle loop, UvPipeHandle handle, bool ipc)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.pipe_pending_count(Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvPipeHandle
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int pipe_pending_count(UvPipeHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.read_start(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_alloc_cb, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_read_cb)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type alloc_cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_alloc_cb
        
        
        :type read_cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_read_cb
    
        
        .. code-block:: csharp
    
           public void read_start(UvStreamHandle handle, Libuv.uv_alloc_cb alloc_cb, Libuv.uv_read_cb read_cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.read_stop(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           public void read_stop(UvStreamHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.ref(Microsoft.AspNet.Server.Kestrel.Networking.UvHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle
    
        
        .. code-block:: csharp
    
           public void ref(UvHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.req_size(Microsoft.AspNet.Server.Kestrel.Networking.Libuv.RequestType)
    
        
        
        
        :type reqType: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.RequestType
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int req_size(Libuv.RequestType reqType)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.run(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, System.Int32)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type mode: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int run(UvLoopHandle handle, int mode)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.shutdown(Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_shutdown_cb)
    
        
        
        
        :type req: Microsoft.AspNet.Server.Kestrel.Networking.UvShutdownReq
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_shutdown_cb
    
        
        .. code-block:: csharp
    
           public void shutdown(UvShutdownReq req, UvStreamHandle handle, Libuv.uv_shutdown_cb cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.stop(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public void stop(UvLoopHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.strerror(System.Int32)
    
        
        
        
        :type err: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string strerror(int err)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.tcp_bind(Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle, ref Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr, System.Int32)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
        
        
        :type addr: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.sockaddr
        
        
        :type flags: System.Int32
    
        
        .. code-block:: csharp
    
           public void tcp_bind(UvTcpHandle handle, ref Libuv.sockaddr addr, int flags)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.tcp_init(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
    
        
        .. code-block:: csharp
    
           public void tcp_init(UvLoopHandle loop, UvTcpHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.tcp_nodelay(Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle, System.Boolean)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
        
        
        :type enable: System.Boolean
    
        
        .. code-block:: csharp
    
           public void tcp_nodelay(UvTcpHandle handle, bool enable)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.tcp_open(Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle, System.IntPtr)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvTcpHandle
        
        
        :type hSocket: System.IntPtr
    
        
        .. code-block:: csharp
    
           public void tcp_open(UvTcpHandle handle, IntPtr hSocket)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.try_write(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t[], System.Int32)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type bufs: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t[]
        
        
        :type nbufs: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int try_write(UvStreamHandle handle, Libuv.uv_buf_t[] bufs, int nbufs)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.unref(Microsoft.AspNet.Server.Kestrel.Networking.UvHandle)
    
        
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvHandle
    
        
        .. code-block:: csharp
    
           public void unref(UvHandle handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.walk(Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_walk_cb, System.IntPtr)
    
        
        
        
        :type loop: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
        
        
        :type walk_cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_walk_cb
        
        
        :type arg: System.IntPtr
    
        
        .. code-block:: csharp
    
           public void walk(UvLoopHandle loop, Libuv.uv_walk_cb walk_cb, IntPtr arg)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.write(Microsoft.AspNet.Server.Kestrel.Networking.UvRequest, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t*, System.Int32, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_write_cb)
    
        
        
        
        :type req: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type bufs: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t*
        
        
        :type nbufs: System.Int32
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_write_cb
    
        
        .. code-block:: csharp
    
           public void write(UvRequest req, UvStreamHandle handle, Libuv.uv_buf_t*bufs, int nbufs, Libuv.uv_write_cb cb)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.write2(Microsoft.AspNet.Server.Kestrel.Networking.UvRequest, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t*, System.Int32, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_write_cb)
    
        
        
        
        :type req: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest
        
        
        :type handle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type bufs: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_buf_t*
        
        
        :type nbufs: System.Int32
        
        
        :type sendHandle: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type cb: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.uv_write_cb
    
        
        .. code-block:: csharp
    
           public void write2(UvRequest req, UvStreamHandle handle, Libuv.uv_buf_t*bufs, int nbufs, UvStreamHandle sendHandle, Libuv.uv_write_cb cb)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv.IsWindows
    
        
    
        
        .. code-block:: csharp
    
           public bool IsWindows
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_accept
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvStreamHandle, UvStreamHandle, int> _uv_accept
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_async_init
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, UvAsyncHandle, Libuv.uv_async_cb, int> _uv_async_init
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_async_send
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvAsyncHandle, int> _uv_async_send
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_close
    
        
    
        
        .. code-block:: csharp
    
           protected Action<IntPtr, Libuv.uv_close_cb> _uv_close
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_err_name
    
        
    
        
        .. code-block:: csharp
    
           protected Func<int, IntPtr> _uv_err_name
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_handle_size
    
        
    
        
        .. code-block:: csharp
    
           protected Func<Libuv.HandleType, int> _uv_handle_size
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_ip4_addr
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv.uv_ip4_addr_func _uv_ip4_addr
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_ip6_addr
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv.uv_ip6_addr_func _uv_ip6_addr
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_listen
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvStreamHandle, int, Libuv.uv_connection_cb, int> _uv_listen
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_loop_close
    
        
    
        
        .. code-block:: csharp
    
           protected Func<IntPtr, int> _uv_loop_close
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_loop_init
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, int> _uv_loop_init
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_loop_size
    
        
    
        
        .. code-block:: csharp
    
           protected Func<int> _uv_loop_size
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_pipe_bind
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvPipeHandle, string, int> _uv_pipe_bind
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_pipe_connect
    
        
    
        
        .. code-block:: csharp
    
           protected Action<UvConnectRequest, UvPipeHandle, string, Libuv.uv_connect_cb> _uv_pipe_connect
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_pipe_init
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, UvPipeHandle, int, int> _uv_pipe_init
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_pipe_pending_count
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvPipeHandle, int> _uv_pipe_pending_count
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_read_start
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvStreamHandle, Libuv.uv_alloc_cb, Libuv.uv_read_cb, int> _uv_read_start
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_read_stop
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvStreamHandle, int> _uv_read_stop
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_ref
    
        
    
        
        .. code-block:: csharp
    
           protected Action<UvHandle> _uv_ref
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_req_size
    
        
    
        
        .. code-block:: csharp
    
           protected Func<Libuv.RequestType, int> _uv_req_size
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_run
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, int, int> _uv_run
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_shutdown
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvShutdownReq, UvStreamHandle, Libuv.uv_shutdown_cb, int> _uv_shutdown
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_stop
    
        
    
        
        .. code-block:: csharp
    
           protected Action<UvLoopHandle> _uv_stop
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_strerror
    
        
    
        
        .. code-block:: csharp
    
           protected Func<int, IntPtr> _uv_strerror
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_tcp_bind
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv.uv_tcp_bind_func _uv_tcp_bind
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_tcp_init
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, UvTcpHandle, int> _uv_tcp_init
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_tcp_nodelay
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvTcpHandle, int, int> _uv_tcp_nodelay
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_tcp_open
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvTcpHandle, IntPtr, int> _uv_tcp_open
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_try_write
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvStreamHandle, Libuv.uv_buf_t[], int, int> _uv_try_write
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_unref
    
        
    
        
        .. code-block:: csharp
    
           protected Action<UvHandle> _uv_unref
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_walk
    
        
    
        
        .. code-block:: csharp
    
           protected Func<UvLoopHandle, Libuv.uv_walk_cb, IntPtr, int> _uv_walk
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_write
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv.uv_write_func _uv_write
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.Libuv._uv_write2
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv.uv_write2_func _uv_write2
    

