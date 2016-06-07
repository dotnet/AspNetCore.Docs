

HttpNoContentOutputFormatter Class
==================================






Sets the status code to 204 if the content is null.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter`








Syntax
------

.. code-block:: csharp

    public class HttpNoContentOutputFormatter : IOutputFormatter








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter.TreatNullValueAsNoContent
    
        
    
        
        Indicates whether to select this formatter if the returned value from the action
        is null.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TreatNullValueAsNoContent
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(OutputFormatterWriteContext context)
    

