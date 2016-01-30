

IFormFile Interface
===================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFormFile





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/IFormFile.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.IFormFile

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.IFormFile
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.IFormFile.OpenReadStream()
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream OpenReadStream()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.IFormFile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.IFormFile.ContentDisposition
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ContentDisposition { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.IFormFile.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.IFormFile.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.IFormFile.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           long Length { get; }
    

