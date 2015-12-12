

IDiaSymbol Interface
====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaSymbol





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaSymbol.cs>`_





.. dn:interface:: dia2.IDiaSymbol

Methods
-------

.. dn:interface:: dia2.IDiaSymbol
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaSymbol.findChildren(dia2.SymTagEnum, System.String, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildren(SymTagEnum symTag, string name, uint compareFlags, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findChildrenEx(dia2.SymTagEnum, System.String, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenEx(SymTagEnum symTag, string name, uint compareFlags, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findChildrenExByAddr(dia2.SymTagEnum, System.String, System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByAddr(SymTagEnum symTag, string name, uint compareFlags, uint isect, uint offset, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findChildrenExByRVA(dia2.SymTagEnum, System.String, System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type rva: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByRVA(SymTagEnum symTag, string name, uint compareFlags, uint rva, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findChildrenExByVA(dia2.SymTagEnum, System.String, System.UInt32, System.UInt64, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type symTag: dia2.SymTagEnum
        
        
        :type name: System.String
        
        
        :type compareFlags: System.UInt32
        
        
        :type va: System.UInt64
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findChildrenExByVA(SymTagEnum symTag, string name, uint compareFlags, ulong va, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineFramesByAddr(System.UInt32, System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByAddr(uint isect, uint offset, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineFramesByRVA(System.UInt32, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByRVA(uint rva, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineFramesByVA(System.UInt64, out dia2.IDiaEnumSymbols)
    
        
        
        
        :type va: System.UInt64
        
        
        :type ppResult: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void findInlineFramesByVA(ulong va, out IDiaEnumSymbols ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineeLines(out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLines(out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineeLinesByAddr(System.UInt32, System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type isect: System.UInt32
        
        
        :type offset: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByAddr(uint isect, uint offset, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineeLinesByRVA(System.UInt32, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type rva: System.UInt32
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByRVA(uint rva, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.findInlineeLinesByVA(System.UInt64, System.UInt32, out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type va: System.UInt64
        
        
        :type length: System.UInt32
        
        
        :type ppResult: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void findInlineeLinesByVA(ulong va, uint length, out IDiaEnumLineNumbers ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.getSrcLineOnTypeDefn(out dia2.IDiaLineNumber)
    
        
        
        
        :type ppResult: dia2.IDiaLineNumber
    
        
        .. code-block:: csharp
    
           void getSrcLineOnTypeDefn(out IDiaLineNumber ppResult)
    
    .. dn:method:: dia2.IDiaSymbol.get_dataBytes(System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
    
        
        .. code-block:: csharp
    
           void get_dataBytes(uint cbData, out uint pcbData, out byte pbData)
    
    .. dn:method:: dia2.IDiaSymbol.get_modifierValues(System.UInt32, out System.UInt32, out System.UInt16)
    
        
        
        
        :type cnt: System.UInt32
        
        
        :type pcnt: System.UInt32
        
        
        :type pModifiers: System.UInt16
    
        
        .. code-block:: csharp
    
           void get_modifierValues(uint cnt, out uint pcnt, out ushort pModifiers)
    
    .. dn:method:: dia2.IDiaSymbol.get_numericProperties(System.UInt32, out System.UInt32, out System.UInt32)
    
        
        
        
        :type cnt: System.UInt32
        
        
        :type pcnt: System.UInt32
        
        
        :type pProperties: System.UInt32
    
        
        .. code-block:: csharp
    
           void get_numericProperties(uint cnt, out uint pcnt, out uint pProperties)
    
    .. dn:method:: dia2.IDiaSymbol.get_typeIds(System.UInt32, out System.UInt32, out System.UInt32)
    
        
        
        
        :type cTypeIds: System.UInt32
        
        
        :type pcTypeIds: System.UInt32
        
        
        :type pdwTypeIds: System.UInt32
    
        
        .. code-block:: csharp
    
           void get_typeIds(uint cTypeIds, out uint pcTypeIds, out uint pdwTypeIds)
    
    .. dn:method:: dia2.IDiaSymbol.get_types(System.UInt32, out System.UInt32, out dia2.IDiaSymbol)
    
        
        
        
        :type cTypes: System.UInt32
        
        
        :type pcTypes: System.UInt32
        
        
        :type pTypes: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           void get_types(uint cTypes, out uint pcTypes, out IDiaSymbol pTypes)
    
    .. dn:method:: dia2.IDiaSymbol.get_undecoratedNameEx(System.UInt32, out System.String)
    
        
        
        
        :type undecorateOptions: System.UInt32
        
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           void get_undecoratedNameEx(uint undecorateOptions, out string name)
    

Properties
----------

.. dn:interface:: dia2.IDiaSymbol
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaSymbol.PGODynamicInstructionCount
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong PGODynamicInstructionCount { get; }
    
    .. dn:property:: dia2.IDiaSymbol.PGOEdgeCount
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint PGOEdgeCount { get; }
    
    .. dn:property:: dia2.IDiaSymbol.PGOEntryCount
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint PGOEntryCount { get; }
    
    .. dn:property:: dia2.IDiaSymbol.RValueReference
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int RValueReference { get; }
    
    .. dn:property:: dia2.IDiaSymbol.access
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint access { get; }
    
    .. dn:property:: dia2.IDiaSymbol.addressOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint addressOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.addressSection
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint addressSection { get; }
    
    .. dn:property:: dia2.IDiaSymbol.addressTaken
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int addressTaken { get; }
    
    .. dn:property:: dia2.IDiaSymbol.age
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint age { get; }
    
    .. dn:property:: dia2.IDiaSymbol.arrayIndexType
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol arrayIndexType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.arrayIndexTypeId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint arrayIndexTypeId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.backEndBuild
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint backEndBuild { get; }
    
    .. dn:property:: dia2.IDiaSymbol.backEndMajor
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint backEndMajor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.backEndMinor
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint backEndMinor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.backEndQFE
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint backEndQFE { get; }
    
    .. dn:property:: dia2.IDiaSymbol.baseDataOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint baseDataOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.baseDataSlot
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint baseDataSlot { get; }
    
    .. dn:property:: dia2.IDiaSymbol.baseSymbol
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol baseSymbol { get; }
    
    .. dn:property:: dia2.IDiaSymbol.baseSymbolId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint baseSymbolId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.baseType
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint baseType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.bitPosition
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint bitPosition { get; }
    
    .. dn:property:: dia2.IDiaSymbol.builtInKind
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint builtInKind { get; }
    
    .. dn:property:: dia2.IDiaSymbol.callingConvention
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint callingConvention { get; }
    
    .. dn:property:: dia2.IDiaSymbol.classParent
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol classParent { get; }
    
    .. dn:property:: dia2.IDiaSymbol.classParentId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint classParentId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.code
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int code { get; }
    
    .. dn:property:: dia2.IDiaSymbol.compilerGenerated
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int compilerGenerated { get; }
    
    .. dn:property:: dia2.IDiaSymbol.compilerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string compilerName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.constType
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int constType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.constantExport
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int constantExport { get; }
    
    .. dn:property:: dia2.IDiaSymbol.constructor
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int constructor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.container
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol container { get; }
    
    .. dn:property:: dia2.IDiaSymbol.count
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint count { get; }
    
    .. dn:property:: dia2.IDiaSymbol.countLiveRanges
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint countLiveRanges { get; }
    
    .. dn:property:: dia2.IDiaSymbol.customCallingConvention
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int customCallingConvention { get; }
    
    .. dn:property:: dia2.IDiaSymbol.dataExport
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int dataExport { get; }
    
    .. dn:property:: dia2.IDiaSymbol.dataKind
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint dataKind { get; }
    
    .. dn:property:: dia2.IDiaSymbol.editAndContinueEnabled
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int editAndContinueEnabled { get; }
    
    .. dn:property:: dia2.IDiaSymbol.exportHasExplicitlyAssignedOrdinal
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int exportHasExplicitlyAssignedOrdinal { get; }
    
    .. dn:property:: dia2.IDiaSymbol.exportIsForwarder
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int exportIsForwarder { get; }
    
    .. dn:property:: dia2.IDiaSymbol.farReturn
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int farReturn { get; }
    
    .. dn:property:: dia2.IDiaSymbol.finalLiveStaticSize
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint finalLiveStaticSize { get; }
    
    .. dn:property:: dia2.IDiaSymbol.framePointerPresent
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int framePointerPresent { get; }
    
    .. dn:property:: dia2.IDiaSymbol.frontEndBuild
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint frontEndBuild { get; }
    
    .. dn:property:: dia2.IDiaSymbol.frontEndMajor
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint frontEndMajor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.frontEndMinor
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint frontEndMinor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.frontEndQFE
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint frontEndQFE { get; }
    
    .. dn:property:: dia2.IDiaSymbol.function
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int function { get; }
    
    .. dn:property:: dia2.IDiaSymbol.guid
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
           Guid guid { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasAlloca
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasAlloca { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasAssignmentOperator
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasAssignmentOperator { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasCastOperator
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasCastOperator { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasControlFlowCheck
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasControlFlowCheck { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasDebugInfo
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasDebugInfo { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasEH
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasEH { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasEHa
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasEHa { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasInlAsm
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasInlAsm { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasLongJump
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasLongJump { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasManagedCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasManagedCode { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasNestedTypes
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasNestedTypes { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasSEH
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasSEH { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasSecurityChecks
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasSecurityChecks { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasSetJump
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasSetJump { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hasValidPGOCounts
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hasValidPGOCounts { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hfaDouble
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hfaDouble { get; }
    
    .. dn:property:: dia2.IDiaSymbol.hfaFloat
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int hfaFloat { get; }
    
    .. dn:property:: dia2.IDiaSymbol.indirectVirtualBaseClass
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int indirectVirtualBaseClass { get; }
    
    .. dn:property:: dia2.IDiaSymbol.inlSpec
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int inlSpec { get; }
    
    .. dn:property:: dia2.IDiaSymbol.interruptReturn
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int interruptReturn { get; }
    
    .. dn:property:: dia2.IDiaSymbol.intrinsic
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int intrinsic { get; }
    
    .. dn:property:: dia2.IDiaSymbol.intro
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int intro { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isAggregated
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isAggregated { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isCTypes
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isCTypes { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isCVTCIL
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isCVTCIL { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isConstructorVirtualBase
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isConstructorVirtualBase { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isCxxReturnUdt
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isCxxReturnUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isDataAligned
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isDataAligned { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isHLSLData
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isHLSLData { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isHotpatchable
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isHotpatchable { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isInterfaceUdt
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isInterfaceUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isLTCG
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isLTCG { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isLocationControlFlowDependent
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isLocationControlFlowDependent { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isMSILNetmodule
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isMSILNetmodule { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isMatrixRowMajor
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isMatrixRowMajor { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isMultipleInheritance
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isMultipleInheritance { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isNaked
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isNaked { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isOptimizedAway
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isOptimizedAway { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isOptimizedForSpeed
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isOptimizedForSpeed { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isPGO
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isPGO { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isPointerBasedOnSymbolValue
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isPointerBasedOnSymbolValue { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isPointerToDataMember
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isPointerToDataMember { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isPointerToMemberFunction
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isPointerToMemberFunction { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isRefUdt
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isRefUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isReturnValue
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isReturnValue { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isSafeBuffers
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isSafeBuffers { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isSdl
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isSdl { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isSingleInheritance
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isSingleInheritance { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isSplitted
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isSplitted { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isStatic
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isStatic { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isStripped
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isStripped { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isValueUdt
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isValueUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isVirtualInheritance
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isVirtualInheritance { get; }
    
    .. dn:property:: dia2.IDiaSymbol.isWinRTPointer
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int isWinRTPointer { get; }
    
    .. dn:property:: dia2.IDiaSymbol.language
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint language { get; }
    
    .. dn:property:: dia2.IDiaSymbol.length
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong length { get; }
    
    .. dn:property:: dia2.IDiaSymbol.lexicalParent
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol lexicalParent { get; }
    
    .. dn:property:: dia2.IDiaSymbol.lexicalParentId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint lexicalParentId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.libraryName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string libraryName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.liveRangeLength
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong liveRangeLength { get; }
    
    .. dn:property:: dia2.IDiaSymbol.liveRangeStartAddressOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint liveRangeStartAddressOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.liveRangeStartAddressSection
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint liveRangeStartAddressSection { get; }
    
    .. dn:property:: dia2.IDiaSymbol.liveRangeStartRelativeVirtualAddress
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint liveRangeStartRelativeVirtualAddress { get; }
    
    .. dn:property:: dia2.IDiaSymbol.localBasePointerRegisterId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint localBasePointerRegisterId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.locationType
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint locationType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.lowerBound
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol lowerBound { get; }
    
    .. dn:property:: dia2.IDiaSymbol.lowerBoundId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint lowerBoundId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.machineType
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint machineType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.managed
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int managed { get; }
    
    .. dn:property:: dia2.IDiaSymbol.memorySpaceKind
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint memorySpaceKind { get; }
    
    .. dn:property:: dia2.IDiaSymbol.msil
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int msil { get; }
    
    .. dn:property:: dia2.IDiaSymbol.name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string name { get; }
    
    .. dn:property:: dia2.IDiaSymbol.nested
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int nested { get; }
    
    .. dn:property:: dia2.IDiaSymbol.noInline
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int noInline { get; }
    
    .. dn:property:: dia2.IDiaSymbol.noNameExport
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int noNameExport { get; }
    
    .. dn:property:: dia2.IDiaSymbol.noReturn
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int noReturn { get; }
    
    .. dn:property:: dia2.IDiaSymbol.noStackOrdering
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int noStackOrdering { get; }
    
    .. dn:property:: dia2.IDiaSymbol.notReached
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int notReached { get; }
    
    .. dn:property:: dia2.IDiaSymbol.numberOfColumns
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint numberOfColumns { get; }
    
    .. dn:property:: dia2.IDiaSymbol.numberOfModifiers
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint numberOfModifiers { get; }
    
    .. dn:property:: dia2.IDiaSymbol.numberOfRegisterIndices
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint numberOfRegisterIndices { get; }
    
    .. dn:property:: dia2.IDiaSymbol.numberOfRows
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint numberOfRows { get; }
    
    .. dn:property:: dia2.IDiaSymbol.objectFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string objectFileName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.objectPointerType
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol objectPointerType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.oemId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint oemId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.oemSymbolId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint oemSymbolId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.offset
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int offset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.offsetInUdt
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint offsetInUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.optimizedCodeDebugInfo
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int optimizedCodeDebugInfo { get; }
    
    .. dn:property:: dia2.IDiaSymbol.ordinal
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint ordinal { get; }
    
    .. dn:property:: dia2.IDiaSymbol.overloadedOperator
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int overloadedOperator { get; }
    
    .. dn:property:: dia2.IDiaSymbol.packed
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int packed { get; }
    
    .. dn:property:: dia2.IDiaSymbol.paramBasePointerRegisterId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint paramBasePointerRegisterId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.phaseName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string phaseName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.platform
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint platform { get; }
    
    .. dn:property:: dia2.IDiaSymbol.privateExport
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int privateExport { get; }
    
    .. dn:property:: dia2.IDiaSymbol.pure
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int pure { get; }
    
    .. dn:property:: dia2.IDiaSymbol.rank
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint rank { get; }
    
    .. dn:property:: dia2.IDiaSymbol.reference
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int reference { get; }
    
    .. dn:property:: dia2.IDiaSymbol.registerId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint registerId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.registerType
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint registerType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.relativeVirtualAddress
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint relativeVirtualAddress { get; }
    
    .. dn:property:: dia2.IDiaSymbol.restrictedType
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int restrictedType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.samplerSlot
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint samplerSlot { get; }
    
    .. dn:property:: dia2.IDiaSymbol.scoped
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int scoped { get; }
    
    .. dn:property:: dia2.IDiaSymbol.sealed
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int sealed { get; }
    
    .. dn:property:: dia2.IDiaSymbol.signature
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint signature { get; }
    
    .. dn:property:: dia2.IDiaSymbol.sizeInUdt
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint sizeInUdt { get; }
    
    .. dn:property:: dia2.IDiaSymbol.slot
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint slot { get; }
    
    .. dn:property:: dia2.IDiaSymbol.sourceFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string sourceFileName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.staticSize
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint staticSize { get; }
    
    .. dn:property:: dia2.IDiaSymbol.strictGSCheck
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int strictGSCheck { get; }
    
    .. dn:property:: dia2.IDiaSymbol.stride
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint stride { get; }
    
    .. dn:property:: dia2.IDiaSymbol.subType
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol subType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.subTypeId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint subTypeId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.symIndexId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint symIndexId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.symTag
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint symTag { get; }
    
    .. dn:property:: dia2.IDiaSymbol.symbolsFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string symbolsFileName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.targetOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint targetOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.targetRelativeVirtualAddress
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint targetRelativeVirtualAddress { get; }
    
    .. dn:property:: dia2.IDiaSymbol.targetSection
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint targetSection { get; }
    
    .. dn:property:: dia2.IDiaSymbol.targetVirtualAddress
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong targetVirtualAddress { get; }
    
    .. dn:property:: dia2.IDiaSymbol.textureSlot
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint textureSlot { get; }
    
    .. dn:property:: dia2.IDiaSymbol.thisAdjust
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int thisAdjust { get; }
    
    .. dn:property:: dia2.IDiaSymbol.thunkOrdinal
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint thunkOrdinal { get; }
    
    .. dn:property:: dia2.IDiaSymbol.timeStamp
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint timeStamp { get; }
    
    .. dn:property:: dia2.IDiaSymbol.token
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint token { get; }
    
    .. dn:property:: dia2.IDiaSymbol.type
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol type { get; }
    
    .. dn:property:: dia2.IDiaSymbol.typeId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint typeId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.uavSlot
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint uavSlot { get; }
    
    .. dn:property:: dia2.IDiaSymbol.udtKind
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint udtKind { get; }
    
    .. dn:property:: dia2.IDiaSymbol.unalignedType
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int unalignedType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.undecoratedName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string undecoratedName { get; }
    
    .. dn:property:: dia2.IDiaSymbol.unmodifiedType
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol unmodifiedType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.unmodifiedTypeId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint unmodifiedTypeId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.unused
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string unused { get; }
    
    .. dn:property:: dia2.IDiaSymbol.upperBound
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol upperBound { get; }
    
    .. dn:property:: dia2.IDiaSymbol.upperBoundId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint upperBoundId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object value { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtual
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int virtual { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualAddress
    
        
        :rtype: System.UInt64
    
        
        .. code-block:: csharp
    
           ulong virtualAddress { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualBaseClass
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int virtualBaseClass { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualBaseDispIndex
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint virtualBaseDispIndex { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualBaseOffset
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint virtualBaseOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualBasePointerOffset
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int virtualBasePointerOffset { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualBaseTableType
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol virtualBaseTableType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualTableShape
    
        
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol virtualTableShape { get; }
    
    .. dn:property:: dia2.IDiaSymbol.virtualTableShapeId
    
        
        :rtype: System.UInt32
    
        
        .. code-block:: csharp
    
           uint virtualTableShapeId { get; }
    
    .. dn:property:: dia2.IDiaSymbol.volatileType
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int volatileType { get; }
    
    .. dn:property:: dia2.IDiaSymbol.wasInlined
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int wasInlined { get; }
    

