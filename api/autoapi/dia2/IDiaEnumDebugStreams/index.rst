

IDiaEnumDebugStreams Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumDebugStreams





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumDebugStreams.cs>`_





.. dn:interface:: dia2.IDiaEnumDebugStreams

Methods
-------

.. dn:interface:: dia2.IDiaEnumDebugStreams
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumDebugStreams.Clone(out dia2.IDiaEnumDebugStreams)
    
        
        
        
        :type ppenum: dia2.IDiaEnumDebugStreams
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumDebugStreams ppenum)
    
    .. dn:method:: dia2.IDiaEnumDebugStreams.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumDebugStreams.Item(System.Object)
    
        
        
        
        :type index: System.Object
        :rtype: dia2.IDiaEnumDebugStreamData
    
        
        .. code-block:: csharp
    
           IDiaEnumDebugStreamData Item(object index)
    
    .. dn:method:: dia2.IDiaEnumDebugStreams.Next(System.UInt32, out dia2.IDiaEnumDebugStreamData, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaEnumDebugStreamData
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaEnumDebugStreamData rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumDebugStreams.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumDebugStreams.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumDebugStreams
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumDebugStreams.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

