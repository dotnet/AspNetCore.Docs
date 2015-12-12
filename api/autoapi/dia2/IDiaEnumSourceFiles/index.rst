

IDiaEnumSourceFiles Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumSourceFiles





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumSourceFiles.cs>`_





.. dn:interface:: dia2.IDiaEnumSourceFiles

Methods
-------

.. dn:interface:: dia2.IDiaEnumSourceFiles
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumSourceFiles.Clone(out dia2.IDiaEnumSourceFiles)
    
        
        
        
        :type ppenum: dia2.IDiaEnumSourceFiles
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumSourceFiles ppenum)
    
    .. dn:method:: dia2.IDiaEnumSourceFiles.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumSourceFiles.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: dia2.IDiaSourceFile
    
        
        .. code-block:: csharp
    
           IDiaSourceFile Item(uint index)
    
    .. dn:method:: dia2.IDiaEnumSourceFiles.Next(System.UInt32, out dia2.IDiaSourceFile, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaSourceFile
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaSourceFile rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumSourceFiles.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumSourceFiles.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumSourceFiles
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumSourceFiles.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

