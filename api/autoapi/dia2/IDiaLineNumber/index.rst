

IDiaLineNumber Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaLineNumber





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaLineNumber.cs>`_





.. dn:interface:: dia2.IDiaLineNumber

Properties
----------

.. dn:interface:: dia2.IDiaLineNumber
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaLineNumber.addressOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint addressOffset { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.addressSection
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint addressSection { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.columnNumber
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint columnNumber { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.columnNumberEnd
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint columnNumberEnd { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.compiland
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol compiland { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.compilandId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint compilandId { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.length
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint length { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.lineNumber
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint lineNumber { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.lineNumberEnd
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint lineNumberEnd { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.relativeVirtualAddress
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint relativeVirtualAddress { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.sourceFile
    
        
        :rtype: dia2.IDiaSourceFile
    
        
        .. code-block:: csharp
    
           IDiaSourceFile sourceFile { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.sourceFileId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint sourceFileId { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.statement
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int statement { get; }
    
    .. dn:property:: dia2.IDiaLineNumber.virtualAddress
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong virtualAddress { get; }
    

