

MediaType Struct
================






A media type value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct MediaType








.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.MediaType
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.MediaType

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.MediaType
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.Charset
    
        
    
        
        Gets the charset parameter of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` if it has one.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment Charset
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.Encoding
    
        
    
        
        Gets the :any:`System.Text.Encoding` of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` if it has one.
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public Encoding Encoding
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.MatchesAllSubTypes
    
        
    
        
        Gets whether this :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` matches all subtypes.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MatchesAllSubTypes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.MatchesAllTypes
    
        
    
        
        Gets whether this :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` matches all types.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MatchesAllTypes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.SubType
    
        
    
        
        Gets the subtype of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType`\.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment SubType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.Type
    
        
    
        
        Gets the type of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType`\.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment Type
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.MediaType
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.MediaType(Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` instance.
    
        
    
        
        :param mediaType: The :any:`Microsoft.Extensions.Primitives.StringSegment` with the media type.
        
        :type mediaType: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public MediaType(StringSegment mediaType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.MediaType(System.String)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` instance.
    
        
    
        
        :param mediaType: The :any:`System.String` with the media type.
        
        :type mediaType: System.String
    
        
        .. code-block:: csharp
    
            public MediaType(string mediaType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.MediaType(System.String, System.Int32, System.Nullable<System.Int32>)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType.MediaTypeParameterParser` instance.
    
        
    
        
        :param mediaType: The :any:`System.String` with the media type.
        
        :type mediaType: System.String
    
        
        :param offset: The offset in the <em>mediaType</em> where the parsing starts.
        
        :type offset: System.Int32
    
        
        :param length: The of the media type to parse if provided.
        
        :type length: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public MediaType(string mediaType, int offset, int ? length)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.MediaType
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.CreateMediaTypeSegmentWithQuality(System.String, System.Int32)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality` containing the media type in <em>mediaType</em>
        and its associated quality.
    
        
    
        
        :param mediaType: The media type to parse.
        
        :type mediaType: System.String
    
        
        :param start: The position at which the parsing starts.
        
        :type start: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality
        :return: The parsed media type with its associated quality.
    
        
        .. code-block:: csharp
    
            public static MediaTypeSegmentWithQuality CreateMediaTypeSegmentWithQuality(string mediaType, int start)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.GetEncoding(Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        :type mediaType: Microsoft.Extensions.Primitives.StringSegment
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public static Encoding GetEncoding(StringSegment mediaType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.GetEncoding(System.String)
    
        
    
        
        :type mediaType: System.String
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public static Encoding GetEncoding(string mediaType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.GetParameter(Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        Gets the parameter <em>parameterName</em> of the media type.
    
        
    
        
        :param parameterName: The name of the parameter to retrieve.
        
        :type parameterName: Microsoft.Extensions.Primitives.StringSegment
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: The :any:`Microsoft.Extensions.Primitives.StringSegment`\for the given <em>parameterName</em> if found; otherwise<pre><code>null</code></pre>.
    
        
        .. code-block:: csharp
    
            public StringSegment GetParameter(StringSegment parameterName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.GetParameter(System.String)
    
        
    
        
        Gets the parameter <em>parameterName</em> of the media type.
    
        
    
        
        :param parameterName: The name of the parameter to retrieve.
        
        :type parameterName: System.String
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: The :any:`Microsoft.Extensions.Primitives.StringSegment`\for the given <em>parameterName</em> if found; otherwise<pre><code>null</code></pre>.
    
        
        .. code-block:: csharp
    
            public StringSegment GetParameter(string parameterName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.IsSubsetOf(Microsoft.AspNetCore.Mvc.Formatters.MediaType)
    
        
    
        
        Determines whether the current :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` is a subset of the <em>set</em> :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType`\.
    
        
    
        
        :param set: The set :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType`\.
        
        :type set: Microsoft.AspNetCore.Mvc.Formatters.MediaType
        :rtype: System.Boolean
        :return: 
            <pre><code>true</code></pre> if this :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaType` is a subset of <em>set</em>; otherwise<pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool IsSubsetOf(MediaType set)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.ReplaceEncoding(Microsoft.Extensions.Primitives.StringSegment, System.Text.Encoding)
    
        
    
        
        Replaces the encoding of the given <em>mediaType</em> with the provided
        <em>encoding</em>.
    
        
    
        
        :param mediaType: The media type whose encoding will be replaced.
        
        :type mediaType: Microsoft.Extensions.Primitives.StringSegment
    
        
        :param encoding: The encoding that will replace the encoding in the <em>mediaType</em>
        
        :type encoding: System.Text.Encoding
        :rtype: System.String
        :return: A media type with the replaced encoding.
    
        
        .. code-block:: csharp
    
            public static string ReplaceEncoding(StringSegment mediaType, Encoding encoding)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaType.ReplaceEncoding(System.String, System.Text.Encoding)
    
        
    
        
        Replaces the encoding of the given <em>mediaType</em> with the provided
        <em>encoding</em>.
    
        
    
        
        :param mediaType: The media type whose encoding will be replaced.
        
        :type mediaType: System.String
    
        
        :param encoding: The encoding that will replace the encoding in the <em>mediaType</em>
        
        :type encoding: System.Text.Encoding
        :rtype: System.String
        :return: A media type with the replaced encoding.
    
        
        .. code-block:: csharp
    
            public static string ReplaceEncoding(string mediaType, Encoding encoding)
    

