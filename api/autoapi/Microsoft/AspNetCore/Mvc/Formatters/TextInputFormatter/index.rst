

TextInputFormatter Class
========================






Reads an object from a request body with a text format.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter`








Syntax
------

.. code-block:: csharp

    public abstract class TextInputFormatter : InputFormatter, IInputFormatter, IApiRequestFormatMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.SupportedEncodings
    
        
    
        
        Gets the mutable collection of character encodings supported by
        this :any:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter`\. The encodings are
        used when reading the data.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Text.Encoding<System.Text.Encoding>}
    
        
        .. code-block:: csharp
    
            public IList<Encoding> SupportedEncodings
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
    
        
        .. code-block:: csharp
    
            public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.ReadRequestBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext, System.Text.Encoding)
    
        
    
        
        Reads an object from the request body.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
    
        
        :param encoding: The :any:`System.Text.Encoding` used to read the request body.
        
        :type encoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion deserializes the request body.
    
        
        .. code-block:: csharp
    
            public abstract Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.SelectCharacterEncoding(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        Returns an :any:`System.Text.Encoding` based on <em>context</em>'s
        character set.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Text.Encoding
        :return: 
            An :any:`System.Text.Encoding` based on <em>context</em>'s
            character set. <code>null</code> if no supported encoding was found.
    
        
        .. code-block:: csharp
    
            protected Encoding SelectCharacterEncoding(InputFormatterContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.UTF16EncodingLittleEndian
    
        
    
        
        Returns UTF16 Encoding which uses littleEndian byte order with BOM and throws on invalid bytes.
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            protected static readonly Encoding UTF16EncodingLittleEndian
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter.UTF8EncodingWithoutBOM
    
        
    
        
        Returns UTF8 Encoding without BOM and throws on invalid bytes.
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            protected static readonly Encoding UTF8EncodingWithoutBOM
    

