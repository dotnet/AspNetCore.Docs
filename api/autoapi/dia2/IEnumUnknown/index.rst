

IEnumUnknown Interface
======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IEnumUnknown





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IEnumUnknown.cs>`_





.. dn:interface:: dia2.IEnumUnknown

Methods
-------

.. dn:interface:: dia2.IEnumUnknown
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IEnumUnknown.Clone(out dia2.IEnumUnknown)
    
        
        
        
        :type ppenum: dia2.IEnumUnknown
    
        
        .. code-block:: csharp
    
           void Clone(out IEnumUnknown ppenum)
    
    .. dn:method:: dia2.IEnumUnknown.RemoteNext(System.UInt32, out System.Object, out System.UInt32)
    
        
        
        
        :type celt: System.UInt32
        
        
        :type rgelt: System.Object
        
        
        :type pceltFetched: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteNext(uint celt, out object rgelt, out uint pceltFetched)
    
    .. dn:method:: dia2.IEnumUnknown.Reset()
    
        
    
        
        .. code-block:: csharp
    
           void Reset()
    
    .. dn:method:: dia2.IEnumUnknown.Skip(System.UInt32)
    
        
        
        
        :type celt: System.UInt32
    
        
        .. code-block:: csharp
    
           void Skip(uint celt)
    

