

ISystemClock Interface
======================






Abstracts the system clock to facilitate testing.


Namespace
    :dn:ns:`Microsoft.Extensions.Internal`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISystemClock








.. dn:interface:: Microsoft.Extensions.Internal.ISystemClock
    :hidden:

.. dn:interface:: Microsoft.Extensions.Internal.ISystemClock

Properties
----------

.. dn:interface:: Microsoft.Extensions.Internal.ISystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Internal.ISystemClock.UtcNow
    
        
    
        
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            DateTimeOffset UtcNow { get; }
    

