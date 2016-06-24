

FormFile Class
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.FormFile`








Syntax
------

.. code-block:: csharp

    public class FormFile : IFormFile








.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFile
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFile

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.FormFile.FormFile(System.IO.Stream, System.Int64, System.Int64, System.String, System.String)
    
        
    
        
        :type baseStream: System.IO.Stream
    
        
        :type baseStreamOffset: System.Int64
    
        
        :type length: System.Int64
    
        
        :type name: System.String
    
        
        :type fileName: System.String
    
        
        .. code-block:: csharp
    
            public FormFile(Stream baseStream, long baseStreamOffset, long length, string name, string fileName)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.ContentDisposition
    
        
    
        
        Gets the raw Content-Disposition header of the uploaded file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentDisposition { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.ContentType
    
        
    
        
        Gets the raw Content-Type header of the uploaded file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.FileName
    
        
    
        
        Gets the file name from the Content-Disposition header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.Headers
    
        
    
        
        Gets the header dictionary of the uploaded file.
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.Length
    
        
    
        
        Gets the file length in bytes.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.FormFile.Name
    
        
    
        
        Gets the name from the Content-Disposition header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.FormFile
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.FormFile.CopyTo(System.IO.Stream)
    
        
    
        
        Copies the contents of the uploaded file to the <em>target</em> stream.
    
        
    
        
        :param target: The stream to copy the file contents to.
        
        :type target: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public void CopyTo(Stream target)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.FormFile.CopyToAsync(System.IO.Stream, System.Threading.CancellationToken)
    
        
    
        
        Asynchronously copies the contents of the uploaded file to the <em>target</em> stream.
    
        
    
        
        :param target: The stream to copy the file contents to.
        
        :type target: System.IO.Stream
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task CopyToAsync(Stream target, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.FormFile.OpenReadStream()
    
        
    
        
        Opens the request stream for reading the uploaded file.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream OpenReadStream()
    

