

DefaultAntiforgeryTokenSerializer Class
=======================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer`








Syntax
------

.. code-block:: csharp

   public class DefaultAntiforgeryTokenSerializer : IAntiforgeryTokenSerializer





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/DefaultAntiforgeryTokenSerializer.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer.DefaultAntiforgeryTokenSerializer(Microsoft.AspNet.DataProtection.IDataProtectionProvider)
    
        
        
        
        :type provider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
    
        
        .. code-block:: csharp
    
           public DefaultAntiforgeryTokenSerializer(IDataProtectionProvider provider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer.Deserialize(System.String)
    
        
        
        
        :type serializedToken: System.String
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           public AntiforgeryToken Deserialize(string serializedToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer.Serialize(Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type token: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Serialize(AntiforgeryToken token)
    

