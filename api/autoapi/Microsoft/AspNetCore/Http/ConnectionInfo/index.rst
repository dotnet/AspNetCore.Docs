

ConnectionInfo Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.ConnectionInfo`








Syntax
------

.. code-block:: csharp

    public abstract class ConnectionInfo








.. dn:class:: Microsoft.AspNetCore.Http.ConnectionInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.ConnectionInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.ConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.ConnectionInfo.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            public abstract X509Certificate2 ClientCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ConnectionInfo.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public abstract IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ConnectionInfo.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public abstract int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public abstract IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ConnectionInfo.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public abstract int RemotePort { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.ConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.ConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>}
    
        
        .. code-block:: csharp
    
            public abstract Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = null)
    

