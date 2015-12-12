

IKeyEscrowSink Interface
========================



.. contents:: 
   :local:



Summary
-------

The basic interface for implementing a key escrow sink.











Syntax
------

.. code-block:: csharp

   public interface IKeyEscrowSink





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/KeyManagement/IKeyEscrowSink.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink.Store(System.Guid, System.Xml.Linq.XElement)
    
        
    
        Stores the given key material to the escrow service.
    
        
        
        
        :param keyId: The id of the key being persisted to escrow.
        
        :type keyId: System.Guid
        
        
        :param element: The unencrypted XML element that comprises the key material.
        
        :type element: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
           void Store(Guid keyId, XElement element)
    

