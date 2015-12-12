

StreamWrapper Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`dia2.StreamWrapper`








Syntax
------

.. code-block:: csharp

   public class StreamWrapper : IStream, ISequentialStream





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/DIA/StreamWrapper.cs>`_





.. dn:class:: dia2.StreamWrapper

Constructors
------------

.. dn:class:: dia2.StreamWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: dia2.StreamWrapper.StreamWrapper(System.IO.Stream)
    
        
        
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public StreamWrapper(Stream stream)
    

Methods
-------

.. dn:class:: dia2.StreamWrapper
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.StreamWrapper.Clone(out dia2.IStream)
    
        
        
        
        :type ppstm: dia2.IStream
    
        
        .. code-block:: csharp
    
           public void Clone(out IStream ppstm)
    
    .. dn:method:: dia2.StreamWrapper.Commit(System.UInt32)
    
        
        
        
        :type grfCommitFlags: System.UInt32
    
        
        .. code-block:: csharp
    
           public void Commit(uint grfCommitFlags)
    
    .. dn:method:: dia2.StreamWrapper.LockRegion(dia2._ULARGE_INTEGER, dia2._ULARGE_INTEGER, System.UInt32)
    
        
        
        
        :type libOffset: dia2._ULARGE_INTEGER
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type dwLockType: System.UInt32
    
        
        .. code-block:: csharp
    
           public void LockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    
    .. dn:method:: dia2.StreamWrapper.RemoteCopyTo(dia2.IStream, dia2._ULARGE_INTEGER, out dia2._ULARGE_INTEGER, out dia2._ULARGE_INTEGER)
    
        
        
        
        :type pstm: dia2.IStream
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type pcbRead: dia2._ULARGE_INTEGER
        
        
        :type pcbWritten: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           public void RemoteCopyTo(IStream pstm, _ULARGE_INTEGER cb, out _ULARGE_INTEGER pcbRead, out _ULARGE_INTEGER pcbWritten)
    
    .. dn:method:: dia2.StreamWrapper.RemoteRead(System.Byte[], System.Int32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte[]
        
        
        :type cb: System.Int32
        
        
        :type pcbRead: System.UInt32
    
        
        .. code-block:: csharp
    
           public void RemoteRead(byte[] pv, int cb, out uint pcbRead)
    
    .. dn:method:: dia2.StreamWrapper.RemoteRead(System.Byte[], System.UInt32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte[]
        
        
        :type cb: System.UInt32
        
        
        :type pcbRead: System.UInt32
    
        
        .. code-block:: csharp
    
           public void RemoteRead(byte[] pv, uint cb, out uint pcbRead)
    
    .. dn:method:: dia2.StreamWrapper.RemoteSeek(dia2._LARGE_INTEGER, System.UInt32, out dia2._ULARGE_INTEGER)
    
        
        
        
        :type dlibMove: dia2._LARGE_INTEGER
        
        
        :type dwOrigin: System.UInt32
        
        
        :type plibNewPosition: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           public void RemoteSeek(_LARGE_INTEGER dlibMove, uint dwOrigin, out _ULARGE_INTEGER plibNewPosition)
    
    .. dn:method:: dia2.StreamWrapper.RemoteWrite(ref System.Byte, System.UInt32, out System.UInt32)
    
        
        
        
        :type pv: System.Byte
        
        
        :type cb: System.UInt32
        
        
        :type pcbWritten: System.UInt32
    
        
        .. code-block:: csharp
    
           public void RemoteWrite(ref byte pv, uint cb, out uint pcbWritten)
    
    .. dn:method:: dia2.StreamWrapper.Revert()
    
        
    
        
        .. code-block:: csharp
    
           public void Revert()
    
    .. dn:method:: dia2.StreamWrapper.SetSize(dia2._ULARGE_INTEGER)
    
        
        
        
        :type libNewSize: dia2._ULARGE_INTEGER
    
        
        .. code-block:: csharp
    
           public void SetSize(_ULARGE_INTEGER libNewSize)
    
    .. dn:method:: dia2.StreamWrapper.Stat(out dia2.tagSTATSTG, System.UInt32)
    
        
        
        
        :type pstatstg: dia2.tagSTATSTG
        
        
        :type grfStatFlag: System.UInt32
    
        
        .. code-block:: csharp
    
           public void Stat(out tagSTATSTG pstatstg, uint grfStatFlag)
    
    .. dn:method:: dia2.StreamWrapper.UnlockRegion(dia2._ULARGE_INTEGER, dia2._ULARGE_INTEGER, System.UInt32)
    
        
        
        
        :type libOffset: dia2._ULARGE_INTEGER
        
        
        :type cb: dia2._ULARGE_INTEGER
        
        
        :type dwLockType: System.UInt32
    
        
        .. code-block:: csharp
    
           public void UnlockRegion(_ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType)
    

