

IConnectionControl Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IConnectionControl





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/IConnectionControl.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.End(Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType)
    
        
        
        
        :type endType: Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
           void End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.Pause()
    
        
    
        
        .. code-block:: csharp
    
           void Pause()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl.Resume()
    
        
    
        
        .. code-block:: csharp
    
           void Resume()
    

