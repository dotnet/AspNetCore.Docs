

OutputFormatterCanWriteContext Class
====================================






A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext`








Syntax
------

.. code-block:: csharp

    public abstract class OutputFormatterCanWriteContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.ContentType
    
        
    
        
        Gets or sets the content type to write to the response.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public virtual StringSegment ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.Object
    
        
    
        
        Gets or sets the object to write to the response.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Object { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.ObjectType
    
        
    
        
        Gets or sets the :any:`System.Type` of the object to write to the response.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public virtual Type ObjectType { get; protected set; }
    

