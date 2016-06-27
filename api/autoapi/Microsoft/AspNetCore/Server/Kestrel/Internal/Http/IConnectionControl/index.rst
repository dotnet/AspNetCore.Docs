

IConnectionControl Interface
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

    public interface IConnectionControl








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.End(Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ProduceEndType)
    
        
    
        
        :type endType: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
            void End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.Pause()
    
        
    
        
        .. code-block:: csharp
    
            void Pause()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.Resume()
    
        
    
        
        .. code-block:: csharp
    
            void Resume()
    

