

IDiaEnumSymbols Interface
=========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumSymbols





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumSymbols.cs>`_





.. dn:interface:: dia2.IDiaEnumSymbols

Methods
-------

.. dn:interface:: dia2.IDiaEnumSymbols
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumSymbols.Clone(out dia2.IDiaEnumSymbols)
    
        
        
        
        :type ppenum: dia2.IDiaEnumSymbols
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumSymbols ppenum)
    
    .. dn:method:: dia2.IDiaEnumSymbols.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumSymbols.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: dia2.IDiaSymbol
    
        
        .. code-block:: csharp
    
           IDiaSymbol Item(uint index)
    
    .. dn:method:: dia2.IDiaEnumSymbols.Next(System.UInt32, out dia2.IDiaSymbol, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaSymbol
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaSymbol rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumSymbols.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumSymbols.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumSymbols
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumSymbols.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

