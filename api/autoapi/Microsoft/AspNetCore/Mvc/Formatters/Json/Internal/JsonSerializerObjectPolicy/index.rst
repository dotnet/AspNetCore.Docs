

JsonSerializerObjectPolicy Class
================================






:any:`Microsoft.Extensions.ObjectPool.IPooledObjectPolicy\`1` for :any:`Newtonsoft.Json.JsonSerializer`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy`








Syntax
------

.. code-block:: csharp

    public class JsonSerializerObjectPolicy : IPooledObjectPolicy<JsonSerializer>








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy.JsonSerializerObjectPolicy(Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy`\.
    
        
    
        
        :param serializerSettings: The :any:`Newtonsoft.Json.JsonSerializerSettings` used to instantiate 
            :any:`Newtonsoft.Json.JsonSerializer` instances.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonSerializerObjectPolicy(JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy.Create()
    
        
        :rtype: Newtonsoft.Json.JsonSerializer
    
        
        .. code-block:: csharp
    
            public JsonSerializer Create()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonSerializerObjectPolicy.Return(Newtonsoft.Json.JsonSerializer)
    
        
    
        
        :type serializer: Newtonsoft.Json.JsonSerializer
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Return(JsonSerializer serializer)
    

