

FormReader Class
================



.. contents:: 
   :local:



Summary
-------

Used to read an 'application/x-www-form-urlencoded' form.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.FormReader`








Syntax
------

.. code-block:: csharp

   public class FormReader





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.WebUtilities/FormReader.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.FormReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.FormReader.FormReader(System.IO.Stream, System.Text.Encoding)
    
        
        
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public FormReader(Stream stream, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.FormReader.FormReader(System.String)
    
        
        
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
           public FormReader(string data)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.FormReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FormReader.ReadForm(System.String)
    
        
    
        Parses text from an HTTP form body.
    
        
        
        
        :param text: The HTTP form body to parse.
        
        :type text: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        :return: The collection containing the parsed HTTP form body.
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, StringValues> ReadForm(string text)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FormReader.ReadFormAsync(System.IO.Stream, System.Text.Encoding, System.Threading.CancellationToken)
    
        
    
        Parses an HTTP form body.
    
        
        
        
        :param stream: The HTTP form body to parse.
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}}
        :return: The collection containing the parsed HTTP form body.
    
        
        .. code-block:: csharp
    
           public static Task<IDictionary<string, StringValues>> ReadFormAsync(Stream stream, Encoding encoding, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FormReader.ReadFormAsync(System.IO.Stream, System.Threading.CancellationToken)
    
        
    
        Parses an HTTP form body.
    
        
        
        
        :param stream: The HTTP form body to parse.
        
        :type stream: System.IO.Stream
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}}
        :return: The collection containing the parsed HTTP form body.
    
        
        .. code-block:: csharp
    
           public static Task<IDictionary<string, StringValues>> ReadFormAsync(Stream stream, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FormReader.ReadNextPair()
    
        
    
        Reads the next key value pair from the form.
        For unbuffered data use the async overload instead.
    
        
        :rtype: System.Nullable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
        :return: The next key value pair, or null when the end of the form is reached.
    
        
        .. code-block:: csharp
    
           public KeyValuePair<string, string>? ReadNextPair()
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FormReader.ReadNextPairAsync(System.Threading.CancellationToken)
    
        
    
        Asynchronously reads the next key value pair from the form.
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Nullable{System.Collections.Generic.KeyValuePair{System.String,System.String}}}
        :return: The next key value pair, or null when the end of the form is reached.
    
        
        .. code-block:: csharp
    
           public Task<KeyValuePair<string, string>? > ReadNextPairAsync(CancellationToken cancellationToken)
    

