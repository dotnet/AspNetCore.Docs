

MediaTypeHeaderValue Class
==========================





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
* :dn:cls:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue`








Syntax
------

.. code-block:: csharp

    public class MediaTypeHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.MediaTypeHeaderValue(System.String)
    
        
    
        
        :type mediaType: System.String
    
        
        .. code-block:: csharp
    
            public MediaTypeHeaderValue(string mediaType)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.MediaTypeHeaderValue(System.String, System.Double)
    
        
    
        
        :type mediaType: System.String
    
        
        :type quality: System.Double
    
        
        .. code-block:: csharp
    
            public MediaTypeHeaderValue(string mediaType, double quality)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Boundary
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Boundary { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Charset
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Charset { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public Encoding Encoding { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.MatchesAllSubTypes
    
        
    
        
        SubType = "*"
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MatchesAllSubTypes { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.MatchesAllTypes
    
        
    
        
        MediaType = "*/*"
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MatchesAllTypes { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.MediaType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MediaType { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parameters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.NameValueHeaderValue<Microsoft.Net.Http.Headers.NameValueHeaderValue>}
    
        
        .. code-block:: csharp
    
            public IList<NameValueHeaderValue> Parameters { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Quality
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Double<System.Double>}
    
        
        .. code-block:: csharp
    
            public double ? Quality { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.SubType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SubType { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Type
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Type { get; }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Copy()
    
        
    
        
        Performs a deep copy of this object and all of it's NameValueHeaderValue sub components,
        while avoiding the cost of revalidating the components.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :return: A deep copy.
    
        
        .. code-block:: csharp
    
            public MediaTypeHeaderValue Copy()
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.CopyAsReadOnly()
    
        
    
        
        Performs a deep copy of this object and all of it's NameValueHeaderValue sub components,
        while avoiding the cost of revalidating the components. This copy is read-only.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :return: A deep, read-only, copy.
    
        
        .. code-block:: csharp
    
            public MediaTypeHeaderValue CopyAsReadOnly()
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.IsSubsetOf(Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Gets a value indicating whether this :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` is a subset of
        <em>otherMediaType</em>. A "subset" is defined as the same or a more specific media type
        according to the precedence described in https://www.ietf.org/rfc/rfc2068.txt section 14.1, Accept.
    
        
    
        
        :param otherMediaType: The :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` to compare.
        
        :type otherMediaType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Boolean
        :return: 
            A value indicating whether this :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` is a subset of
            <em>otherMediaType</em>.
    
        
        .. code-block:: csharp
    
            public bool IsSubsetOf(MediaTypeHeaderValue otherMediaType)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public static MediaTypeHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.MediaTypeHeaderValue<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<MediaTypeHeaderValue> ParseList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.ParseStrictList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.MediaTypeHeaderValue<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<MediaTypeHeaderValue> ParseStrictList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out MediaTypeHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.MediaTypeHeaderValue<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseList(IList<string> inputs, out IList<MediaTypeHeaderValue> parsedValues)
    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValue.TryParseStrictList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.MediaTypeHeaderValue<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseStrictList(IList<string> inputs, out IList<MediaTypeHeaderValue> parsedValues)
    

