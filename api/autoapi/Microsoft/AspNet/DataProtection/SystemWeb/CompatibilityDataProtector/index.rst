

CompatibilityDataProtector Class
================================



.. contents:: 
   :local:



Summary
-------

A :any:`System.Security.Cryptography.DataProtector` that can be used by ASP.NET 4.x to interact with ASP.NET 5's
DataProtection stack. This type is for internal use only and shouldn't be directly used by
developers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Security.Cryptography.DataProtector`
* :dn:cls:`Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector`








Syntax
------

.. code-block:: csharp

   public sealed class CompatibilityDataProtector : DataProtector





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection.SystemWeb/CompatibilityDataProtector.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.CompatibilityDataProtector(System.String, System.String, System.String[])
    
        
        
        
        :type applicationName: System.String
        
        
        :type primaryPurpose: System.String
        
        
        :type specificPurposes: System.String[]
    
        
        .. code-block:: csharp
    
           public CompatibilityDataProtector(string applicationName, string primaryPurpose, string[] specificPurposes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.IsReprotectRequired(System.Byte[])
    
        
        
        
        :type encryptedData: System.Byte[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsReprotectRequired(byte[] encryptedData)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderProtect(System.Byte[])
    
        
        
        
        :type userData: System.Byte[]
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           protected override byte[] ProviderProtect(byte[] userData)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderUnprotect(System.Byte[])
    
        
        
        
        :type encryptedData: System.Byte[]
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           protected override byte[] ProviderUnprotect(byte[] encryptedData)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.RunWithSuppressedPrimaryPurpose(System.Func<System.Object, System.Byte[], System.Byte[]>, System.Object, System.Byte[])
    
        
    
        Invokes a delegate where calls to :dn:meth:`Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderProtect(System.Byte[])`
        and :dn:meth:`Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderUnprotect(System.Byte[])` will ignore the primary
        purpose and instead use only the sub-purposes.
    
        
        
        
        :type callback: System.Func{System.Object,System.Byte[],System.Byte[]}
        
        
        :type state: System.Object
        
        
        :type input: System.Byte[]
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public static byte[] RunWithSuppressedPrimaryPurpose(Func<object, byte[], byte[]> callback, object state, byte[] input)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.SystemWeb.CompatibilityDataProtector.PrependHashedPurposeToPlaintext
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool PrependHashedPurposeToPlaintext { get; }
    

