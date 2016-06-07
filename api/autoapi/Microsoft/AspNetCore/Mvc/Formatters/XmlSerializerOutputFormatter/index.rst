

XmlSerializerOutputFormatter Class
==================================






This class handles serialization of objects
to XML using :any:`System.Xml.Serialization.XmlSerializer`


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class XmlSerializerOutputFormatter : TextOutputFormatter, IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.WrapperProviderFactories
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory` to
        provide the wrapping type for serialization.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>}
    
        
        .. code-block:: csharp
    
            public IList<IWrapperProviderFactory> WrapperProviderFactories
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.WriterSettings
    
        
    
        
        Gets the settings to be used by the XmlWriter.
    
        
        :rtype: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
            public XmlWriterSettings WriterSettings
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.XmlSerializerOutputFormatter()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter`
        with default XmlWriterSettings.
    
        
    
        
        .. code-block:: csharp
    
            public XmlSerializerOutputFormatter()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.XmlSerializerOutputFormatter(System.Xml.XmlWriterSettings)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter`
    
        
    
        
        :param writerSettings: The settings to be used by the :any:`System.Xml.Serialization.XmlSerializer`\.
        
        :type writerSettings: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
            public XmlSerializerOutputFormatter(XmlWriterSettings writerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.CanWriteType(System.Type)
    
        
    
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool CanWriteType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.CreateSerializer(System.Type)
    
        
    
        
        Create a new instance of :any:`System.Xml.Serialization.XmlSerializer` for the given object type.
    
        
    
        
        :param type: The type of object for which the serializer should be created.
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: A new instance of :any:`System.Xml.Serialization.XmlSerializer`
    
        
        .. code-block:: csharp
    
            protected virtual XmlSerializer CreateSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.CreateXmlWriter(System.IO.TextWriter, System.Xml.XmlWriterSettings)
    
        
    
        
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
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.GetCachedSerializer(System.Type)
    
        
    
        
        Gets the cached serializer or creates and caches the serializer for the given type.
    
        
    
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: The :any:`System.Xml.Serialization.XmlSerializer` instance.
    
        
        .. code-block:: csharp
    
            protected virtual XmlSerializer GetCachedSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.GetSerializableType(System.Type)
    
        
    
        
        Gets the type to be serialized.
    
        
    
        
        :param type: The original type to be serialized
        
        :type type: System.Type
        :rtype: System.Type
        :return: The original or wrapped type provided by any :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider`\.
    
        
        .. code-block:: csharp
    
            protected virtual Type GetSerializableType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :type selectedEncoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    

