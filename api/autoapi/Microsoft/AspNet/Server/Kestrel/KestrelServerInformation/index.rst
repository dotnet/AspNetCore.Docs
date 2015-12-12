

KestrelServerInformation Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.KestrelServerInformation`








Syntax
------

.. code-block:: csharp

   public class KestrelServerInformation : IKestrelServerInformation, IServerAddressesFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/KestrelServerInformation.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation.Initialize(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
           public void Initialize(IConfiguration configuration)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation.Addresses
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Addresses { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation.ConnectionFilter
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
           public IConnectionFilter ConnectionFilter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation.NoDelay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool NoDelay { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelServerInformation.ThreadCount
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ThreadCount { get; set; }
    

