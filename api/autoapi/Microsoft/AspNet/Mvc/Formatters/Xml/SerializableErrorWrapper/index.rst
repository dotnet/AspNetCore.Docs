

SerializableErrorWrapper Class
==============================



.. contents:: 
   :local:



Summary
-------

Wrapper class for :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` to enable it to be serialized by the xml formatters.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper`








Syntax
------

.. code-block:: csharp

   public sealed class SerializableErrorWrapper : IXmlSerializable, IUnwrappable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/SerializableErrorWrapper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableErrorWrapper()
    
        
    
        
        .. code-block:: csharp
    
           public SerializableErrorWrapper()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableErrorWrapper(Microsoft.AspNet.Mvc.SerializableError)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper` class.
    
        
        
        
        :param error: The  object that needs to be wrapped.
        
        :type error: Microsoft.AspNet.Mvc.SerializableError
    
        
        .. code-block:: csharp
    
           public SerializableErrorWrapper(SerializableError error)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.GetSchema()
    
        
        :rtype: System.Xml.Schema.XmlSchema
    
        
        .. code-block:: csharp
    
           public XmlSchema GetSchema()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.ReadXml(System.Xml.XmlReader)
    
        
    
        Generates a :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` object from its XML representation.
    
        
        
        
        :param reader: The  stream from which the object is deserialized.
        
        :type reader: System.Xml.XmlReader
    
        
        .. code-block:: csharp
    
           public void ReadXml(XmlReader reader)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.Unwrap(System.Type)
    
        
        
        
        :type declaredType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Unwrap(Type declaredType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.WriteXml(System.Xml.XmlWriter)
    
        
    
        Converts the wrapped :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` object into its XML representation.
    
        
        
        
        :param writer: The  stream to which the object is serialized.
        
        :type writer: System.Xml.XmlWriter
    
        
        .. code-block:: csharp
    
           public void WriteXml(XmlWriter writer)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError
    
        
    
        Gets the wrapped object which is serialized/deserialized into XML
        representation.
    
        
        :rtype: Microsoft.AspNet.Mvc.SerializableError
    
        
        .. code-block:: csharp
    
           public SerializableError SerializableError { get; }
    

