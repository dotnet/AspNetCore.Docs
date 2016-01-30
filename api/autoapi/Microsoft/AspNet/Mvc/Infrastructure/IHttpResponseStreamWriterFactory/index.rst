

IHttpResponseStreamWriterFactory Interface
==========================================



.. contents:: 
   :local:



Summary
-------

Creates :any:`System.IO.TextWriter` instances for writing to :dn:prop:`Microsoft.AspNet.Http.HttpResponse.Body`\.











Syntax
------

.. code-block:: csharp

   public interface IHttpResponseStreamWriterFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IHttpResponseStreamWriterFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory.CreateWriter(System.IO.Stream, System.Text.Encoding)
    
        
    
        Creates a new :any:`System.IO.TextWriter`\.
    
        
        
        
        :param stream: The , usually .
        
        :type stream: System.IO.Stream
        
        
        :param encoding: The , usually .
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextWriter
        :return: A <see cref="T:System.IO.TextWriter" />.
    
        
        .. code-block:: csharp
    
           TextWriter CreateWriter(Stream stream, Encoding encoding)
    

