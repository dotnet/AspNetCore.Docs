

SerializableErrorWrapper Class
==============================






Wrapper class for :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` to enable it to be serialized by the xml formatters.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper`








Syntax
------

.. code-block:: csharp

    [XmlRoot("Error")]
    public sealed class SerializableErrorWrapper : IXmlSerializable, IUnwrappable








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableErrorWrapper()
    
        
    
        
        .. code-block:: csharp
    
            public SerializableErrorWrapper()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableErrorWrapper(Microsoft.AspNetCore.Mvc.SerializableError)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper` class.
    
        
    
        
        :param error: The :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` object that needs to be wrapped.
        
        :type error: Microsoft.AspNetCore.Mvc.SerializableError
    
        
        .. code-block:: csharp
    
            public SerializableErrorWrapper(SerializableError error)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.GetSchema()
    
        
        :rtype: System.Xml.Schema.XmlSchema
    
        
        .. code-block:: csharp
    
            public XmlSchema GetSchema()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.ReadXml(System.Xml.XmlReader)
    
        
    
        
        Generates a :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` object from its XML representation.
    
        
    
        
        :param reader: The :any:`System.Xml.XmlReader` stream from which the object is deserialized.
        
        :type reader: System.Xml.XmlReader
    
        
        .. code-block:: csharp
    
            public void ReadXml(XmlReader reader)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.Unwrap(System.Type)
    
        
    
        
        :type declaredType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Unwrap(Type declaredType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.WriteXml(System.Xml.XmlWriter)
    
        
    
        
        Converts the wrapped :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError` object into its XML representation.
    
        
    
        
        :param writer: The :any:`System.Xml.XmlWriter` stream to which the object is serialized.
        
        :type writer: System.Xml.XmlWriter
    
        
        .. code-block:: csharp
    
            public void WriteXml(XmlWriter writer)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapper.SerializableError
    
        
    
        
        Gets the wrapped object which is serialized/deserialized into XML
        representation.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.SerializableError
    
        
        .. code-block:: csharp
    
            public SerializableError SerializableError { get; }
    

