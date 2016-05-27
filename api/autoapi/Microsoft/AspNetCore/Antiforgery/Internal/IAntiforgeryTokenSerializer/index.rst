

IAntiforgeryTokenSerializer Interface
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAntiforgeryTokenSerializer








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer.Deserialize(System.String)
    
        
    
        
        :type serializedToken: System.String
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            AntiforgeryToken Deserialize(string serializedToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer.Serialize(Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        :type token: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Serialize(AntiforgeryToken token)
    

