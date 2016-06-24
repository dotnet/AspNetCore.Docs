

IBufferSizeControl Interface
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IBufferSizeControl








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl.Add(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            void Add(int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl.Subtract(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            void Subtract(int count)
    

