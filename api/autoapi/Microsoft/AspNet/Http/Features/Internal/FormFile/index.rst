

FormFile Class
==============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.FormFile`








Syntax
------

.. code-block:: csharp

   public class FormFile : IFormFile





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/Features/FormFile.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFile

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.FormFile.FormFile(System.IO.Stream, System.Int64, System.Int64)
    
        
        
        
        :type baseStream: System.IO.Stream
        
        
        :type baseStreamOffset: System.Int64
        
        
        :type length: System.Int64
    
        
        .. code-block:: csharp
    
           public FormFile(Stream baseStream, long baseStreamOffset, long length)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.FormFile.OpenReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream OpenReadStream()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFile.ContentDisposition
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ContentDisposition { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFile.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFile.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFile.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public long Length { get; }
    

