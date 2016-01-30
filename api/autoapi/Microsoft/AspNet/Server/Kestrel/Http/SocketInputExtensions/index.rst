

SocketInputExtensions Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketInputExtensions`








Syntax
------

.. code-block:: csharp

   public class SocketInputExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/SocketInputExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInputExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketInputExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketInputExtensions.ReadAsync(Microsoft.AspNet.Server.Kestrel.Http.SocketInput, System.ArraySegment<System.Byte>)
    
        
        
        
        :type input: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
        
        
        :type buffer: System.ArraySegment{System.Byte}
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public static Task<int> ReadAsync(SocketInput input, ArraySegment<byte> buffer)
    

