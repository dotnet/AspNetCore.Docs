

ISecureDataFormat<TData> Interface
==================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISecureDataFormat<TData>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/DataHandler/ISecureDataFormat.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>.Protect(TData)
    
        
        
        
        :type data: {TData}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Protect(TData data)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>.Protect(TData, System.String)
    
        
        
        
        :type data: {TData}
        
        
        :type purpose: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Protect(TData data, string purpose)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>.Unprotect(System.String)
    
        
        
        
        :type protectedText: System.String
        :rtype: {TData}
    
        
        .. code-block:: csharp
    
           TData Unprotect(string protectedText)
    
    .. dn:method:: Microsoft.AspNet.Authentication.ISecureDataFormat<TData>.Unprotect(System.String, System.String)
    
        
        
        
        :type protectedText: System.String
        
        
        :type purpose: System.String
        :rtype: {TData}
    
        
        .. code-block:: csharp
    
           TData Unprotect(string protectedText, string purpose)
    

