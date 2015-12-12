

XmlDataContractSerializerInputFormatter Class
=============================================



.. contents:: 
   :local:



Summary
-------

This class handles deserialization of input XML data
to strongly-typed objects using :any:`System.Runtime.Serialization.DataContractSerializer`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter`








Syntax
------

.. code-block:: csharp

   public class XmlDataContractSerializerInputFormatter : InputFormatter, IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/XmlDataContractSerializerInputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.XmlDataContractSerializerInputFormatter()
    
        
    
        Initializes a new instance of DataContractSerializerInputFormatter
    
        
    
        
        .. code-block:: csharp
    
           public XmlDataContractSerializerInputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.CanReadType(System.Type)
    
        
        
        
        :type type: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool CanReadType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.CreateSerializer(System.Type)
    
        
    
        Called during deserialization to get the :any:`System.Runtime.Serialization.DataContractSerializer`\.
    
        
        
        
        :param type: The type of object for which the serializer should be created.
        
        :type type: System.Type
        :rtype: System.Runtime.Serialization.DataContractSerializer
        :return: The <see cref="T:System.Runtime.Serialization.DataContractSerializer" /> used during deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual DataContractSerializer CreateSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.CreateXmlReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        Called during deserialization to get the :any:`System.Xml.XmlReader`\.
    
        
        
        
        :param readStream: The  from which to read.
        
        :type readStream: System.IO.Stream
        
        
        :param encoding: The  used to read the stream.
        
        :type encoding: System.Text.Encoding
        :rtype: System.Xml.XmlReader
        :return: The <see cref="T:System.Xml.XmlReader" /> used during deserialization.
    
        
        .. code-block:: csharp
    
           protected virtual XmlReader CreateXmlReader(Stream readStream, Encoding encoding)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.GetCachedSerializer(System.Type)
    
        
    
        Gets the cached serializer or creates and caches the serializer for the given type.
    
        
        
        
        :type type: System.Type
        :rtype: System.Runtime.Serialization.DataContractSerializer
        :return: The <see cref="T:System.Runtime.Serialization.DataContractSerializer" /> instance.
    
        
        .. code-block:: csharp
    
           protected virtual DataContractSerializer GetCachedSerializer(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.GetSerializableType(System.Type)
    
        
    
        Gets the type to which the XML will be deserialized.
    
        
        
        
        :param declaredType: The declared type.
        
        :type declaredType: System.Type
        :rtype: System.Type
        :return: The type to which the XML will be deserialized.
    
        
        .. code-block:: csharp
    
           protected virtual Type GetSerializableType(Type declaredType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.ReadRequestBodyAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
    
        
        .. code-block:: csharp
    
           public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.MaxDepth
    
        
    
        Indicates the acceptable input XML depth.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxDepth { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.SerializerSettings
    
        
    
        Gets or sets the :any:`System.Runtime.Serialization.DataContractSerializerSettings` used to configure the 
        :any:`System.Runtime.Serialization.DataContractSerializer`\.
    
        
        :rtype: System.Runtime.Serialization.DataContractSerializerSettings
    
        
        .. code-block:: csharp
    
           public DataContractSerializerSettings SerializerSettings { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.WrapperProviderFactories
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory` to
        provide the wrapping type for de-serialization.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory}
    
        
        .. code-block:: csharp
    
           public IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter.XmlDictionaryReaderQuotas
    
        
    
        The quotas include - DefaultMaxDepth, DefaultMaxStringContentLength, DefaultMaxArrayLength,
        DefaultMaxBytesPerRead, DefaultMaxNameTableCharCount
    
        
        :rtype: System.Xml.XmlDictionaryReaderQuotas
    
        
        .. code-block:: csharp
    
           public XmlDictionaryReaderQuotas XmlDictionaryReaderQuotas { get; }
    

