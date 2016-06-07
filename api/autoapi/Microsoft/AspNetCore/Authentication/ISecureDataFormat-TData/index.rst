

ISecureDataFormat<TData> Interface
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISecureDataFormat<TData>








.. dn:interface:: Microsoft.AspNetCore.Authentication.ISecureDataFormat`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>.Protect(TData)
    
        
    
        
        :type data: TData
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Protect(TData data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>.Protect(TData, System.String)
    
        
    
        
        :type data: TData
    
        
        :type purpose: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Protect(TData data, string purpose)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>.Unprotect(System.String)
    
        
    
        
        :type protectedText: System.String
        :rtype: TData
    
        
        .. code-block:: csharp
    
            TData Unprotect(string protectedText)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ISecureDataFormat<TData>.Unprotect(System.String, System.String)
    
        
    
        
        :type protectedText: System.String
    
        
        :type purpose: System.String
        :rtype: TData
    
        
        .. code-block:: csharp
    
            TData Unprotect(string protectedText, string purpose)
    

