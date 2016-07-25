

FormOptions Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.FormOptions`








Syntax
------

.. code-block:: csharp

    public class FormOptions








.. dn:class:: Microsoft.AspNetCore.Http.Features.FormOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.BufferBody
    
        
    
        
        Enables full request body buffering. Use this if multiple components need to read the raw stream.
        The default value is false.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool BufferBody { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.BufferBodyLengthLimit
    
        
    
        
        If :dn:prop:`Microsoft.AspNetCore.Http.Features.FormOptions.BufferBody` is enabled, this is the limit for the total number of bytes that will
        be buffered. Forms that exceed this limit will throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long BufferBodyLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.KeyLengthLimit
    
        
    
        
        A limit on the length of individual keys. Forms containing keys that exceed this limit will
        throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int KeyLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.MemoryBufferThreshold
    
        
    
        
        If :dn:prop:`Microsoft.AspNetCore.Http.Features.FormOptions.BufferBody` is enabled, this many bytes of the body will be buffered in memory.
        If this threshold is exceeded then the buffer will be moved to a temp file on disk instead.
        This also applies when buffering individual multipart section bodies.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MemoryBufferThreshold { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.MultipartBodyLengthLimit
    
        
    
        
        A limit for the length of each multipart body. Forms sections that exceed this limit will throw an 
        :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long MultipartBodyLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.MultipartBoundaryLengthLimit
    
        
    
        
        A limit for the length of the boundary identifier. Forms with boundaries that exceed this
        limit will throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MultipartBoundaryLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.MultipartHeadersCountLimit
    
        
    
        
        A limit for the number of headers to allow in each multipart section. Headers with the same name will
        be combined. Form sections that exceed this limit will throw an :any:`System.IO.InvalidDataException`
        when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MultipartHeadersCountLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.MultipartHeadersLengthLimit
    
        
    
        
        A limit for the total length of the header keys and values in each multipart section.
        Form sections that exceed this limit will throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MultipartHeadersLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.ValueCountLimit
    
        
    
        
        A limit for the number of form entries to allow.
        Forms that exceed this limit will throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ValueCountLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormOptions.ValueLengthLimit
    
        
    
        
        A limit on the length of individual form values. Forms containing values that exceed this
        limit will throw an :any:`System.IO.InvalidDataException` when parsed.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ValueLengthLimit { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FormOptions.DefaultBufferBodyLengthLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultBufferBodyLengthLimit = 134217728
    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FormOptions.DefaultMemoryBufferThreshold
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultMemoryBufferThreshold = 65536
    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FormOptions.DefaultMultipartBodyLengthLimit
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public const long DefaultMultipartBodyLengthLimit = 134217728L
    
    .. dn:field:: Microsoft.AspNetCore.Http.Features.FormOptions.DefaultMultipartBoundaryLengthLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultMultipartBoundaryLengthLimit = 128
    

