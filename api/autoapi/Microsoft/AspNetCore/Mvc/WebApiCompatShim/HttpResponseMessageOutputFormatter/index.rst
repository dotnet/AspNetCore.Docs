

HttpResponseMessageOutputFormatter Class
========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.WebApiCompatShim`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class HttpResponseMessageOutputFormatter : IOutputFormatter








.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(OutputFormatterWriteContext context)
    

