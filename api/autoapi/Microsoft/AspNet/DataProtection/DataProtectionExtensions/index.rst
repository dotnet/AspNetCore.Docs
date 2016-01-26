

DataProtectionExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

Helpful extension methods for data protection APIs.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionExtensions`








Syntax
------

.. code-block:: csharp

   public class DataProtectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.Abstractions/DataProtectionExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.CreateProtector(Microsoft.AspNet.DataProtection.IDataProtectionProvider, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.IDataProtector` given a list of purposes.
    
        
        
        
        :param provider: The  from which to generate the purpose chain.
        
        :type provider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :param purposes: The list of purposes which contribute to the purpose chain. This list must
            contain at least one element, and it may not contain null elements.
        
        :type purposes: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtector" /> tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
           public static IDataProtector CreateProtector(IDataProtectionProvider provider, IEnumerable<string> purposes)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.CreateProtector(Microsoft.AspNet.DataProtection.IDataProtectionProvider, System.String, System.String[])
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.IDataProtector` given a list of purposes.
    
        
        
        
        :param provider: The  from which to generate the purpose chain.
        
        :type provider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :param purpose: The primary purpose used to create the .
        
        :type purpose: System.String
        
        
        :param subPurposes: An optional list of secondary purposes which contribute to the purpose chain.
            If this list is provided it cannot contain null elements.
        
        :type subPurposes: System.String[]
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtector" /> tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
           public static IDataProtector CreateProtector(IDataProtectionProvider provider, string purpose, params string[] subPurposes)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.GetApplicationUniqueIdentifier(System.IServiceProvider)
    
        
    
        Returns a unique identifier for this application.
    
        
        
        
        :param services: The application-level .
        
        :type services: System.IServiceProvider
        :rtype: System.String
        :return: A unique application identifier, or null if <paramref name="services" /> is null
            or cannot provide a unique application identifier.
    
        
        .. code-block:: csharp
    
           public static string GetApplicationUniqueIdentifier(IServiceProvider services)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.GetDataProtectionProvider(System.IServiceProvider)
    
        
    
        Retrieves an :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider` from an :any:`System.IServiceProvider`\.
    
        
        
        
        :param services: The service provider from which to retrieve the .
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtectionProvider" />. This method is guaranteed never to return null.
    
        
        .. code-block:: csharp
    
           public static IDataProtectionProvider GetDataProtectionProvider(IServiceProvider services)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.GetDataProtector(System.IServiceProvider, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Retrieves an :any:`Microsoft.AspNet.DataProtection.IDataProtector` from an :any:`System.IServiceProvider` given a list of purposes.
    
        
        
        
        :param services: An  which contains the
            from which to generate the purpose chain.
        
        :type services: System.IServiceProvider
        
        
        :param purposes: The list of purposes which contribute to the purpose chain. This list must
            contain at least one element, and it may not contain null elements.
        
        :type purposes: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtector" /> tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
           public static IDataProtector GetDataProtector(IServiceProvider services, IEnumerable<string> purposes)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.GetDataProtector(System.IServiceProvider, System.String, System.String[])
    
        
    
        Retrieves an :any:`Microsoft.AspNet.DataProtection.IDataProtector` from an :any:`System.IServiceProvider` given a list of purposes.
    
        
        
        
        :param services: An  which contains the
            from which to generate the purpose chain.
        
        :type services: System.IServiceProvider
        
        
        :param purpose: The primary purpose used to create the .
        
        :type purpose: System.String
        
        
        :param subPurposes: An optional list of secondary purposes which contribute to the purpose chain.
            If this list is provided it cannot contain null elements.
        
        :type subPurposes: System.String[]
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtector" /> tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
           public static IDataProtector GetDataProtector(IServiceProvider services, string purpose, params string[] subPurposes)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.Protect(Microsoft.AspNet.DataProtection.IDataProtector, System.String)
    
        
    
        Cryptographically protects a piece of plaintext data.
    
        
        
        
        :param protector: The data protector to use for this operation.
        
        :type protector: Microsoft.AspNet.DataProtection.IDataProtector
        
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.String
        :rtype: System.String
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
           public static string Protect(IDataProtector protector, string plaintext)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionExtensions.Unprotect(Microsoft.AspNet.DataProtection.IDataProtector, System.String)
    
        
    
        Cryptographically unprotects a piece of protected data.
    
        
        
        
        :param protector: The data protector to use for this operation.
        
        :type protector: Microsoft.AspNet.DataProtection.IDataProtector
        
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.String
        :rtype: System.String
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
           public static string Unprotect(IDataProtector protector, string protectedData)
    

