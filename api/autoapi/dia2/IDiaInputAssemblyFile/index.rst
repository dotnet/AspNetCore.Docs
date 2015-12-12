

IDiaInputAssemblyFile Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaInputAssemblyFile





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaInputAssemblyFile.cs>`_





.. dn:interface:: dia2.IDiaInputAssemblyFile

Methods
-------

.. dn:interface:: dia2.IDiaInputAssemblyFile
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaInputAssemblyFile.get_version(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
    
        
        .. code-block:: csharp
    
           void get_version(uint cbData, out uint pcbData, out byte pbData)
    

Properties
----------

.. dn:interface:: dia2.IDiaInputAssemblyFile
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaInputAssemblyFile.fileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string fileName { get; }
    
    .. dn:property:: dia2.IDiaInputAssemblyFile.index
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint index { get; }
    
    .. dn:property:: dia2.IDiaInputAssemblyFile.pdbAvailableAtILMerge
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int pdbAvailableAtILMerge { get; }
    
    .. dn:property:: dia2.IDiaInputAssemblyFile.timeStamp
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint timeStamp { get; }
    
    .. dn:property:: dia2.IDiaInputAssemblyFile.uniqueId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint uniqueId { get; }
    

