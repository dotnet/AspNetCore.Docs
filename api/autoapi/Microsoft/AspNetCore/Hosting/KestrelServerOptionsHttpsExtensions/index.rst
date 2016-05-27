

KestrelServerOptionsHttpsExtensions Class
=========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel.Https

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions`








Syntax
------

.. code-block:: csharp

    public class KestrelServerOptionsHttpsExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions, Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions)
    
        
    
        
        Configure Kestrel to use HTTPS.
    
        
    
        
        :param options: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions to configure.
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        :param httpsOptions: 
            Options to configure HTTPS.
        
        :type httpsOptions: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseHttps(KestrelServerOptions options, HttpsConnectionFilterOptions httpsOptions)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions, System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        
        Configure Kestrel to use HTTPS.
    
        
    
        
        :param options: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions to configure.
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        :param serverCertificate: 
            The X.509 certificate.
        
        :type serverCertificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseHttps(KestrelServerOptions options, X509Certificate2 serverCertificate)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions, System.String)
    
        
    
        
        Configure Kestrel to use HTTPS.
    
        
    
        
        :param options: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions to configure.
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        :param fileName: 
            The name of a certificate file, relative to the directory that contains the application content files.
        
        :type fileName: System.String
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseHttps(KestrelServerOptions options, string fileName)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsHttpsExtensions.UseHttps(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions, System.String, System.String)
    
        
    
        
        Configure Kestrel to use HTTPS.
    
        
    
        
        :param options: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions to configure.
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        :param fileName: 
            The name of a certificate file, relative to the directory that contains the application content files.
        
        :type fileName: System.String
    
        
        :param password: 
            The password required to access the X.509 certificate data.
        
        :type password: System.String
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseHttps(KestrelServerOptions options, string fileName, string password)
    

