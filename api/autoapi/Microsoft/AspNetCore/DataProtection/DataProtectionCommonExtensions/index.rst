

DataProtectionCommonExtensions Class
====================================






Helpful extension methods for data protection APIs.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions`








Syntax
------

.. code-block:: csharp

    public class DataProtectionCommonExtensions








.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.CreateProtector(Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` given a list of purposes.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` from which to generate the purpose chain.
        
        :type provider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :param purposes: The list of purposes which contribute to the purpose chain. This list must
            contain at least one element, and it may not contain null elements.
        
        :type purposes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
            public static IDataProtector CreateProtector(this IDataProtectionProvider provider, IEnumerable<string> purposes)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.CreateProtector(Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, System.String, System.String[])
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` given a list of purposes.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` from which to generate the purpose chain.
        
        :type provider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :param purpose: The primary purpose used to create the :any:`Microsoft.AspNetCore.DataProtection.IDataProtector`\.
        
        :type purpose: System.String
    
        
        :param subPurposes: An optional list of secondary purposes which contribute to the purpose chain.
            If this list is provided it cannot contain null elements.
        
        :type subPurposes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
            public static IDataProtector CreateProtector(this IDataProtectionProvider provider, string purpose, params string[] subPurposes)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.GetDataProtectionProvider(System.IServiceProvider)
    
        
    
        
        Retrieves an :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` from an :any:`System.IServiceProvider`\.
    
        
    
        
        :param services: The service provider from which to retrieve the :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\. This method is guaranteed never to return null.
    
        
        .. code-block:: csharp
    
            public static IDataProtectionProvider GetDataProtectionProvider(this IServiceProvider services)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.GetDataProtector(System.IServiceProvider, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Retrieves an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` from an :any:`System.IServiceProvider` given a list of purposes.
    
        
    
        
        :param services: An :any:`System.IServiceProvider` which contains the :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`
            from which to generate the purpose chain.
        
        :type services: System.IServiceProvider
    
        
        :param purposes: The list of purposes which contribute to the purpose chain. This list must
            contain at least one element, and it may not contain null elements.
        
        :type purposes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
            public static IDataProtector GetDataProtector(this IServiceProvider services, IEnumerable<string> purposes)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.GetDataProtector(System.IServiceProvider, System.String, System.String[])
    
        
    
        
        Retrieves an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` from an :any:`System.IServiceProvider` given a list of purposes.
    
        
    
        
        :param services: An :any:`System.IServiceProvider` which contains the :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`
            from which to generate the purpose chain.
        
        :type services: System.IServiceProvider
    
        
        :param purpose: The primary purpose used to create the :any:`Microsoft.AspNetCore.DataProtection.IDataProtector`\.
        
        :type purpose: System.String
    
        
        :param subPurposes: An optional list of secondary purposes which contribute to the purpose chain.
            If this list is provided it cannot contain null elements.
        
        :type subPurposes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` tied to the provided purpose chain.
    
        
        .. code-block:: csharp
    
            public static IDataProtector GetDataProtector(this IServiceProvider services, string purpose, params string[] subPurposes)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.Protect(Microsoft.AspNetCore.DataProtection.IDataProtector, System.String)
    
        
    
        
        Cryptographically protects a piece of plaintext data.
    
        
    
        
        :param protector: The data protector to use for this operation.
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.String
        :rtype: System.String
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            public static string Protect(this IDataProtector protector, string plaintext)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.Unprotect(Microsoft.AspNetCore.DataProtection.IDataProtector, System.String)
    
        
    
        
        Cryptographically unprotects a piece of protected data.
    
        
    
        
        :param protector: The data protector to use for this operation.
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.String
        :rtype: System.String
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
            public static string Unprotect(this IDataProtector protector, string protectedData)
    

