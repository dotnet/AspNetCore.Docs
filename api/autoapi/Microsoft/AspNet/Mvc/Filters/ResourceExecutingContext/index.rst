

ResourceExecutingContext Class
==============================



.. contents:: 
   :local:



Summary
-------

A context for resource filters. Allows modification of services and values used for
model binding.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext`








Syntax
------

.. code-block:: csharp

   public class ResourceExecutingContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ResourceExecutingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.ResourceExecutingContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext`\.
    
        
        
        
        :param actionContext: The .
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param filters: The list of  instances.
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public ResourceExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.InputFormatters
    
        
    
        Gets or sets the list of :any:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter` instances used by model binding.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
    
        
        .. code-block:: csharp
    
           public virtual IList<IInputFormatter> InputFormatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.ModelBinders
    
        
    
        Gets or sets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` instances used by model binding.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
    
        
        .. code-block:: csharp
    
           public virtual IList<IModelBinder> ModelBinders { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.OutputFormatters
    
        
    
        Gets or sets the list of :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` instances used to format the response.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
    
        
        .. code-block:: csharp
    
           public virtual IList<IOutputFormatter> OutputFormatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.Result
    
        
    
        Gets or sets the result of the action to be executed.
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.ValidatorProviders
    
        
    
        Gets or sets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances used by model binding.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public IList<IModelValidatorProvider> ValidatorProviders { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.ValueProviderFactories
    
        
    
        Gets or sets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory` instances used by model binding.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory}
    
        
        .. code-block:: csharp
    
           public IList<IValueProviderFactory> ValueProviderFactories { get; set; }
    

