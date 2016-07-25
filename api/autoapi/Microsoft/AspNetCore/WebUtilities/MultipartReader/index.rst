

MultipartReader Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.MultipartReader`








Syntax
------

.. code-block:: csharp

    public class MultipartReader








.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.MultipartReader.ReadNextSectionAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.WebUtilities.MultipartSection<Microsoft.AspNetCore.WebUtilities.MultipartSection>}
    
        
        .. code-block:: csharp
    
            public Task<MultipartSection> ReadNextSectionAsync(CancellationToken cancellationToken = null)
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.MultipartReader.MultipartReader(System.String, System.IO.Stream)
    
        
    
        
        :type boundary: System.String
    
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public MultipartReader(string boundary, Stream stream)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.MultipartReader.MultipartReader(System.String, System.IO.Stream, System.Int32)
    
        
    
        
        :type boundary: System.String
    
        
        :type stream: System.IO.Stream
    
        
        :type bufferSize: System.Int32
    
        
        .. code-block:: csharp
    
            public MultipartReader(string boundary, Stream stream, int bufferSize)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartReader.BodyLengthLimit
    
        
    
        
        The optional limit for the total response body length.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? BodyLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartReader.HeadersCountLimit
    
        
    
        
        The limit for the number of headers to read.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int HeadersCountLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartReader.HeadersLengthLimit
    
        
    
        
        The combined size limit for headers per multipart section.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int HeadersLengthLimit { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.MultipartReader.DefaultHeadersCountLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultHeadersCountLimit = 16
    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.MultipartReader.DefaultHeadersLengthLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultHeadersLengthLimit = 16384
    

