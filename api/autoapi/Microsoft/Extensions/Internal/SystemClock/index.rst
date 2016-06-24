

SystemClock Class
=================






Provides access to the normal system clock.


Namespace
    :dn:ns:`Microsoft.Extensions.Internal`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Internal.SystemClock`








Syntax
------

.. code-block:: csharp

    public class SystemClock : ISystemClock








.. dn:class:: Microsoft.Extensions.Internal.SystemClock
    :hidden:

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
    

