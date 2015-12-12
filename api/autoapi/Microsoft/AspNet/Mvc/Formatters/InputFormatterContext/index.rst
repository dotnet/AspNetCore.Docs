

InputFormatterContext Class
===========================



.. contents:: 
   :local:



Summary
-------

A context object used by an input formatter for deserializing the request body into an object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatterContext`








Syntax
------

.. code-block:: csharp

   public class InputFormatterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/InputFormatterContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.InputFormatterContext(Microsoft.AspNet.Http.HttpContext, System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatterContext`\.
    
        
        
        
        :param httpContext: The  for the current operation.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelName: The name of the model.
        
        :type modelName: System.String
        
        
        :param modelState: The  for recording errors.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public InputFormatterContext(HttpContext httpContext, string modelName, ModelStateDictionary modelState, ModelMetadata metadata)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.HttpContext
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpContext` associated with the current operation.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.Metadata
    
        
    
        Gets the requested :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` of the request body deserialization.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelName
    
        
    
        Gets the name of the model. Used as the key or key prefix for errors added to :dn:prop:`Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelState`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ModelName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelState
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` associated with the current operation.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelType
    
        
    
        Gets the requested :any:`System.Type` of the request body deserialization.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ModelType { get; }
    

