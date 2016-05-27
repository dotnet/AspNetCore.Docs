

HttpError Class
===============






Defines a serializable container for storing error information. This information is stored
as key/value pairs. The dictionary keys to look up standard error information are available
on the :any:`System.Web.Http.HttpErrorKeys` type.


Namespace
    :dn:ns:`System.Web.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Generic.Dictionary{System.String,System.Object}`
* :dn:cls:`System.Web.Http.HttpError`








Syntax
------

.. code-block:: csharp

    [XmlRoot("Error")]
    public sealed class HttpError : Dictionary<string, object>, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IDictionary, ICollection, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, ISerializable, IDeserializationCallback, IXmlSerializable








.. dn:class:: System.Web.Http.HttpError
    :hidden:

.. dn:class:: System.Web.Http.HttpError

Properties
----------

.. dn:class:: System.Web.Http.HttpError
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.HttpError.ExceptionMessage
    
        
    
        
        The message of the :any:`System.Exception` if available.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExceptionMessage
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.HttpError.ExceptionType
    
        
    
        
        The type of the :any:`System.Exception` if available.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExceptionType
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.HttpError.InnerException
    
        
    
        
        The inner :any:`System.Exception` associated with this instance if available.
    
        
        :rtype: System.Web.Http.HttpError
    
        
        .. code-block:: csharp
    
            public HttpError InnerException
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.HttpError.Message
    
        
    
        
        The high-level, user-visible message explaining the cause of the error. Information carried in this field
        should be considered public in that it will go over the wire regardless of the value of error detail
        policy. As a result care should be taken not to disclose sensitive information about the server or the
        application.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Message
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.HttpError.MessageDetail
    
        
    
        
        A detailed description of the error intended for the developer to understand exactly what failed.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MessageDetail
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.HttpError.ModelState
    
        
    
        
        The :dn:prop:`System.Web.Http.HttpError.ModelState` containing information about the errors that occurred during model binding.
    
        
        :rtype: System.Web.Http.HttpError
    
        
        .. code-block:: csharp
    
            public HttpError ModelState
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.HttpError.StackTrace
    
        
    
        
        The stack trace information associated with this instance if available.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string StackTrace
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: System.Web.Http.HttpError
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.HttpError.HttpError()
    
        
    
        
        Initializes a new instance of the :any:`System.Web.Http.HttpError` class.
    
        
    
        
        .. code-block:: csharp
    
            public HttpError()
    
    .. dn:constructor:: System.Web.Http.HttpError.HttpError(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Boolean)
    
        
    
        
        Initializes a new instance of the :any:`System.Web.Http.HttpError` class for <em>modelState</em>.
    
        
    
        
        :param modelState: The invalid model state to use for error information.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param includeErrorDetail: 
            <code>true</code> to include exception messages in the error; <code>false</code> otherwise.
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
            public HttpError(ModelStateDictionary modelState, bool includeErrorDetail)
    
    .. dn:constructor:: System.Web.Http.HttpError.HttpError(System.Exception, System.Boolean)
    
        
    
        
        Initializes a new instance of the :any:`System.Web.Http.HttpError` class for <em>exception</em>.
    
        
    
        
        :param exception: The exception to use for error information.
        
        :type exception: System.Exception
    
        
        :param includeErrorDetail: 
            <code>true</code> to include the exception information in the error;<code>false</code> otherwise.
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
            public HttpError(Exception exception, bool includeErrorDetail)
    
    .. dn:constructor:: System.Web.Http.HttpError.HttpError(System.String)
    
        
    
        
        Initializes a new instance of the :any:`System.Web.Http.HttpError` class containing error message
        <em>message</em>.
    
        
    
        
        :param message: The error message to associate with this instance.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public HttpError(string message)
    

Methods
-------

.. dn:class:: System.Web.Http.HttpError
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.HttpError.GetPropertyValue<TValue>(System.String)
    
        
    
        
        Gets a particular property value from this error instance.
    
        
    
        
        :param key: The name of the error property.
        
        :type key: System.String
        :rtype: TValue
        :return: The value of the error property.
    
        
        .. code-block:: csharp
    
            public TValue GetPropertyValue<TValue>(string key)
    
    .. dn:method:: System.Web.Http.HttpError.System.Xml.Serialization.IXmlSerializable.GetSchema()
    
        
        :rtype: System.Xml.Schema.XmlSchema
    
        
        .. code-block:: csharp
    
            XmlSchema IXmlSerializable.GetSchema()
    
    .. dn:method:: System.Web.Http.HttpError.System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)
    
        
    
        
        :type reader: System.Xml.XmlReader
    
        
        .. code-block:: csharp
    
            void IXmlSerializable.ReadXml(XmlReader reader)
    
    .. dn:method:: System.Web.Http.HttpError.System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)
    
        
    
        
        :type writer: System.Xml.XmlWriter
    
        
        .. code-block:: csharp
    
            void IXmlSerializable.WriteXml(XmlWriter writer)
    

