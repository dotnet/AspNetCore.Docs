

ServerAddress Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServerAddress`








Syntax
------

.. code-block:: csharp

   public class ServerAddress





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/ServerAddress.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerAddress

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerAddress
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerAddress.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerAddress.FromUrl(System.String)
    
        
        
        
        :type url: System.String
        :rtype: Microsoft.AspNet.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
           public static ServerAddress FromUrl(string url)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerAddress.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerAddress.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerAddress
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.Host
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Host { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.IsUnixPipe
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsUnixPipe { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.Port
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Port { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Scheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServerAddress.UnixPipePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UnixPipePath { get; }
    

