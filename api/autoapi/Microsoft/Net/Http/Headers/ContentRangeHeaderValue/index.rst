

ContentRangeHeaderValue Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.ContentRangeHeaderValue`








Syntax
------

.. code-block:: csharp

   public class ContentRangeHeaderValue





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/ContentRangeHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.ContentRangeHeaderValue(System.Int64)
    
        
        
        
        :type length: System.Int64
    
        
        .. code-block:: csharp
    
           public ContentRangeHeaderValue(long length)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.ContentRangeHeaderValue(System.Int64, System.Int64)
    
        
        
        
        :type from: System.Int64
        
        
        :type to: System.Int64
    
        
        .. code-block:: csharp
    
           public ContentRangeHeaderValue(long from, long to)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.ContentRangeHeaderValue(System.Int64, System.Int64, System.Int64)
    
        
        
        
        :type from: System.Int64
        
        
        :type to: System.Int64
        
        
        :type length: System.Int64
    
        
        .. code-block:: csharp
    
           public ContentRangeHeaderValue(long from, long to, long length)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.Parse(System.String)
    
        
        
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    
        
        .. code-block:: csharp
    
           public static ContentRangeHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.ContentRangeHeaderValue)
    
        
        
        
        :type input: System.String
        
        
        :type parsedValue: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParse(string input, out ContentRangeHeaderValue parsedValue)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.From
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? From { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.HasLength
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasLength { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.HasRange
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasRange { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.Length
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? Length { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.To
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? To { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.ContentRangeHeaderValue.Unit
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Unit { get; set; }
    

