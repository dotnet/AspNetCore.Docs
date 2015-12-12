

IDiaEnumInputAssemblyFiles Interface
====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumInputAssemblyFiles





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumInputAssemblyFiles.cs>`_





.. dn:interface:: dia2.IDiaEnumInputAssemblyFiles

Methods
-------

.. dn:interface:: dia2.IDiaEnumInputAssemblyFiles
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.Clone(out dia2.IDiaEnumInputAssemblyFiles)
    
        
        
        
        :type ppenum: dia2.IDiaEnumInputAssemblyFiles
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumInputAssemblyFiles ppenum)
    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: dia2.IDiaInputAssemblyFile
    
        
        .. code-block:: csharp
    
           IDiaInputAssemblyFile Item(uint index)
    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.Next(System.UInt32, out dia2.IDiaInputAssemblyFile, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaInputAssemblyFile
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaInputAssemblyFile rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumInputAssemblyFiles.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumInputAssemblyFiles
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumInputAssemblyFiles.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

