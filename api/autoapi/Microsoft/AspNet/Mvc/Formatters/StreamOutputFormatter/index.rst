

StreamOutputFormatter Class
===========================



.. contents:: 
   :local:



Summary
-------

Always copies the stream to the response, regardless of requested content type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class StreamOutputFormatter : IOutputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/StreamOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(OutputFormatterWriteContext context)
    

