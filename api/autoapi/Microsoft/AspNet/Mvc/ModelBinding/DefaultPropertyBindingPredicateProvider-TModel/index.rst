

DefaultPropertyBindingPredicateProvider<TModel> Class
=====================================================



.. contents:: 
   :local:



Summary
-------

Default implementation for :any:`Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider`\.
Provides a expression based way to provide include properties.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider\<TModel>`








Syntax
------

.. code-block:: csharp

   public class DefaultPropertyBindingPredicateProvider<TModel> : IPropertyBindingPredicateProvider where TModel : class





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/DefaultPropertyBindingPredicateProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider<TModel>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider<TModel>.Prefix
    
        
    
        The prefix which is used while generating the property filter.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider<TModel>.PropertyFilter
    
        
        :rtype: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
    
        
        .. code-block:: csharp
    
           public virtual Func<ModelBindingContext, string, bool> PropertyFilter { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.DefaultPropertyBindingPredicateProvider<TModel>.PropertyIncludeExpressions
    
        
    
        Expressions which can be used to generate property filter which can filter model
        properties.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<Expression<Func<TModel, object>>> PropertyIncludeExpressions { get; }
    

