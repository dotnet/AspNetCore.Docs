

Microsoft.Extensions.Internal Namespace
=======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Internal/GcNotification/index
   
   
   
   /autoapi/Microsoft/Extensions/Internal/ISystemClock/index
   
   
   
   /autoapi/Microsoft/Extensions/Internal/SystemClock/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.Internal


    .. rubric:: Classes


    class :dn:cls:`GcNotification`
        .. object: type=class name=Microsoft.Extensions.Internal.GcNotification

        
        Registers a callback that fires each time a Gen2 garbage collection occurs,
        presumably due to memory pressure.
        For this to work no components can have a reference to the instance.


    class :dn:cls:`SystemClock`
        .. object: type=class name=Microsoft.Extensions.Internal.SystemClock

        
        Provides access to the normal system clock.


    .. rubric:: Interfaces


    interface :dn:iface:`ISystemClock`
        .. object: type=interface name=Microsoft.Extensions.Internal.ISystemClock

        
        Abstracts the system clock to facilitate testing.


