

IAntiforgeryTokenSerializer Interface
=====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAntiforgeryTokenSerializer





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/IAntiforgeryTokenSerializer.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer.Deserialize(System.String)
    
        
        
        
        :type serializedToken: System.String
        :rtype: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    
        
        .. code-block:: csharp
    
           AntiforgeryToken Deserialize(string serializedToken)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer.Serialize(Microsoft.AspNet.Antiforgery.AntiforgeryToken)
    
        
        
        
        :type token: Microsoft.AspNet.Antiforgery.AntiforgeryToken
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Serialize(AntiforgeryToken token)
    

