

MultipartSection Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.MultipartSection`








Syntax
------

.. code-block:: csharp

   public class MultipartSection





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.WebUtilities/MultipartSection.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartSection

Properties
----------

.. dn:class:: Microsoft.AspNet.WebUtilities.MultipartSection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartSection.BaseStreamOffset
    
        
    
        The position where the body starts in the total multipart body.
        This may not be available if the total multipart body is not seekable.
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? BaseStreamOffset { get; set; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartSection.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartSection.ContentDisposition
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ContentDisposition { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartSection.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.MultipartSection.Headers
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, StringValues> Headers { get; set; }
    

