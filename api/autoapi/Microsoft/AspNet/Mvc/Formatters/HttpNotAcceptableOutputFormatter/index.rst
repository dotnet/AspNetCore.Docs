

HttpNotAcceptableOutputFormatter Class
======================================



.. contents:: 
   :local:



Summary
-------

A formatter which selects itself when content-negotiation has failed and writes a 406 Not Acceptable response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class HttpNotAcceptableOutputFormatter : IOutputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/HttpNotAcceptableOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(OutputFormatterWriteContext context)
    

