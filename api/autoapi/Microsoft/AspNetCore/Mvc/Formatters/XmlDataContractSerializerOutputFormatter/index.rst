

XmlDataContractSerializerOutputFormatter Class
==============================================






This class handles serialization of objects
to XML using :any:`System.Runtime.Serialization.DataContractSerializer`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class XmlDataContractSerializerOutputFormatter : TextOutputFormatter, IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.XmlDataContractSerializerOutputFormatter()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter`
        with default XmlWriterSettings
    
        
    
        
        .. code-block:: csharp
    
            public XmlDataContractSerializerOutputFormatter()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.XmlDataContractSerializerOutputFormatter(System.Xml.XmlWriterSettings)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter`
    
        
    
        
        :param writerSettings: The settings to be used by the :any:`System.Runtime.Serialization.DataContractSerializer`\.
        
        :type writerSettings: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
            public XmlDataContractSerializerOutputFormatter(XmlWriterSettings writerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.CanWriteType(System.Type)
    
        
    
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool CanWriteType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.CreateSerializer(System.Type)
    
        
    
        
        Create a new instance of :any:`System.Runtime.Serialization.DataContractSerializer` for the given object type.
    
        
    
        
        :param type: The type of object for which the serializer should be created.
        
        :type type: System.Type
        :rtype: System.Runtime.Serialization.DataContractSerializer
        :return: A new instance of :any:`System.Runtime.Serialization.DataContractSerializer`
    
        
        .. code-block:: csharp
    
            protected virtual DataContractSerializer CreateSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.CreateXmlWriter(System.IO.TextWriter, System.Xml.XmlWriterSettings)
    
        
    
        
        Creates a new instance of :any:`System.Xml.XmlWriter` using the given :any:`System.IO.TextWriter` and 
        :any:`System.Xml.XmlWriterSettings`\.
    
        
    
        
        :param writer: 
            The underlying :any:`System.IO.TextWriter` which the :any:`System.Xml.XmlWriter` should write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param xmlWriterSettings: 
            The :any:`System.Xml.XmlWriterSettings`\.
        
        :type xmlWriterSettings: System.Xml.XmlWriterSettings
        :rtype: System.Xml.XmlWriter
        :return: A new instance of :any:`System.Xml.XmlWriter`
    
        
        .. code-block:: csharp
    
            public virtual XmlWriter CreateXmlWriter(TextWriter writer, XmlWriterSettings xmlWriterSettings)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.GetCachedSerializer(System.Type)
    
        
    
        
        Gets the cached serializer or creates and caches the serializer for the given type.
    
        
    
        
        :type type: System.Type
        :rtype: System.Runtime.Serialization.DataContractSerializer
        :return: The :any:`System.Runtime.Serialization.DataContractSerializer` instance.
    
        
        .. code-block:: csharp
    
            protected virtual DataContractSerializer GetCachedSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.GetSerializableType(System.Type)
    
        
    
        
        Gets the type to be serialized.
    
        
    
        
        :param type: The original type to be serialized
        
        :type type: System.Type
        :rtype: System.Type
        :return: The original or wrapped type provided by any :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider`\s.
    
        
        .. code-block:: csharp
    
            protected virtual Type GetSerializableType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :type selectedEncoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.SerializerSettings
    
        
    
        
        Gets or sets the :any:`System.Runtime.Serialization.DataContractSerializerSettings` used to configure the 
        :any:`System.Runtime.Serialization.DataContractSerializer`\.
    
        
        :rtype: System.Runtime.Serialization.DataContractSerializerSettings
    
        
        .. code-block:: csharp
    
            public DataContractSerializerSettings SerializerSettings { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.WrapperProviderFactories
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory` to
        provide the wrapping type for serialization.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>}
    
        
        .. code-block:: csharp
    
            public IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter.WriterSettings
    
        
    
        
        Gets the settings to be used by the XmlWriter.
    
        
        :rtype: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
            public XmlWriterSettings WriterSettings { get; }
    

