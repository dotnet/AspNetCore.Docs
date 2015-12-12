

IDiaEnumLineNumbers Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumLineNumbers





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumLineNumbers.cs>`_





.. dn:interface:: dia2.IDiaEnumLineNumbers

Methods
-------

.. dn:interface:: dia2.IDiaEnumLineNumbers
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumLineNumbers.Clone(out dia2.IDiaEnumLineNumbers)
    
        
        
        
        :type ppenum: dia2.IDiaEnumLineNumbers
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumLineNumbers ppenum)
    
    .. dn:method:: dia2.IDiaEnumLineNumbers.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumLineNumbers.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: dia2.IDiaLineNumber
    
        
        .. code-block:: csharp
    
           IDiaLineNumber Item(uint index)
    
    .. dn:method:: dia2.IDiaEnumLineNumbers.Next(System.UInt32, out dia2.IDiaLineNumber, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaLineNumber
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaLineNumber rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumLineNumbers.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumLineNumbers.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumLineNumbers
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumLineNumbers.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

