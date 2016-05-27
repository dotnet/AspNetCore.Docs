

MultipartSection Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.MultipartSection`








Syntax
------

.. code-block:: csharp

    public class MultipartSection








.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartSection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartSection

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.MultipartSection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartSection.BaseStreamOffset
    
        
    
        
        The position where the body starts in the total multipart body.
        This may not be available if the total multipart body is not seekable.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? BaseStreamOffset
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartSection.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartSection.ContentDisposition
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentDisposition
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartSection.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.MultipartSection.Headers
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, StringValues> Headers
            {
                get;
                set;
            }
    

