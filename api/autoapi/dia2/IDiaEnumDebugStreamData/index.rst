

IDiaEnumDebugStreamData Interface
=================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumDebugStreamData





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumDebugStreamData.cs>`_





.. dn:interface:: dia2.IDiaEnumDebugStreamData

Methods
-------

.. dn:interface:: dia2.IDiaEnumDebugStreamData
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.Clone(out dia2.IDiaEnumDebugStreamData)
    
        
        
        
        :type ppenum: dia2.IDiaEnumDebugStreamData
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumDebugStreamData ppenum)
    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.Item(System.UInt32, System.UInt32, out System.UInt32, out System.Byte)
    
        
        
        
        :type index: System.UInt32
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
    
        
        .. code-block:: csharp
    
           void Item(uint index, uint cbData, out uint pcbData, out byte pbData)
    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.Next(System.UInt32, System.UInt32, out System.UInt32, out System.Byte, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type cbData: System.UInt32
        
        
        :type pcbData: System.UInt32
        
        
        :type pbData: System.Byte
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, uint cbData, out uint pcbData, out byte pbData, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumDebugStreamData.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumDebugStreamData
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumDebugStreamData.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    
    .. dn:property:: dia2.IDiaEnumDebugStreamData.name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string name { get; }
    

