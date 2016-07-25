

DataProtectorShim Class
=======================






Converts an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` to an 
:any:`Microsoft.Owin.Security.DataProtection.IDataProtector`\.


Namespace
    :dn:ns:`Microsoft.Owin.Security.Interop`
Assemblies
    * Microsoft.Owin.Security.Interop

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Owin.Security.Interop.DataProtectorShim`








Syntax
------

.. code-block:: csharp

    public sealed class DataProtectorShim : IDataProtector








.. dn:class:: Microsoft.Owin.Security.Interop.DataProtectorShim
    :hidden:

.. dn:class:: Microsoft.Owin.Security.Interop.DataProtectorShim

Constructors
------------

.. dn:class:: Microsoft.Owin.Security.Interop.DataProtectorShim
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Owin.Security.Interop.DataProtectorShim.DataProtectorShim(Microsoft.AspNetCore.DataProtection.IDataProtector)
    
        
    
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
            public DataProtectorShim(IDataProtector protector)
    

Methods
-------

.. dn:class:: Microsoft.Owin.Security.Interop.DataProtectorShim
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Owin.Security.Interop.DataProtectorShim.Protect(System.Byte[])
    
        
    
        
        :type userData: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Protect(byte[] userData)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.DataProtectorShim.Unprotect(System.Byte[])
    
        
    
        
        :type protectedData: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Unprotect(byte[] protectedData)
    

