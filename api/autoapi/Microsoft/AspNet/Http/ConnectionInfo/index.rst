

ConnectionInfo Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.ConnectionInfo`








Syntax
------

.. code-block:: csharp

   public abstract class ConnectionInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/ConnectionInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Http.ConnectionInfo

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.ConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.ConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Security.Cryptography.X509Certificates.X509Certificate2}
    
        
        .. code-block:: csharp
    
           public abstract Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.ConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           public abstract X509Certificate2 ClientCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.IsLocal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsLocal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public abstract IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public abstract int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public abstract IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.ConnectionInfo.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public abstract int RemotePort { get; set; }
    

