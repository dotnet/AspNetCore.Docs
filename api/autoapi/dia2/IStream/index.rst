

IStream Interface
=================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IStream : ISequentialStream





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IStream.cs>`_





.. dn:interface:: dia2.IStream

Methods
-------

.. dn:interface:: dia2.IStream
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IStream.Clone(out dia2.IStream)
    
        
        
        
        :type ppstm: dia2.IStream
    
        
        .. code-block:: csharp
    
           void Clone(out IStream ppstm)
    
    .. dn:method:: dia2.IStream.Commit(System.UInt32)
    
        
        
        
        :type grfCommitFlags: System.UInt32
    
        
        .. code-block:: csharp
    
           void Commit(uint grfCommitFlags)
    
    .. dn:method:: dia2.IStream.LockRegion(dia2._ULARGE_INTEGER, dia2._ULARGE_INTEGER, System.UInt32)
    
        
        
        
        :type libOffset: dia2._ULARGE_INTEGER
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type dwLockType: System.UInt32
    
        
        .. code-block:: csharp
    
           void LockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    
    .. dn:method:: dia2.IStream.RemoteCopyTo(dia2.IStream, dia2._ULARGE_INTEGER, out dia2._ULARGE_INTEGER, out dia2._ULARGE_INTEGER)
    
        
        
        
        :type pstm: dia2.IStream
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type pcbRead: dia2._ULARGE_INTEGER
        
        
        :type pcbWritten: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           void RemoteCopyTo(IStream pstm, _ULARGE_INTEGER cb, out _ULARGE_INTEGER pcbRead, out _ULARGE_INTEGER pcbWritten)
    
    .. dn:method:: dia2.IStream.RemoteRead(System.Byte[], System.Int32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte[]
        
        
        :type cb: System.Int32
        
        
        :type pcbRead: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteRead(byte[] pv, int cb, out uint pcbRead)
    
    .. dn:method:: dia2.IStream.RemoteSeek(dia2._LARGE_INTEGER, System.UInt32, out dia2._ULARGE_INTEGER)
    
        
        
        
        :type dlibMove: dia2._LARGE_INTEGER
        
        
        :type dwOrigin: System.UInt32
        
        
        :type plibNewPosition: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           void RemoteSeek(_LARGE_INTEGER dlibMove, uint dwOrigin, out _ULARGE_INTEGER plibNewPosition)
    
    .. dn:method:: dia2.IStream.RemoteWrite(ref System.Byte, System.UInt32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte
        
        
        :type cb: System.UInt32
        
        
        :type pcbWritten: System.UInt32
    
        
        .. code-block:: csharp
    
           void RemoteWrite(ref byte pv, uint cb, out uint pcbWritten)
    
    .. dn:method:: dia2.IStream.Revert()
    
        
    
        
        .. code-block:: csharp
    
           void Revert()
    
    .. dn:method:: dia2.IStream.SetSize(dia2._ULARGE_INTEGER)
    
        
        
        
        :type libNewSize: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           void SetSize(_ULARGE_INTEGER libNewSize)
    
    .. dn:method:: dia2.IStream.Stat(out dia2.tagSTATSTG, System.UInt32)
    
        
        
        
        :type pstatstg: dia2.tagSTATSTG
        
        
        :type grfStatFlag: System.UInt32
    
        
        .. code-block:: csharp
    
           void Stat(out tagSTATSTG pstatstg, uint grfStatFlag)
    
    .. dn:method:: dia2.IStream.UnlockRegion(dia2._ULARGE_INTEGER, dia2._ULARGE_INTEGER, System.UInt32)
    
        
        
        
        :type libOffset: dia2._ULARGE_INTEGER
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type dwLockType: System.UInt32
    
        
        .. code-block:: csharp
    
           void UnlockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    

