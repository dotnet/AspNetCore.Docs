

IDiaTable Interface
===================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaTable : IEnumUnknown





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaTable.cs>`_





.. dn:interface:: dia2.IDiaTable

Methods
-------

.. dn:interface:: dia2.IDiaTable
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaTable.Clone(out dia2.IEnumUnknown)
    
        
        
        
        :type ppenum: dia2.IEnumUnknown
    
        
        .. code-block:: csharp
    
           void Clone(out IEnumUnknown ppenum)
    
    .. dn:method:: dia2.IDiaTable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaTable.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object Item(uint index)
    
    .. dn:method:: dia2.IDiaTable.RemoteNext(System.UInt32, out System.Object, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: System.Object
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteNext(uint celt, out object rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaTable.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaTable.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaTable
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaTable.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    
    .. dn:property:: dia2.IDiaTable.name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string name { get; }
    

