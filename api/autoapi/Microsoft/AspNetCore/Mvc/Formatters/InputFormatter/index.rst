

InputFormatter Class
====================






Reads an object from the request body.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatter`








Syntax
------

.. code-block:: csharp

    public abstract class InputFormatter : IInputFormatter, IApiRequestFormatMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanRead(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType(System.Type)
    
        
    
        
        Determines whether this :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatter` can deserialize an object of the given
        <em>type</em>.
    
        
    
        
        :param type: The :any:`System.Type` of object that will be read.
        
        :type type: System.Type
        :rtype: System.Boolean
        :return: <code>true</code> if the <em>type</em> can be read, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected virtual bool CanReadType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.GetDefaultValueForType(System.Type)
    
        
    
        
        Gets the default value for a given type. Used to return a default value when the body contains no content.
    
        
    
        
        :param modelType: The type of the value.
        
        :type modelType: System.Type
        :rtype: System.Object
        :return: The default value for the <em>modelType</em> type.
    
        
        .. code-block:: csharp
    
            protected virtual object GetDefaultValueForType(Type modelType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.GetSupportedContentTypes(System.String, System.Type)
    
        
    
        
        :type contentType: System.String
    
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
    
        
        .. code-block:: csharp
    
            public virtual Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        Reads an object from the request body.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion deserializes the request body.
    
        
        .. code-block:: csharp
    
            public abstract Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.SupportedMediaTypes
    
        
    
        
        Gets the mutable collection of media type elements supported by
        this :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatter`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection SupportedMediaTypes { get; }
    

