

JsonInputFormatter Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter`








Syntax
------

.. code-block:: csharp

   public class JsonInputFormatter : InputFormatter, IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/JsonInputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.JsonInputFormatter()
    
        
    
        
        .. code-block:: csharp
    
           public JsonInputFormatter()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.JsonInputFormatter(Newtonsoft.Json.JsonSerializerSettings)
    
        
        
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonInputFormatter(JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.CreateJsonReader(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext, System.IO.Stream, System.Text.Encoding)
    
        
    
        Called during deserialization to get the :any:`Newtonsoft.Json.JsonReader`\.
    
        
        
        
        :param context: The  for the read.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        
        
        :param readStream: The  from which to read.
        
        :type readStream: System.IO.Stream
        
        
        :param effectiveEncoding: The  to use when reading.
        
        :type effectiveEncoding: System.Text.Encoding
        :rtype: Newtonsoft.Json.JsonReader
        :return: The <see cref="T:Newtonsoft.Json.JsonReader" /> used during deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual JsonReader CreateJsonReader(InputFormatterContext context, Stream readStream, Encoding effectiveEncoding)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.CreateJsonSerializer()
    
        
    
        Called during deserialization to get the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializer
        :return: The <see cref="T:Newtonsoft.Json.JsonSerializer" /> used during serialization and deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual JsonSerializer CreateJsonSerializer()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.ReadRequestBodyAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
    
        
        .. code-block:: csharp
    
           public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter.SerializerSettings
    
        
    
        Gets or sets the :any:`Newtonsoft.Json.JsonSerializerSettings` used to configure the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonSerializerSettings SerializerSettings { get; set; }
    

