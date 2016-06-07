

ContentDispositionHeaderValue Class
===================================





Namespace
    :dn:ns:`Microsoft.Net.Http.Headers`
Assemblies
    * Microsoft.Net.Http.Headers

----

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








.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.CreationDate
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? CreationDate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.DispositionType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DispositionType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.FileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.FileNameStar
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileNameStar
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ModificationDate
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? ModificationDate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Parameters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.NameValueHeaderValue<Microsoft.Net.Http.Headers.NameValueHeaderValue>}
    
        
        .. code-block:: csharp
    
            public IList<NameValueHeaderValue> Parameters
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.ReadDate
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? ReadDate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Size
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? Size
            {
                get;
                set;
            }
    

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
    

