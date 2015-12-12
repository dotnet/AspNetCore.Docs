

SystemClock Class
=================



.. contents:: 
   :local:



Summary
-------

Provides access to the normal system clock.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Internal.SystemClock`








Syntax
------

.. code-block:: csharp

   public class SystemClock : ISystemClock





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/Internal/SystemClock.cs>`_





.. dn:class:: Microsoft.Extensions.Internal.SystemClock

Properties
----------

.. dn:class:: Microsoft.Extensions.Internal.SystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Internal.SystemClock.UtcNow
    
        
    
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset UtcNow { get; }
    

