

JsonOutputFormatter Class
=========================






An output formatter that specializes in writing JSON content.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class JsonOutputFormatter : TextOutputFormatter, IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.SerializerSettings
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.JsonOutputFormatter()
    
        
    
        
        .. code-block:: csharp
    
            public JsonOutputFormatter()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.JsonOutputFormatter(Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonOutputFormatter(JsonSerializerSettings serializerSettings)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.JsonOutputFormatter(Newtonsoft.Json.JsonSerializerSettings, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public JsonOutputFormatter(JsonSerializerSettings serializerSettings, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.CreateJsonSerializer()
    
        
    
        
        Called during serialization to create the :any:`Newtonsoft.Json.JsonSerializer`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializer
        :return: The :any:`Newtonsoft.Json.JsonSerializer` used during serialization and deserialization.
    
        
        .. code-block:: csharp
    
            protected virtual JsonSerializer CreateJsonSerializer()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.CreateJsonWriter(System.IO.TextWriter)
    
        
    
        
        Called during serialization to create the :any:`Newtonsoft.Json.JsonWriter`\.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` used to write.
        
        :type writer: System.IO.TextWriter
        :rtype: Newtonsoft.Json.JsonWriter
        :return: The :any:`Newtonsoft.Json.JsonWriter` used during serialization.
    
        
        .. code-block:: csharp
    
            protected virtual JsonWriter CreateJsonWriter(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.WriteObject(System.IO.TextWriter, System.Object)
    
        
    
        
        Writes the given <em>value</em> as JSON using the given
        <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` used to write the <em>value</em>
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The value to write as JSON.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void WriteObject(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :type selectedEncoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    

