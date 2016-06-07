

InputFormatterContext Class
===========================






A context object used by an input formatter for deserializing the request body into an object.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`








Syntax
------

.. code-block:: csharp

    public class InputFormatterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current operation.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.Metadata
    
        
    
        
        Gets the requested :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` of the request body deserialization.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelName
    
        
    
        
        Gets the name of the model. Used as the key or key prefix for errors added to :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelState`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ModelName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelState
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` associated with the current operation.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelType
    
        
    
        
        Gets the requested :any:`System.Type` of the request body deserialization.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ModelType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ReaderFactory
    
        
    
        
        Gets a delegate which can create a :any:`System.IO.TextReader` for the request body.
    
        
        :rtype: System.Func<System.Func`3>{System.IO.Stream<System.IO.Stream>, System.Text.Encoding<System.Text.Encoding>, System.IO.TextReader<System.IO.TextReader>}
    
        
        .. code-block:: csharp
    
            public Func<Stream, Encoding, TextReader> ReaderFactory
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.InputFormatterContext(Microsoft.AspNetCore.Http.HttpContext, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Func<System.IO.Stream, System.Text.Encoding, System.IO.TextReader>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
    
        
    
        
        :param httpContext: 
            The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current operation.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param modelName: The name of the model.
        
        :type modelName: System.String
    
        
        :param modelState: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` for recording errors.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param metadata: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` of the model to deserialize.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param readerFactory: 
            A delegate which can create a :any:`System.IO.TextReader` for the request body.
        
        :type readerFactory: System.Func<System.Func`3>{System.IO.Stream<System.IO.Stream>, System.Text.Encoding<System.Text.Encoding>, System.IO.TextReader<System.IO.TextReader>}
    
        
        .. code-block:: csharp
    
            public InputFormatterContext(HttpContext httpContext, string modelName, ModelStateDictionary modelState, ModelMetadata metadata, Func<Stream, Encoding, TextReader> readerFactory)
    

