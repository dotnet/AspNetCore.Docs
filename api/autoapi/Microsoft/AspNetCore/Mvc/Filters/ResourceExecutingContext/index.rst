

ResourceExecutingContext Class
==============================






A context for resource filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)` and 
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter.OnResourceExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate)` calls.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext`








Syntax
------

.. code-block:: csharp

    public class ResourceExecutingContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.ResourceExecutingContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: The list of :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` instances.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        :param valueProviderFactories: The list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` instances.
        
        :type valueProviderFactories: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        .. code-block:: csharp
    
            public ResourceExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters, IList<IValueProviderFactory> valueProviderFactories)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.Result
    
        
    
        
        Gets or sets the result of the action to be executed.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.ValueProviderFactories
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` instances used by model binding.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        .. code-block:: csharp
    
            public IList<IValueProviderFactory> ValueProviderFactories { get; }
    

