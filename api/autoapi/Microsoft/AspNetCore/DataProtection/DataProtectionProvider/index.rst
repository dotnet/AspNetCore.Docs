

DataProtectionProvider Class
============================






Contains factory methods for creating an :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` where keys are stored
at a particular location on the file system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider`








Syntax
------

.. code-block:: csharp

    public class DataProtectionProvider








.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.IO.DirectoryInfo)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` given a location at which to store keys.
    
        
    
        
        :param keyDirectory: The :any:`System.IO.DirectoryInfo` in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(DirectoryInfo keyDirectory)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.IO.DirectoryInfo, System.Action<Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` given a location at which to store keys and an
        optional configuration callback.
    
        
    
        
        :param keyDirectory: The :any:`System.IO.DirectoryInfo` in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
    
        
        :param setupAction: An optional callback which provides further configuration of the data protection
            system. See :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder` for more information.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder<Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>}
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(DirectoryInfo keyDirectory, Action<IDataProtectionBuilder> setupAction)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.IO.DirectoryInfo, System.Action<Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>, System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` given a location at which to store keys, an
        optional configuration callback and a :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` used to encrypt the keys.
    
        
    
        
        :param keyDirectory: The :any:`System.IO.DirectoryInfo` in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
    
        
        :param setupAction: An optional callback which provides further configuration of the data protection
            system. See :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder` for more information.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder<Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>}
    
        
        :param certificate: The :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` to be used for encryption.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(DirectoryInfo keyDirectory, Action<IDataProtectionBuilder> setupAction, X509Certificate2 certificate)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.IO.DirectoryInfo, System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` given a location at which to store keys
        and a :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` used to encrypt the keys.
    
        
    
        
        :param keyDirectory: The :any:`System.IO.DirectoryInfo` in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
    
        
        :param certificate: The :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` to be used for encryption.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(DirectoryInfo keyDirectory, X509Certificate2 certificate)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` that store keys in a location based on
        the platform and operating system.
    
        
    
        
        :param applicationName: An identifier that uniquely discriminates this application from all other
            applications on the machine.
        
        :type applicationName: System.String
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(string applicationName)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionProvider.Create(System.String, System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.DataProtectionProvider` that store keys in a location based on
        the platform and operating system and uses the given :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` to encrypt the keys.
    
        
    
        
        :param applicationName: An identifier that uniquely discriminates this application from all other
            applications on the machine.
        
        :type applicationName: System.String
    
        
        :param certificate: The :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` to be used for encryption.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider Create(string applicationName, X509Certificate2 certificate)
    

