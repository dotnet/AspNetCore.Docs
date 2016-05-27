

SecureDataFormat<TData> Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.SecureDataFormat\<TData>`








Syntax
------

.. code-block:: csharp

    public class SecureDataFormat<TData> : ISecureDataFormat<TData>








.. dn:class:: Microsoft.AspNetCore.Authentication.SecureDataFormat`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>.SecureDataFormat(Microsoft.AspNetCore.Authentication.IDataSerializer<TData>, Microsoft.AspNetCore.DataProtection.IDataProtector)
    
        
    
        
        :type serializer: Microsoft.AspNetCore.Authentication.IDataSerializer<Microsoft.AspNetCore.Authentication.IDataSerializer`1>{TData}
    
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
            public SecureDataFormat(IDataSerializer<TData> serializer, IDataProtector protector)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>.Protect(TData)
    
        
    
        
        :type data: TData
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protect(TData data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>.Protect(TData, System.String)
    
        
    
        
        :type data: TData
    
        
        :type purpose: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protect(TData data, string purpose)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>.Unprotect(System.String)
    
        
    
        
        :type protectedText: System.String
        :rtype: TData
    
        
        .. code-block:: csharp
    
            public TData Unprotect(string protectedText)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.SecureDataFormat<TData>.Unprotect(System.String, System.String)
    
        
    
        
        :type protectedText: System.String
    
        
        :type purpose: System.String
        :rtype: TData
    
        
        .. code-block:: csharp
    
            public TData Unprotect(string protectedText, string purpose)
    

