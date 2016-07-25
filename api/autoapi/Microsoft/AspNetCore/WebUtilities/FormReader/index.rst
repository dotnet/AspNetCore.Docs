

FormReader Class
================






Used to read an 'application/x-www-form-urlencoded' form.


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
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.FormReader`








Syntax
------

.. code-block:: csharp

    public class FormReader : IDisposable








.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FormReader.FormReader(System.IO.Stream)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public FormReader(Stream stream)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FormReader.FormReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public FormReader(Stream stream, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FormReader.FormReader(System.IO.Stream, System.Text.Encoding, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public FormReader(Stream stream, Encoding encoding, ArrayPool<char> charPool)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FormReader.FormReader(System.String)
    
        
    
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
            public FormReader(string data)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FormReader.FormReader(System.String, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        :type data: System.String
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public FormReader(string data, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FormReader.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FormReader.ReadForm()
    
        
    
        
        Parses text from an HTTP form body.
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :return: The collection containing the parsed HTTP form body.
    
        
        .. code-block:: csharp
    
            public Dictionary<string, StringValues> ReadForm()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FormReader.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        
        Parses an HTTP form body.
    
        
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken`\.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
        :return: The collection containing the parsed HTTP form body.
    
        
        .. code-block:: csharp
    
            public Task<Dictionary<string, StringValues>> ReadFormAsync(CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FormReader.ReadNextPair()
    
        
    
        
        Reads the next key value pair from the form.
        For unbuffered data use the async overload instead.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :return: The next key value pair, or null when the end of the form is reached.
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, string>? ReadNextPair()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FormReader.ReadNextPairAsync(System.Threading.CancellationToken)
    
        
    
        
        Asynchronously reads the next key value pair from the form.
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Nullable<System.Nullable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}}
        :return: The next key value pair, or null when the end of the form is reached.
    
        
        .. code-block:: csharp
    
            public Task<KeyValuePair<string, string>? > ReadNextPairAsync(CancellationToken cancellationToken = null)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.FormReader.DefaultKeyLengthLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultKeyLengthLimit = 2048
    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.FormReader.DefaultValueCountLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultValueCountLimit = 1024
    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.FormReader.DefaultValueLengthLimit
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultValueLengthLimit = 4194304
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FormReader.KeyLengthLimit
    
        
    
        
        The limit on the length of form keys.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int KeyLengthLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FormReader.ValueCountLimit
    
        
    
        
        The limit on the number of form values to allow in ReadForm or ReadFormAsync.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ValueCountLimit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FormReader.ValueLengthLimit
    
        
    
        
        The limit on the length of form values.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ValueLengthLimit { get; set; }
    

