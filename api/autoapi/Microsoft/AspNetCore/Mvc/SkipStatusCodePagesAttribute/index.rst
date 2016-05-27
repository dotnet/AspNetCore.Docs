

SkipStatusCodePagesAttribute Class
==================================






A filter that prevents execution of the StatusCodePages middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SkipStatusCodePagesAttribute : Attribute, _Attribute, IResourceFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.SkipStatusCodePagesAttribute.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuting(ResourceExecutingContext context)
    

