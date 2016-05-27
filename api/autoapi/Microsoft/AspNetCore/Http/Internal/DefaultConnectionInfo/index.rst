

DefaultConnectionInfo Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.ConnectionInfo`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo`








Syntax
------

.. code-block:: csharp

    public class DefaultConnectionInfo : ConnectionInfo








.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            public override X509Certificate2 ClientCertificate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public override IPAddress LocalIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int LocalPort
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public override IPAddress RemoteIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int RemotePort
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.DefaultConnectionInfo(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public DefaultConnectionInfo(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>}
    
        
        .. code-block:: csharp
    
            public override Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.Initialize(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultConnectionInfo.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    

