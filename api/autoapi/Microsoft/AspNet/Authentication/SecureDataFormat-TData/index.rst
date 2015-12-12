

SecureDataFormat<TData> Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.SecureDataFormat\<TData>`








Syntax
------

.. code-block:: csharp

   public class SecureDataFormat<TData> : ISecureDataFormat<TData>





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/DataHandler/SecureDataFormat.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>.SecureDataFormat(Microsoft.AspNet.Authentication.IDataSerializer<TData>, Microsoft.AspNet.DataProtection.IDataProtector)
    
        
        
        
        :type serializer: Microsoft.AspNet.Authentication.IDataSerializer{{TData}}
        
        
        :type protector: Microsoft.AspNet.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
           public SecureDataFormat(IDataSerializer<TData> serializer, IDataProtector protector)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>.Protect(TData)
    
        
        
        
        :type data: {TData}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protect(TData data)
    
    .. dn:method:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>.Protect(TData, System.String)
    
        
        
        
        :type data: {TData}
        
        
        :type purpose: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protect(TData data, string purpose)
    
    .. dn:method:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>.Unprotect(System.String)
    
        
        
        
        :type protectedText: System.String
        :rtype: {TData}
    
        
        .. code-block:: csharp
    
           public TData Unprotect(string protectedText)
    
    .. dn:method:: Microsoft.AspNet.Authentication.SecureDataFormat<TData>.Unprotect(System.String, System.String)
    
        
        
        
        :type protectedText: System.String
        
        
        :type purpose: System.String
        :rtype: {TData}
    
        
        .. code-block:: csharp
    
           public TData Unprotect(string protectedText, string purpose)
    

