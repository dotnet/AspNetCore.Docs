

XmlSerializerInputFormatter Class
=================================



.. contents:: 
   :local:



Summary
-------

This class handles deserialization of input XML data
to strongly-typed objects using :any:`System.Xml.Serialization.XmlSerializer`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter`








Syntax
------

.. code-block:: csharp

   public class XmlSerializerInputFormatter : InputFormatter, IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/XmlSerializerInputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.XmlSerializerInputFormatter()
    
        
    
        Initializes a new instance of XmlSerializerInputFormatter.
    
        
    
        
        .. code-block:: csharp
    
           public XmlSerializerInputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.CanReadType(System.Type)
    
        
        
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool CanReadType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.CreateSerializer(System.Type)
    
        
    
        Called during deserialization to get the :any:`System.Xml.Serialization.XmlSerializer`\.
    
        
        
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: The <see cref="T:System.Xml.Serialization.XmlSerializer" /> used during deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual XmlSerializer CreateSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.CreateXmlReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        Called during deserialization to get the :any:`System.Xml.XmlReader`\.
    
        
        
        
        :param readStream: The  from which to read.
        
        :type readStream: System.IO.Stream
        
        
        :param encoding: The  used to read the stream.
        
        :type encoding: System.Text.Encoding
        :rtype: System.Xml.XmlReader
        :return: The <see cref="T:System.Xml.XmlReader" /> used during deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual XmlReader CreateXmlReader(Stream readStream, Encoding encoding)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.GetCachedSerializer(System.Type)
    
        
    
        Gets the cached serializer or creates and caches the serializer for the given type.
    
        
        
        
        :type type: System.Type
        :rtype: System.Xml.Serialization.XmlSerializer
        :return: The <see cref="T:System.Xml.Serialization.XmlSerializer" /> instance.
    
        
        .. code-block:: csharp
    
           protected virtual XmlSerializer GetCachedSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.GetSerializableType(System.Type)
    
        
    
        Gets the type to which the XML will be deserialized.
    
        
        
        
        :param declaredType: The declared type.
        
        :type declaredType: System.Type
        :rtype: System.Type
        :return: The type to which the XML will be deserialized.
    
        
        .. code-block:: csharp
    
           protected virtual Type GetSerializableType(Type declaredType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.ReadRequestBodyAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
    
        
        .. code-block:: csharp
    
           public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.MaxDepth
    
        
    
        Indicates the acceptable input XML depth.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxDepth { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.WrapperProviderFactories
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory` to
        provide the wrapping type for de-serialization.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory}
    
        
        .. code-block:: csharp
    
           public IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter.XmlDictionaryReaderQuotas
    
        
    
        The quotas include - DefaultMaxDepth, DefaultMaxStringContentLength, DefaultMaxArrayLength,
        DefaultMaxBytesPerRead, DefaultMaxNameTableCharCount
    
        
        :rtype: System.Xml.XmlDictionaryReaderQuotas
    
        
        .. code-block:: csharp
    
           public XmlDictionaryReaderQuotas XmlDictionaryReaderQuotas { get; }
    

