

IKeyEscrowSink Interface
========================






The basic interface for implementing a key escrow sink.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IKeyEscrowSink








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink.Store(System.Guid, System.Xml.Linq.XElement)
    
        
    
        
        Stores the given key material to the escrow service.
    
        
    
        
        :param keyId: The id of the key being persisted to escrow.
        
        :type keyId: System.Guid
    
        
        :param element: The unencrypted XML element that comprises the key material.
        
        :type element: System.Xml.Linq.XElement
    
        
        .. code-block:: csharp
    
            void Store(Guid keyId, XElement element)
    

