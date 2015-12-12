

IDiaEnumTables Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumTables





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumTables.cs>`_





.. dn:interface:: dia2.IDiaEnumTables

Methods
-------

.. dn:interface:: dia2.IDiaEnumTables
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumTables.Clone(out dia2.IDiaEnumTables)
    
        
        
        
        :type ppenum: dia2.IDiaEnumTables
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumTables ppenum)
    
    .. dn:method:: dia2.IDiaEnumTables.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumTables.Item(System.Object)
    
        
        
        
        :type index: System.Object
        :rtype: dia2.IDiaTable
    
        
        .. code-block:: csharp
    
           IDiaTable Item(object index)
    
    .. dn:method:: dia2.IDiaEnumTables.Next(System.UInt32, out dia2.IDiaTable, ref System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaTable
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaTable rgelt, ref uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumTables.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumTables.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumTables
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumTables.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

