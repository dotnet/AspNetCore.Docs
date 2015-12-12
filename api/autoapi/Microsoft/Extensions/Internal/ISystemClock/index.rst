

ISystemClock Interface
======================



.. contents:: 
   :local:



Summary
-------

Abstracts the system clock to facilitate testing.











Syntax
------

.. code-block:: csharp

   public interface ISystemClock





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Abstractions/Internal/ISystemClock.cs>`_





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
    

