

SkipStatusCodePagesAttribute Class
==================================



.. contents:: 
   :local:



Summary
-------

Filter to prevent StatusCodePages middleware to handle responses.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.SkipStatusCodePagesAttribute`








Syntax
------

.. code-block:: csharp

   public class SkipStatusCodePagesAttribute : Attribute, _Attribute, IResourceFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/SkipStatusCodePagesAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.SkipStatusCodePagesAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.SkipStatusCodePagesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.SkipStatusCodePagesAttribute.OnResourceExecuted(Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.SkipStatusCodePagesAttribute.OnResourceExecuting(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuting(ResourceExecutingContext context)
    

