

ContentDispositionHeaderValue Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.ContentDispositionHeaderValue`








Syntax
------

.. code-block:: csharp

   public class ContentDispositionHeaderValue





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Net.Http.Headers/ContentDispositionHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ContentDispositionHeaderValue(System.String)
    
        
        
        
        :type dispositionType: System.String
    
        
        .. code-block:: csharp
    
           public ContentDispositionHeaderValue(string dispositionType)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Parse(System.String)
    
        
        
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    
        
        .. code-block:: csharp
    
           public static ContentDispositionHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.SetHttpFileName(System.String)
    
        
    
        Sets both FileName and FileNameStar using encodings appropriate for HTTP headers.
    
        
        
        
        :type fileName: System.String
    
        
        .. code-block:: csharp
    
           public void SetHttpFileName(string fileName)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.SetMimeFileName(System.String)
    
        
    
        Sets the FileName parameter using encodings appropriate for MIME headers.
        The FileNameStar paraemter is removed.
    
        
        
        
        :type fileName: System.String
    
        
        .. code-block:: csharp
    
           public void SetMimeFileName(string fileName)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.ContentDispositionHeaderValue)
    
        
        
        
        :type input: System.String
        
        
        :type parsedValue: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParse(string input, out ContentDispositionHeaderValue parsedValue)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.CreationDate
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? CreationDate { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.DispositionType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DispositionType { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.FileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileName { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.FileNameStar
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileNameStar { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ModificationDate
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? ModificationDate { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Parameters
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.Net.Http.Headers.NameValueHeaderValue}
    
        
        .. code-block:: csharp
    
           public ICollection<NameValueHeaderValue> Parameters { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ReadDate
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? ReadDate { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Size
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? Size { get; set; }
    

