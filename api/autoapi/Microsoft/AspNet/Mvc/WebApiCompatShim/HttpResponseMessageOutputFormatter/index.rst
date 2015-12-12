

HttpResponseMessageOutputFormatter Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class HttpResponseMessageOutputFormatter : IOutputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/Formatters/HttpResponseMessageOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(OutputFormatterWriteContext context)
    

