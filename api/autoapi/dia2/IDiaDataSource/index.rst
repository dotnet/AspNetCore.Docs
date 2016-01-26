

IDiaDataSource Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiaDataSource





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/DIA/IDiaDataSource.cs>`_





.. dn:interface:: dia2.IDiaDataSource

Methods
-------

.. dn:interface:: dia2.IDiaDataSource
    :noindex:
    :hidden:

    
    .. dn:method:: dia2.IDiaDataSource.loadAndValidateDataFromPdb(System.String, ref System.Guid, System.UInt32, System.UInt32)
    
        
        
        
        :type pdbPath: System.String
        
        
        :type pcsig70: System.Guid
        
        
        :type sig: System.UInt32
        
        
        :type age: System.UInt32
    
        
        .. code-block:: csharp
    
           void loadAndValidateDataFromPdb(string pdbPath, ref Guid pcsig70, uint sig, uint age)
    
    .. dn:method:: dia2.IDiaDataSource.loadDataForExe(System.String, System.String, System.Object)
    
        
        
        
        :type executable: System.String
        
        
        :type searchPath: System.String
        
        
        :type pCallback: System.Object
    
        
        .. code-block:: csharp
    
           void loadDataForExe(string executable, string searchPath, object pCallback)
    
    .. dn:method:: dia2.IDiaDataSource.loadDataFromCodeViewInfo(System.String, System.String, System.UInt32, ref System.Byte, System.Object)
    
        
        
        
        :type executable: System.String
        
        
        :type searchPath: System.String
        
        
        :type cbCvInfo: System.UInt32
        
        
        :type pbCvInfo: System.Byte
        
        
        :type pCallback: System.Object
    
        
        .. code-block:: csharp
    
           void loadDataFromCodeViewInfo(string executable, string searchPath, uint cbCvInfo, ref byte pbCvInfo, object pCallback)
    
    .. dn:method:: dia2.IDiaDataSource.loadDataFromIStream(dia2.IStream)
    
        
        
        
        :type pIStream: dia2.IStream
    
        
        .. code-block:: csharp
    
           void loadDataFromIStream(IStream pIStream)
    
    .. dn:method:: dia2.IDiaDataSource.loadDataFromMiscInfo(System.String, System.String, System.UInt32, System.UInt32, System.UInt32, System.UInt32, ref System.Byte, System.Object)
    
        
        
        
        :type executable: System.String
        
        
        :type searchPath: System.String
        
        
        :type timeStampExe: System.UInt32
        
        
        :type timeStampDbg: System.UInt32
        
        
        :type sizeOfExe: System.UInt32
        
        
        :type cbMiscInfo: System.UInt32
        
        
        :type pbMiscInfo: System.Byte
        
        
        :type pCallback: System.Object
    
        
        .. code-block:: csharp
    
           void loadDataFromMiscInfo(string executable, string searchPath, uint timeStampExe, uint timeStampDbg, uint sizeOfExe, uint cbMiscInfo, ref byte pbMiscInfo, object pCallback)
    
    .. dn:method:: dia2.IDiaDataSource.loadDataFromPdb(System.String)
    
        
        
        
        :type pdbPath: System.String
    
        
        .. code-block:: csharp
    
           void loadDataFromPdb(string pdbPath)
    
    .. dn:method:: dia2.IDiaDataSource.openSession(out dia2.IDiaSession)
    
        
        
        
        :type ppSession: dia2.IDiaSession
    
        
        .. code-block:: csharp
    
           void openSession(out IDiaSession ppSession)
    

Properties
----------

.. dn:interface:: dia2.IDiaDataSource
    :noindex:
    :hidden:

    
    .. dn:property:: dia2.IDiaDataSource.lastError
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string lastError { get; }
    

