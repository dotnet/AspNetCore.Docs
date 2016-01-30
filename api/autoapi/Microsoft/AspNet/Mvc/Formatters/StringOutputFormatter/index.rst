

StringOutputFormatter Class
===========================



.. contents:: 
   :local:



Summary
-------

Always writes a string value to the response, regardless of requested content type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class StringOutputFormatter : OutputFormatter, IOutputFormatter, IApiResponseFormatMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Formatters/StringOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter.StringOutputFormatter()
    
        
    
        
        .. code-block:: csharp
    
           public StringOutputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    

