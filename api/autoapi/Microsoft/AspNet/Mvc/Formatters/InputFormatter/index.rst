

InputFormatter Class
====================



.. contents:: 
   :local:



Summary
-------

Reads an object from the request body.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`








Syntax
------

.. code-block:: csharp

   public abstract class InputFormatter : IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/InputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.CanRead(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.CanReadType(System.Type)
    
        
    
        Determines whether this :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatter` can deserialize an object of the given
        ``type``.
    
        
        
        
        :param type: The  of object that will be read.
        
        :type type: System.Type
        :rtype: System.Boolean
        :return: <c>true</c> if the <paramref name="type" /> can be read, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool CanReadType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.GetDefaultValueForType(System.Type)
    
        
        
        
        :type modelType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected object GetDefaultValueForType(Type modelType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
    
        
        .. code-block:: csharp
    
           public virtual Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
    
        Reads an object from the request body.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion deserializes the request body.
    
        
        .. code-block:: csharp
    
           public abstract Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.SelectCharacterEncoding(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
    
        Returns an :any:`System.Text.Encoding` based on ``context``'s 
        :dn:prop:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Charset`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Text.Encoding
        :return: An <see cref="T:System.Text.Encoding" /> based on <paramref name="context" />'s
            <see cref="P:Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Charset" />. <c>null</c> if no supported encoding was found.
    
        
        .. code-block:: csharp
    
           protected Encoding SelectCharacterEncoding(InputFormatterContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.UTF16EncodingLittleEndian
    
        
    
        Returns UTF16 Encoding which uses littleEndian byte order with BOM and throws on invalid bytes.
    
        
    
        
        .. code-block:: csharp
    
           protected static readonly Encoding UTF16EncodingLittleEndian
    
    .. dn:field:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.UTF8EncodingWithoutBOM
    
        
    
        Returns UTF8 Encoding without BOM and throws on invalid bytes.
    
        
    
        
        .. code-block:: csharp
    
           protected static readonly Encoding UTF8EncodingWithoutBOM
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.SupportedEncodings
    
        
    
        Gets the mutable collection of character encodings supported by
        this :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`\. The encodings are
        used when reading the data.
    
        
        :rtype: System.Collections.Generic.IList{System.Text.Encoding}
    
        
        .. code-block:: csharp
    
           public IList<Encoding> SupportedEncodings { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatter.SupportedMediaTypes
    
        
    
        Gets the mutable collection of :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` elements supported by
        this :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`\.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> SupportedMediaTypes { get; }
    

