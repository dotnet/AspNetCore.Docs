

JsonInputFormatter Class
========================






An :any:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter` for JSON content.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter`








Syntax
------

.. code-block:: csharp

    public class JsonInputFormatter : TextInputFormatter, IInputFormatter, IApiRequestFormatMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.SerializerSettings
    
        
    
        
        Gets or sets the :any:`Newtonsoft.Json.JsonSerializerSettings` used to configure the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonSerializerSettings SerializerSettings
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.JsonInputFormatter(Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter`\.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public JsonInputFormatter(ILogger logger)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.JsonInputFormatter(Microsoft.Extensions.Logging.ILogger, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter`\.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param serializerSettings: The :any:`Newtonsoft.Json.JsonSerializerSettings`\.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.JsonInputFormatter(Microsoft.Extensions.Logging.ILogger, Newtonsoft.Json.JsonSerializerSettings, System.Buffers.ArrayPool<System.Char>, Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter`\.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param serializerSettings: The :any:`Newtonsoft.Json.JsonSerializerSettings`\.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        :param charPool: The :any:`System.Buffers.ArrayPool\`1`\.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        :param objectPoolProvider: The :any:`Microsoft.Extensions.ObjectPool.ObjectPoolProvider`\.
        
        :type objectPoolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        .. code-block:: csharp
    
            public JsonInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.CreateJsonSerializer()
    
        
    
        
        Called during deserialization to get the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializer
        :return: The :any:`Newtonsoft.Json.JsonSerializer` used during deserialization.
    
        
        .. code-block:: csharp
    
            protected virtual JsonSerializer CreateJsonSerializer()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    
        
        :type encoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
    
        
        .. code-block:: csharp
    
            public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter.ReleaseJsonSerializer(Newtonsoft.Json.JsonSerializer)
    
        
    
        
        Releases the <em>serializer</em> instance.
    
        
    
        
        :param serializer: The :any:`Newtonsoft.Json.JsonSerializer` to release.
        
        :type serializer: Newtonsoft.Json.JsonSerializer
    
        
        .. code-block:: csharp
    
            protected virtual void ReleaseJsonSerializer(JsonSerializer serializer)
    

