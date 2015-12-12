

HttpNoContentOutputFormatter Class
==================================



.. contents:: 
   :local:



Summary
-------

Sets the status code to 204 if the content is null.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter`








Syntax
------

.. code-block:: csharp

   public class HttpNoContentOutputFormatter : IOutputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/HttpNoContentOutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(OutputFormatterWriteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter.TreatNullValueAsNoContent
    
        
    
        Indicates whether to select this formatter if the returned value from the action
        is null.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TreatNullValueAsNoContent { get; set; }
    

