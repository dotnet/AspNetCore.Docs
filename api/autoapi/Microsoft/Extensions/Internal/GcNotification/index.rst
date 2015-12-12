

GcNotification Class
====================



.. contents:: 
   :local:



Summary
-------

Registers a callback that fires each time a Gen2 garbage collection occurs,
presumably due to memory pressure.
For this to work no components can have a reference to the instance.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Internal.GcNotification`








Syntax
------

.. code-block:: csharp

   public class GcNotification





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Memory/Infrastructure/GcNotification.cs>`_





.. dn:class:: Microsoft.Extensions.Internal.GcNotification

Methods
-------

.. dn:class:: Microsoft.Extensions.Internal.GcNotification
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Internal.GcNotification.Finalize()
    
        
    
        
        .. code-block:: csharp
    
           protected void Finalize()
    
    .. dn:method:: Microsoft.Extensions.Internal.GcNotification.Register(System.Func<System.Object, System.Boolean>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Boolean}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public static void Register(Func<object, bool> callback, object state)
    

