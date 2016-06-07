

PostEvictionCallbackRegistration Class
======================================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration`








Syntax
------

.. code-block:: csharp

    public class PostEvictionCallbackRegistration








.. dn:class:: Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration.EvictionCallback
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.PostEvictionDelegate
    
        
        .. code-block:: csharp
    
            public PostEvictionDelegate EvictionCallback
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.PostEvictionCallbackRegistration.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object State
            {
                get;
                set;
            }
    

