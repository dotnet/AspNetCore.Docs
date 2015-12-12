

ITlsTokenBindingFeature Interface
=================================



.. contents:: 
   :local:



Summary
-------

Provides information regarding TLS token binding parameters.











Syntax
------

.. code-block:: csharp

   public interface ITlsTokenBindingFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/ITlsTokenBindingFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.ITlsTokenBindingFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.ITlsTokenBindingFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.ITlsTokenBindingFeature.GetProvidedTokenBindingId()
    
        
    
        Gets the 'provided' token binding identifier associated with the request.
    
        
        :rtype: System.Byte[]
        :return: The token binding identifier, or null if the client did not
            supply a 'provided' token binding or valid proof of possession of the
            associated private key. The caller should treat this identifier as an
            opaque blob and should not try to parse it.
    
        
        .. code-block:: csharp
    
           byte[] GetProvidedTokenBindingId()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ITlsTokenBindingFeature.GetReferredTokenBindingId()
    
        
    
        Gets the 'referred' token binding identifier associated with the request.
    
        
        :rtype: System.Byte[]
        :return: The token binding identifier, or null if the client did not
            supply a 'referred' token binding or valid proof of possession of the
            associated private key. The caller should treat this identifier as an
            opaque blob and should not try to parse it.
    
        
        .. code-block:: csharp
    
           byte[] GetReferredTokenBindingId()
    

