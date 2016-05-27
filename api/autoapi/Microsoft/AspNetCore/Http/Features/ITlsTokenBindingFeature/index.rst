

ITlsTokenBindingFeature Interface
=================================






Provides information regarding TLS token binding parameters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITlsTokenBindingFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature.GetProvidedTokenBindingId()
    
        
    
        
        Gets the 'provided' token binding identifier associated with the request.
    
        
        :rtype: System.Byte<System.Byte>[]
        :return: The token binding identifier, or null if the client did not
            supply a 'provided' token binding or valid proof of possession of the
            associated private key. The caller should treat this identifier as an
            opaque blob and should not try to parse it.
    
        
        .. code-block:: csharp
    
            byte[] GetProvidedTokenBindingId()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature.GetReferredTokenBindingId()
    
        
    
        
        Gets the 'referred' token binding identifier associated with the request.
    
        
        :rtype: System.Byte<System.Byte>[]
        :return: The token binding identifier, or null if the client did not
            supply a 'referred' token binding or valid proof of possession of the
            associated private key. The caller should treat this identifier as an
            opaque blob and should not try to parse it.
    
        
        .. code-block:: csharp
    
            byte[] GetReferredTokenBindingId()
    

