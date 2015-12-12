

XmlSerializerOutputFormatter Class
==================================



.. contents:: 
   :local:



Summary
-------

This class handles serialization of objects
to XML using :any:`System.Xml.Serialization.XmlSerializer`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class XmlSerializerOutputFormatter : OutputFormatter, IOutputFormatter, IApiResponseFormatMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/XmlSerializerOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.XmlSerializerOutputFormatter()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter`
        with default XmlWriterSettings.
    
        
    
        
        .. code-block:: csharp
    
           public XmlSerializerOutputFormatter()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.XmlSerializerOutputFormatter(System.Xml.XmlWriterSettings)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter`
    
        
        
        
        :param writerSettings: The settings to be used by the .
        
        :type writerSettings: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
           public XmlSerializerOutputFormatter(XmlWriterSettings writerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.CanWriteType(System.Type)
    
        
        
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool CanWriteType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.CreateSerializer(System.Type)
    
        
    
        Create a new instance of :any:`System.Xml.Serialization.XmlSerializer` for the given object type.
    
        
        
        
        :param type: The type of object for which the serializer should be created.
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: A new instance of <see cref="T:System.Xml.Serialization.XmlSerializer" />
    
        
        .. code-block:: csharp
    
           protected virtual XmlSerializer CreateSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.CreateXmlWriter(System.IO.TextWriter, System.Xml.XmlWriterSettings)
    
        
    
        Creates a new instance of :any:`System.Xml.XmlWriter` using the given :any:`System.IO.TextWriter` and 
        :any:`System.Xml.XmlWriterSettings`\.
    
        
        
        
        :param writer: The underlying  which the  should write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param xmlWriterSettings: The .
        
        :type xmlWriterSettings: System.Xml.XmlWriterSettings
        :rtype: System.Xml.XmlWriter
        :return: A new instance of <see cref="T:System.Xml.XmlWriter" />
    
        
        .. code-block:: csharp
    
           public virtual XmlWriter CreateXmlWriter(TextWriter writer, XmlWriterSettings xmlWriterSettings)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.GetCachedSerializer(System.Type)
    
        
    
        Gets the cached serializer or creates and caches the serializer for the given type.
    
        
        
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: The <see cref="T:System.Xml.Serialization.XmlSerializer" /> instance.
    
        
        .. code-block:: csharp
    
           protected virtual XmlSerializer GetCachedSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.GetSerializableType(System.Type)
    
        
    
        Gets the type to be serialized.
    
        
        
        
        :param type: The original type to be serialized
        
        :type type: System.Type
        :rtype: System.Type
        :return: The original or wrapped type provided by any <see cref="T:Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider" />.
    
        
        .. code-block:: csharp
    
           protected virtual Type GetSerializableType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.WrapperProviderFactories
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory` to
        provide the wrapping type for serialization.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory}
    
        
        .. code-block:: csharp
    
           public IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter.WriterSettings
    
        
    
        Gets the settings to be used by the XmlWriter.
    
        
        :rtype: System.Xml.XmlWriterSettings
    
        
        .. code-block:: csharp
    
           public XmlWriterSettings WriterSettings { get; }
    

