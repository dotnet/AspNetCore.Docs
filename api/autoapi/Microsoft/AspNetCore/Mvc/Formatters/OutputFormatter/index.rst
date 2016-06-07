

OutputFormatter Class
=====================






Writes an object to the output stream.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`








Syntax
------

.. code-block:: csharp

    public abstract class OutputFormatter : IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.SupportedMediaTypes
    
        
    
        
        Gets the mutable collection of media type elements supported by
        this :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection SupportedMediaTypes
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType(System.Type)
    
        
    
        
        Returns a value indicating whether or not the given type can be written by this serializer.
    
        
    
        
        :param type: The object type.
        
        :type type: System.Type
        :rtype: System.Boolean
        :return: <code>true</code> if the type can be written, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected virtual bool CanWriteType(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.GetSupportedContentTypes(System.String, System.Type)
    
        
    
        
        :type contentType: System.String
    
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task WriteAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        Writes the response body.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
        :return: A task which can write the response body.
    
        
        .. code-block:: csharp
    
            public abstract Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseHeaders(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        Sets the headers on :any:`Microsoft.AspNetCore.Http.HttpResponse` object.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        .. code-block:: csharp
    
            public virtual void WriteResponseHeaders(OutputFormatterWriteContext context)
    

