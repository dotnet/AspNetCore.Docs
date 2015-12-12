

JsonOutputFormatter Class
=========================



.. contents:: 
   :local:



Summary
-------

An output formatter that specializes in writing JSON content.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class JsonOutputFormatter : OutputFormatter, IOutputFormatter, IApiResponseFormatMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/JsonOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.JsonOutputFormatter()
    
        
    
        
        .. code-block:: csharp
    
           public JsonOutputFormatter()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.JsonOutputFormatter(Newtonsoft.Json.JsonSerializerSettings)
    
        
        
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonOutputFormatter(JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.CreateJsonSerializer()
    
        
    
        Called during serialization to create the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializer
        :return: The <see cref="T:Newtonsoft.Json.JsonSerializer" /> used during serialization and deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual JsonSerializer CreateJsonSerializer()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.CreateJsonWriter(System.IO.TextWriter)
    
        
    
        Called during serialization to create the :any:`Newtonsoft.Json.JsonWriter`\.
    
        
        
        
        :param writer: The  used to write.
        
        :type writer: System.IO.TextWriter
        :rtype: Newtonsoft.Json.JsonWriter
        :return: The <see cref="T:Newtonsoft.Json.JsonWriter" /> used during serialization.
    
        
        .. code-block:: csharp
    
           protected virtual JsonWriter CreateJsonWriter(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.WriteObject(System.IO.TextWriter, System.Object)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void WriteObject(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter.SerializerSettings
    
        
    
        Gets or sets the :any:`Newtonsoft.Json.JsonSerializerSettings` used to configure the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonSerializerSettings SerializerSettings { get; set; }
    

