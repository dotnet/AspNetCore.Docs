

IKestrelServerInformation Interface
===================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IKestrelServerInformation





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/IKestrelServerInformation.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.IKestrelServerInformation

Properties
----------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.IKestrelServerInformation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.IKestrelServerInformation.ConnectionFilter
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
           IConnectionFilter ConnectionFilter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.IKestrelServerInformation.NoDelay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool NoDelay { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.IKestrelServerInformation.ThreadCount
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int ThreadCount { get; set; }
    

