

IDiaSession Interface
=====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaSession





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaSession.cs>`_





.. dn:interface:: dia2.IDiaSession

Methods
-------

.. dn:interface:: dia2.IDiaSession
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaSession.addressForRVA(System.UInt32, out System.UInt32, out System.UInt32)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type pISect: System.UInt32
        
        
        :type pOffset: System.UInt32
    
        
        .. code-block:: csharp
    
           void addressForRVA(uint rva, out uint pISect, out uint pOffset)
    
    .. dn:method:: dia2.IDiaSession.addressForVA(System.UInt64, out System.UInt32, out System.UInt32)
    
        
        
        
        :type va: System.UInt64
        
        
        :type pISect: System.UInt32
        
        
        :type pOffset: System.UInt32
    
        
        .. code-block:: csharp
    
           void addressForVA(ulong va, out uint pISect, out uint pOffset)
    
    .. dn:method:: dia2.IDiaSession.findChildren(dia2.IDiaSymbol, dia2.SymTagEnum, System.String, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildren(IDiaSymbol parent, SymTagEnum symTag, string name, uint compareFlags, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findChildrenEx(dia2.IDiaSymbol, dia2.SymTagEnum, System.String, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenEx(IDiaSymbol parent, SymTagEnum symTag, string name, uint compareFlags, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findChildrenExByAddr(dia2.IDiaSymbol, dia2.SymTagEnum, System.String, System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByAddr(IDiaSymbol parent, SymTagEnum symTag, string name, uint compareFlags, uint isect, uint offset, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findChildrenExByRVA(dia2.IDiaSymbol, dia2.SymTagEnum, System.String, System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type rva: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByRVA(IDiaSymbol parent, SymTagEnum symTag, string name, uint compareFlags, uint rva, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findChildrenExByVA(dia2.IDiaSymbol, dia2.SymTagEnum, System.String, System.UInt32, System.UInt64, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type va: System.UInt64
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByVA(IDiaSymbol parent, SymTagEnum symTag, string name, uint compareFlags, ulong va, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findFile(dia2.IDiaSymbol, System.String, System.UInt32, out dia2.IDiaEnumSourceFiles)
    
        
        
        
        :type pCompiland: dia2.IDiaSymbol
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSourceFiles
    
        
        .. code-block:: csharp
    
           void findFile(IDiaSymbol pCompiland, string name, uint compareFlags, out IDiaEnumSourceFiles ppResult)
    
    .. dn:method:: dia2.IDiaSession.findFileById(System.UInt32, out dia2.IDiaSourceFile)
    
        
        
        
        :type uniqueId: System.UInt32
        
        
        :type ppResult: dia2.IDiaSourceFile
    
        
        .. code-block:: csharp
    
           void findFileById(uint uniqueId, out IDiaSourceFile ppResult)
    
    .. dn:method:: dia2.IDiaSession.findILOffsetsByAddr(System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findILOffsetsByAddr(uint isect, uint offset, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findILOffsetsByRVA(System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findILOffsetsByRVA(uint rva, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findILOffsetsByVA(System.UInt64, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type va: System.UInt64
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findILOffsetsByVA(ulong va, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInjectedSource(System.String, out dia2.IDiaEnumInjectedSources)
    
        
        
        
        :type srcFile: System.String
        
        
        :type ppResult: dia2.IDiaEnumInjectedSources
    
        
        .. code-block:: csharp
    
           void findInjectedSource(string srcFile, out IDiaEnumInjectedSources ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineFramesByAddr(dia2.IDiaSymbol, System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByAddr(IDiaSymbol parent, uint isect, uint offset, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineFramesByRVA(dia2.IDiaSymbol, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type rva: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByRVA(IDiaSymbol parent, uint rva, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineFramesByVA(dia2.IDiaSymbol, System.UInt64, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type va: System.UInt64
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByVA(IDiaSymbol parent, ulong va, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineeLines(dia2.IDiaSymbol, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLines(IDiaSymbol parent, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineeLinesByAddr(dia2.IDiaSymbol, System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByAddr(IDiaSymbol parent, uint isect, uint offset, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineeLinesByLinenum(dia2.IDiaSymbol, dia2.IDiaSourceFile, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type compiland: dia2.IDiaSymbol
        
        
        :type file: dia2.IDiaSourceFile
        
        
        :type linenum: System.UInt32
        
        
        :type column: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, uint linenum, uint column, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineeLinesByRVA(dia2.IDiaSymbol, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type rva: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByRVA(IDiaSymbol parent, uint rva, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineeLinesByVA(dia2.IDiaSymbol, System.UInt64, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type parent: dia2.IDiaSymbol
        
        
        :type va: System.UInt64
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByVA(IDiaSymbol parent, ulong va, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInlineesByName(System.String, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type name: System.String
        
        
        :type option: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineesByName(string name, uint option, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInputAssembly(System.UInt32, out dia2.IDiaInputAssemblyFile)
    
        
        
        
        :type index: System.UInt32
        
        
        :type ppResult: dia2.IDiaInputAssemblyFile
    
        
        .. code-block:: csharp
    
           void findInputAssembly(uint index, out IDiaInputAssemblyFile ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInputAssemblyById(System.UInt32, out dia2.IDiaInputAssemblyFile)
    
        
        
        
        :type uniqueId: System.UInt32
        
        
        :type ppResult: dia2.IDiaInputAssemblyFile
    
        
        .. code-block:: csharp
    
           void findInputAssemblyById(uint uniqueId, out IDiaInputAssemblyFile ppResult)
    
    .. dn:method:: dia2.IDiaSession.findInputAssemblyFiles(out dia2.IDiaEnumInputAssemblyFiles)
    
        
        
        
        :type ppResult: dia2.IDiaEnumInputAssemblyFiles
    
        
        .. code-block:: csharp
    
           void findInputAssemblyFiles(out IDiaEnumInputAssemblyFiles ppResult)
    
    .. dn:method:: dia2.IDiaSession.findLines(dia2.IDiaSymbol, dia2.IDiaSourceFile, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type compiland: dia2.IDiaSymbol
        
        
        :type file: dia2.IDiaSourceFile
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findLines(IDiaSymbol compiland, IDiaSourceFile file, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findLinesByAddr(System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type seg: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findLinesByAddr(uint seg, uint offset, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findLinesByLinenum(dia2.IDiaSymbol, dia2.IDiaSourceFile, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type compiland: dia2.IDiaSymbol
        
        
        :type file: dia2.IDiaSourceFile
        
        
        :type linenum: System.UInt32
        
        
        :type column: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, uint linenum, uint column, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findLinesByRVA(System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findLinesByRVA(uint rva, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findLinesByVA(System.UInt64, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type va: System.UInt64
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findLinesByVA(ulong va, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByAddr(System.UInt32, System.UInt32, dia2.SymTagEnum, out dia2.IDiaSymbol)
    
        
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void findSymbolByAddr(uint isect, uint offset, SymTagEnum symTag, out IDiaSymbol ppSymbol)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByRVA(System.UInt32, dia2.SymTagEnum, out dia2.IDiaSymbol)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void findSymbolByRVA(uint rva, SymTagEnum symTag, out IDiaSymbol ppSymbol)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByRVAEx(System.UInt32, dia2.SymTagEnum, out dia2.IDiaSymbol, out System.Int32)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
        
        
        :type displacement: System.Int32
    
        
        .. code-block:: csharp
    
           void findSymbolByRVAEx(uint rva, SymTagEnum symTag, out IDiaSymbol ppSymbol, out int displacement)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByToken(System.UInt32, dia2.SymTagEnum, out dia2.IDiaSymbol)
    
        
        
        
        :type token: System.UInt32
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void findSymbolByToken(uint token, SymTagEnum symTag, out IDiaSymbol ppSymbol)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByVA(System.UInt64, dia2.SymTagEnum, out dia2.IDiaSymbol)
    
        
        
        
        :type va: System.UInt64
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void findSymbolByVA(ulong va, SymTagEnum symTag, out IDiaSymbol ppSymbol)
    
    .. dn:method:: dia2.IDiaSession.findSymbolByVAEx(System.UInt64, dia2.SymTagEnum, out dia2.IDiaSymbol, out System.Int32)
    
        
        
        
        :type va: System.UInt64
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type ppSymbol: dia2.IDiaSymbol
        
        
        :type displacement: System.Int32
    
        
        .. code-block:: csharp
    
           void findSymbolByVAEx(ulong va, SymTagEnum symTag, out IDiaSymbol ppSymbol, out int displacement)
    
    .. dn:method:: dia2.IDiaSession.getEnumDebugStreams(out dia2.IDiaEnumDebugStreams)
    
        
        
        
        :type ppEnumDebugStreams: dia2.IDiaEnumDebugStreams
    
        
        .. code-block:: csharp
    
           void getEnumDebugStreams(out IDiaEnumDebugStreams ppEnumDebugStreams)
    
    .. dn:method:: dia2.IDiaSession.getEnumTables(out dia2.IDiaEnumTables)
    
        
        
        
        :type ppEnumTables: dia2.IDiaEnumTables
    
        
        .. code-block:: csharp
    
           void getEnumTables(out IDiaEnumTables ppEnumTables)
    
    .. dn:method:: dia2.IDiaSession.getExports(out dia2.IDiaEnumSymbols)
    
        
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void getExports(out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.getFuncMDTokenMap(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cb: System.UInt32
        
        
        :type pcb: System.UInt32
        
        
        :type pb: System.Byte
    
        
        .. code-block:: csharp
    
           void getFuncMDTokenMap(uint cb, out uint pcb, out byte pb)
    
    .. dn:method:: dia2.IDiaSession.getFuncMDTokenMapSize(out System.UInt32)
    
        
        
        
        :type pcb: System.UInt32
    
        
        .. code-block:: csharp
    
           void getFuncMDTokenMapSize(out uint pcb)
    
    .. dn:method:: dia2.IDiaSession.getFunctionFragments_RVA(System.UInt32, System.UInt32, System.UInt32, out System.UInt32, out System.UInt32)
    
        
        
        
        :type rvaFunc: System.UInt32
        
        
        :type cbFunc: System.UInt32
        
        
        :type cFragments: System.UInt32
        
        
        :type pRvaFragment: System.UInt32
        
        
        :type pLenFragment: System.UInt32
    
        
        .. code-block:: csharp
    
           void getFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint cFragments, out uint pRvaFragment, out uint pLenFragment)
    
    .. dn:method:: dia2.IDiaSession.getFunctionFragments_VA(System.UInt64, System.UInt32, System.UInt32, out System.UInt64, out System.UInt32)
    
        
        
        
        :type vaFunc: System.UInt64
        
        
        :type cbFunc: System.UInt32
        
        
        :type cFragments: System.UInt32
        
        
        :type pVaFragment: System.UInt64
        
        
        :type pLenFragment: System.UInt32
    
        
        .. code-block:: csharp
    
           void getFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint cFragments, out ulong pVaFragment, out uint pLenFragment)
    
    .. dn:method:: dia2.IDiaSession.getHeapAllocationSites(out dia2.IDiaEnumSymbols)
    
        
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void getHeapAllocationSites(out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSession.getNumberOfFunctionFragments_RVA(System.UInt32, System.UInt32, out System.UInt32)
    
        
        
        
        :type rvaFunc: System.UInt32
        
        
        :type cbFunc: System.UInt32
        
        
        :type pNumFragments: System.UInt32
    
        
        .. code-block:: csharp
    
           void getNumberOfFunctionFragments_RVA(uint rvaFunc, uint cbFunc, out uint pNumFragments)
    
    .. dn:method:: dia2.IDiaSession.getNumberOfFunctionFragments_VA(System.UInt64, System.UInt32, out System.UInt32)
    
        
        
        
        :type vaFunc: System.UInt64
        
        
        :type cbFunc: System.UInt32
        
        
        :type pNumFragments: System.UInt32
    
        
        .. code-block:: csharp
    
           void getNumberOfFunctionFragments_VA(ulong vaFunc, uint cbFunc, out uint pNumFragments)
    
    .. dn:method:: dia2.IDiaSession.getSymbolsByAddr(out dia2.IDiaEnumSymbolsByAddr)
    
        
        
        
        :type ppEnumbyAddr: dia2.IDiaEnumSymbolsByAddr
    
        
        .. code-block:: csharp
    
           void getSymbolsByAddr(out IDiaEnumSymbolsByAddr ppEnumbyAddr)
    
    .. dn:method:: dia2.IDiaSession.getTypeMDTokenMap(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cb: System.UInt32
        
        
        :type pcb: System.UInt32
        
        
        :type pb: System.Byte
    
        
        .. code-block:: csharp
    
           void getTypeMDTokenMap(uint cb, out uint pcb, out byte pb)
    
    .. dn:method:: dia2.IDiaSession.getTypeMDTokenMapSize(out System.UInt32)
    
        
        
        
        :type pcb: System.UInt32
    
        
        .. code-block:: csharp
    
           void getTypeMDTokenMapSize(out uint pcb)
    
    .. dn:method:: dia2.IDiaSession.symbolById(System.UInt32, out dia2.IDiaSymbol)
    
        
        
        
        :type id: System.UInt32
        
        
        :type ppSymbol: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void symbolById(uint id, out IDiaSymbol ppSymbol)
    
    .. dn:method:: dia2.IDiaSession.symsAreEquiv(dia2.IDiaSymbol, dia2.IDiaSymbol)
    
        
        
        
        :type symbolA: dia2.IDiaSymbol
        
        
        :type symbolB: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void symsAreEquiv(IDiaSymbol symbolA, IDiaSymbol symbolB)
    

Properties
----------

.. dn:interface:: dia2.IDiaSession
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaSession.globalScope
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol globalScope { get; }
    
    .. dn:property:: dia2.IDiaSession.loadAddress
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong loadAddress { get; set; }
    

