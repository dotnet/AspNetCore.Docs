

StringOutputFormatter Class
===========================






Always writes a string value to the response, regardless of requested content type.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class StringOutputFormatter : TextOutputFormatter, IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter.StringOutputFormatter()
    
        
    
        
        .. code-block:: csharp
    
            public StringOutputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Text.Encoding)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :type encoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding encoding)
    

