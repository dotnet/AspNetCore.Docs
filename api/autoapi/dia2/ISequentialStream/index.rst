

ISequentialStream Interface
===========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISequentialStream





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/ISequentialStream.cs>`_





.. dn:interface:: dia2.ISequentialStream

Methods
-------

.. dn:interface:: dia2.ISequentialStream
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.ISequentialStream.RemoteRead(System.Byte[], System.Int32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte[]
        
        
        :type cb: System.Int32
        
        
        :type pcbRead: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteRead(byte[] pv, int cb, out uint pcbRead)
    
    .. dn:method:: dia2.ISequentialStream.RemoteWrite(ref System.Byte, System.UInt32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte
        
        
        :type cb: System.UInt32
        
        
        :type pcbWritten: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteWrite(ref byte pv, uint cb, out uint pcbWritten)
    

