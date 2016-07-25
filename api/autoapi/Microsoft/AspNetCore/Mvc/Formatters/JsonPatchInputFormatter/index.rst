

JsonPatchInputFormatter Class
=============================






A :any:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter` for JSON Patch (application/json-patch+json) content.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter`








Syntax
------

.. code-block:: csharp

    public class JsonPatchInputFormatter : JsonInputFormatter, IInputFormatter, IApiRequestFormatMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter.JsonPatchInputFormatter(Microsoft.Extensions.Logging.ILogger, Newtonsoft.Json.JsonSerializerSettings, System.Buffers.ArrayPool<System.Char>, Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter` instance.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param serializerSettings: 
            The :any:`Newtonsoft.Json.JsonSerializerSettings`\. Should be either the application-wide settings
            ( :dn:prop:`Microsoft.AspNetCore.Mvc.MvcJsonOptions.SerializerSettings`\) or an instance 
            :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.JsonSerializerSettingsProvider.CreateSerializerSettings` initially returned.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        :param charPool: The :any:`System.Buffers.ArrayPool\`1`\.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        :param objectPoolProvider: The :any:`Microsoft.Extensions.ObjectPool.ObjectPoolProvider`\.
        
        :type objectPoolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        .. code-block:: csharp
    
            public JsonPatchInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter.CanRead(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    
        
        :type encoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
    
        
        .. code-block:: csharp
    
            public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    

