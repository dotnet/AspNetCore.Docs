

MultipartReader Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.MultipartReader`








Syntax
------

.. code-block:: csharp

   public class MultipartReader





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.WebUtilities/MultipartReader.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.MultipartReader.MultipartReader(System.String, System.IO.Stream)
    
        
        
        
        :type boundary: System.String
        
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public MultipartReader(string boundary, Stream stream)
    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.MultipartReader.MultipartReader(System.String, System.IO.Stream, System.Int32)
    
        
        
        
        :type boundary: System.String
        
        
        :type stream: System.IO.Stream
        
        
        :type bufferSize: System.Int32
    
        
        .. code-block:: csharp
    
           public MultipartReader(string boundary, Stream stream, int bufferSize)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.MultipartReader.ReadNextSectionAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.WebUtilities.MultipartSection}
    
        
        .. code-block:: csharp
    
           public Task<MultipartSection> ReadNextSectionAsync(CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartReader.HeaderLengthLimit
    
        
    
        The limit for individual header lines inside a multipart section.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int HeaderLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartReader.TotalHeaderSizeLimit
    
        
    
        The combined size limit for headers per multipart section.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int TotalHeaderSizeLimit { get; set; }
    

