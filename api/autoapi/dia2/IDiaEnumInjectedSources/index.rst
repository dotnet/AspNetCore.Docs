

IDiaEnumInjectedSources Interface
=================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaEnumInjectedSources





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaEnumInjectedSources.cs>`_





.. dn:interface:: dia2.IDiaEnumInjectedSources

Methods
-------

.. dn:interface:: dia2.IDiaEnumInjectedSources
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaEnumInjectedSources.Clone(out dia2.IDiaEnumInjectedSources)
    
        
        
        
        :type ppenum: dia2.IDiaEnumInjectedSources
    
        
        .. code-block:: csharp
    
           void Clone(out IDiaEnumInjectedSources ppenum)
    
    .. dn:method:: dia2.IDiaEnumInjectedSources.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator GetEnumerator()
    
    .. dn:method:: dia2.IDiaEnumInjectedSources.Item(System.UInt32)
    
        
        
        
        :type index: System.UInt32
        :rtype: dia2.IDiaInjectedSource
    
        
        .. code-block:: csharp
    
           IDiaInjectedSource Item(uint index)
    
    .. dn:method:: dia2.IDiaEnumInjectedSources.Next(System.UInt32, out dia2.IDiaInjectedSource, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: dia2.IDiaInjectedSource
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void Next(uint celt, out IDiaInjectedSource rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IDiaEnumInjectedSources.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IDiaEnumInjectedSources.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

Properties
----------

.. dn:interface:: dia2.IDiaEnumInjectedSources
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaEnumInjectedSources.count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int count { get; }
    

