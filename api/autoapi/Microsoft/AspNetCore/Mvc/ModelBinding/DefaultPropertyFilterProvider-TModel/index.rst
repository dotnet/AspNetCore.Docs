

DefaultPropertyFilterProvider<TModel> Class
===========================================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider`\.
Provides a expression based way to provide include properties.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider\<TModel>`








Syntax
------

.. code-block:: csharp

    public class DefaultPropertyFilterProvider<TModel> : IPropertyFilterProvider where TModel : class








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider<TModel>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider<TModel>.Prefix
    
        
    
        
        The prefix which is used while generating the property filter.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Prefix
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider<TModel>.PropertyFilter
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public virtual Func<ModelMetadata, bool> PropertyFilter
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultPropertyFilterProvider<TModel>.PropertyIncludeExpressions
    
        
    
        
        Expressions which can be used to generate property filter which can filter model 
        properties.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<Expression<Func<TModel, object>>> PropertyIncludeExpressions
            {
                get;
            }
    

