

IDiaInjectedSource Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaInjectedSource





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaInjectedSource.cs>`_





.. dn:interface:: dia2.IDiaInjectedSource

Methods
-------

.. dn:interface:: dia2.IDiaInjectedSource
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaInjectedSource.get_source(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
    
        
        .. code-block:: csharp
    
           void get_source(uint cbData, out uint pcbData, out byte pbData)
    

Properties
----------

.. dn:interface:: dia2.IDiaInjectedSource
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaInjectedSource.crc
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint crc { get; }
    
    .. dn:property:: dia2.IDiaInjectedSource.fileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string fileName { get; }
    
    .. dn:property:: dia2.IDiaInjectedSource.length
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong length { get; }
    
    .. dn:property:: dia2.IDiaInjectedSource.objectFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string objectFileName { get; }
    
    .. dn:property:: dia2.IDiaInjectedSource.sourceCompression
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint sourceCompression { get; }
    
    .. dn:property:: dia2.IDiaInjectedSource.virtualFilename
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string virtualFilename { get; }
    

