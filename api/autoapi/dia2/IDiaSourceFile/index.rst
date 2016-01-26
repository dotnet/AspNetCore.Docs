

IDiaSourceFile Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaSourceFile





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaSourceFile.cs>`_





.. dn:interface:: dia2.IDiaSourceFile

Methods
-------

.. dn:interface:: dia2.IDiaSourceFile
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaSourceFile.get_checksum(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
    
        
        .. code-block:: csharp
    
           void get_checksum(uint cbData, out uint pcbData, out byte pbData)
    

Properties
----------

.. dn:interface:: dia2.IDiaSourceFile
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaSourceFile.checksumType
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint checksumType { get; }
    
    .. dn:property:: dia2.IDiaSourceFile.compilands
    
        
        :rtype: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           IDiaEnumSymbols compilands { get; }
    
    .. dn:property:: dia2.IDiaSourceFile.fileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string fileName { get; }
    
    .. dn:property:: dia2.IDiaSourceFile.uniqueId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint uniqueId { get; }
    

