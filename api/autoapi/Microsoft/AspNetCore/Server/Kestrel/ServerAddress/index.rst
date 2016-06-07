

ServerAddress Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServerAddress`








Syntax
------

.. code-block:: csharp

    public class ServerAddress








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.Host
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.IsUnixPipe
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsUnixPipe
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PathBase
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.Port
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Port
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.UnixPipePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UnixPipePath
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.FromUrl(System.String)
    
        
    
        
        :type url: System.String
        :rtype: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
            public static ServerAddress FromUrl(string url)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.ServerAddress.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

