

Microsoft.Extensions.Internal Namespace
=======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Internal/GcNotification/index
   
   
   
   /autoapi/Microsoft/Extensions/Internal/ISystemClock/index
   
   
   
   /autoapi/Microsoft/Extensions/Internal/SystemClock/index
   
   











.. dn:namespace:: Microsoft.Extensions.Internal


    .. rubric:: Classes


    class :dn:cls:`Microsoft.Extensions.Internal.GcNotification`
        Registers a callback that fires each time a Gen2 garbage collection occurs,
        presumably due to memory pressure.
        For this to work no components can have a reference to the instance.


    class :dn:cls:`Microsoft.Extensions.Internal.SystemClock`
        Provides access to the normal system clock.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.Extensions.Internal.ISystemClock`
        Abstracts the system clock to facilitate testing.


