

CompatibilityDataProtector Class
================================






A :any:`System.Security.Cryptography.DataProtector` that can be used by ASP.NET 4.x to interact with ASP.NET Core's
DataProtection stack. This type is for internal use only and shouldn't be directly used by
developers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.SystemWeb`
Assemblies
    * Microsoft.AspNetCore.DataProtection.SystemWeb

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Security.Cryptography.DataProtector`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector`








Syntax
------

.. code-block:: csharp

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class CompatibilityDataProtector : DataProtector








.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.PrependHashedPurposeToPlaintext
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool PrependHashedPurposeToPlaintext
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.CompatibilityDataProtector(System.String, System.String, System.String[])
    
        
    
        
        :type applicationName: System.String
    
        
        :type primaryPurpose: System.String
    
        
        :type specificPurposes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public CompatibilityDataProtector(string applicationName, string primaryPurpose, string[] specificPurposes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.IsReprotectRequired(System.Byte[])
    
        
    
        
        :type encryptedData: System.Byte<System.Byte>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsReprotectRequired(byte[] encryptedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderProtect(System.Byte[])
    
        
    
        
        :type userData: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            protected override byte[] ProviderProtect(byte[] userData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderUnprotect(System.Byte[])
    
        
    
        
        :type encryptedData: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            protected override byte[] ProviderUnprotect(byte[] encryptedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.RunWithSuppressedPrimaryPurpose(System.Func<System.Object, System.Byte[], System.Byte[]>, System.Object, System.Byte[])
    
        
    
        
        Invokes a delegate where calls to :dn:meth:`Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderProtect(System.Byte[])`
        and :dn:meth:`Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector.ProviderUnprotect(System.Byte[])` will ignore the primary
        purpose and instead use only the sub-purposes.
    
        
    
        
        :type callback: System.Func<System.Func`3>{System.Object<System.Object>, System.Byte<System.Byte>[], System.Byte<System.Byte>[]}
    
        
        :type state: System.Object
    
        
        :type input: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] RunWithSuppressedPrimaryPurpose(Func<object, byte[], byte[]> callback, object state, byte[] input)
    

