

HttpNotAcceptableOutputFormatter Class
======================================






A formatter which selects itself when content-negotiation has failed and writes a 406 Not Acceptable response.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class HttpNotAcceptableOutputFormatter : IOutputFormatter








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(OutputFormatterWriteContext context)
    

