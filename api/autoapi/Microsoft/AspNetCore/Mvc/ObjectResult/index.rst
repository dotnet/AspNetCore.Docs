

ObjectResult Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`








Syntax
------

.. code-block:: csharp

    public class ObjectResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ObjectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ObjectResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection ContentTypes
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ObjectResult.DeclaredType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type DeclaredType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ObjectResult.Formatters
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        .. code-block:: csharp
    
            public FormatterCollection<IOutputFormatter> Formatters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ObjectResult.StatusCode
    
        
    
        
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? StatusCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ObjectResult.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ObjectResult.ObjectResult(System.Object)
    
        
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public ObjectResult(object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ObjectResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ObjectResult.OnFormatting(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        This method is called before the formatter writes to the output stream.
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public virtual void OnFormatting(ActionContext context)
    

