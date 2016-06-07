

IHttpResponseStreamWriterFactory Interface
==========================================






Creates :any:`System.IO.TextWriter` instances for writing to :dn:prop:`Microsoft.AspNetCore.Http.HttpResponse.Body`\.


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

    public interface IHttpResponseStreamWriterFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory.CreateWriter(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        Creates a new :any:`System.IO.TextWriter`\.
    
        
    
        
        :param stream: The :any:`System.IO.Stream`\, usually :dn:prop:`Microsoft.AspNetCore.Http.HttpResponse.Body`\.
        
        :type stream: System.IO.Stream
    
        
        :param encoding: The :any:`System.Text.Encoding`\, usually :dn:prop:`System.Text.Encoding.UTF8`\.
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextWriter
        :return: A :any:`System.IO.TextWriter`\.
    
        
        .. code-block:: csharp
    
            TextWriter CreateWriter(Stream stream, Encoding encoding)
    

