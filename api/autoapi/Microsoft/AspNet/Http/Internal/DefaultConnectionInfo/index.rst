

DefaultConnectionInfo Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.ConnectionInfo`
* :dn:cls:`Microsoft.AspNet.Http.Internal.DefaultConnectionInfo`








Syntax
------

.. code-block:: csharp

   public class DefaultConnectionInfo : ConnectionInfo, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/DefaultConnectionInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.DefaultConnectionInfo(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultConnectionInfo(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Security.Cryptography.X509Certificates.X509Certificate2}
    
        
        .. code-block:: csharp
    
           public override Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           public override X509Certificate2 ClientCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.IsLocal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsLocal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public override IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public override IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultConnectionInfo.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int RemotePort { get; set; }
    

