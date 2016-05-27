

IHttpRequestStreamReaderFactory Interface
=========================================






Creates :any:`System.IO.TextReader` instances for reading from :dn:prop:`Microsoft.AspNetCore.Http.HttpRequest.Body`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpRequestStreamReaderFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory.CreateReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        Creates a new :any:`System.IO.TextReader`\.
    
        
    
        
        :param stream: The :any:`System.IO.Stream`\, usually :dn:prop:`Microsoft.AspNetCore.Http.HttpRequest.Body`\.
        
        :type stream: System.IO.Stream
    
        
        :param encoding: The :any:`System.Text.Encoding`\, usually :dn:prop:`System.Text.Encoding.UTF8`\.
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextReader
        :return: A :any:`System.IO.TextReader`\.
    
        
        .. code-block:: csharp
    
            TextReader CreateReader(Stream stream, Encoding encoding)
    

