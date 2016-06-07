

DefaultAntiforgeryTokenSerializer Class
=======================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer`








Syntax
------

.. code-block:: csharp

    public class DefaultAntiforgeryTokenSerializer : IAntiforgeryTokenSerializer








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer.DefaultAntiforgeryTokenSerializer(Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext>)
    
        
    
        
        :type provider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type pool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext<Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext>}
    
        
        .. code-block:: csharp
    
            public DefaultAntiforgeryTokenSerializer(IDataProtectionProvider provider, ObjectPool<AntiforgerySerializationContext> pool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer.Deserialize(System.String)
    
        
    
        
        :type serializedToken: System.String
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken Deserialize(string serializedToken)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer.Serialize(Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken)
    
        
    
        
        :type token: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Serialize(AntiforgeryToken token)
    

