

IDiaEnumSymbolsByAddr Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumSymbolsByAddr





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumSymbolsByAddr.cs>`_





.. dn:interface:: dia2.IDiaEnumSymbolsByAddr

Methods
-------

.. dn:interface:: dia2.IDiaEnumSymbolsByAddr
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.Clone(out dia2.IDiaEnumSymbolsByAddr)
    
        
        
        
        :type ppenum: dia2.IDiaEnumSymbolsByAddr
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumSymbolsByAddr ppenum)
    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.Next(System.UInt32, out dia2.IDiaSymbol, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaSymbol
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaSymbol rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.Prev(System.UInt32, out dia2.IDiaSymbol, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaSymbol
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Prev(uint celt, out IDiaSymbol rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.symbolByAddr(System.UInt32, System.UInt32)
    
        
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol symbolByAddr(uint isect, uint offset)
    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.symbolByRVA(System.UInt32)
    
        
        
        
        :type relativeVirtualAddress: System.UInt32
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol symbolByRVA(uint relativeVirtualAddress)
    
    .. dn:method:: dia2.IDiaEnumSymbolsByAddr.symbolByVA(System.UInt64)
    
        
        
        
        :type virtualAddress: System.UInt64
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol symbolByVA(ulong virtualAddress)
    

