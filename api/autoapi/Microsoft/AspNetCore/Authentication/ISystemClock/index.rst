

ISystemClock Interface
======================






Abstracts the system clock to facilitate testing.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISystemClock








.. dn:interface:: Microsoft.AspNetCore.Authentication.ISystemClock
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.ISystemClock

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Authentication.ISystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ISystemClock.UtcNow
    
        
    
        
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            DateTimeOffset UtcNow
            {
                get;
            }
    

