

IFormFile Interface
===================






Represents a file sent with the HttpRequest.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFormFile








.. dn:interface:: Microsoft.AspNetCore.Http.IFormFile
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFile

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.ContentDisposition
    
        
    
        
        Gets the raw Content-Disposition header of the uploaded file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ContentDisposition { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.ContentType
    
        
    
        
        Gets the raw Content-Type header of the uploaded file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ContentType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.FileName
    
        
    
        
        Gets the file name from the Content-Disposition header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string FileName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.Headers
    
        
    
        
        Gets the header dictionary of the uploaded file.
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.Length
    
        
    
        
        Gets the file length in bytes.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            long Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormFile.Name
    
        
    
        
        Gets the name from the Content-Disposition header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Name { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormFile
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormFile.CopyTo(System.IO.Stream)
    
        
    
        
        Copies the contents of the uploaded file to the <em>target</em> stream.
    
        
    
        
        :param target: The stream to copy the file contents to.
        
        :type target: System.IO.Stream
    
        
        .. code-block:: csharp
    
            void CopyTo(Stream target)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormFile.CopyToAsync(System.IO.Stream, System.Threading.CancellationToken)
    
        
    
        
        Asynchronously copies the contents of the uploaded file to the <em>target</em> stream.
    
        
    
        
        :param target: The stream to copy the file contents to.
        
        :type target: System.IO.Stream
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task CopyToAsync(Stream target, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormFile.OpenReadStream()
    
        
    
        
        Opens the request stream for reading the uploaded file.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            Stream OpenReadStream()
    

