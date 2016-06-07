

ValueProviderFactoryContext Class
=================================






A context for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext`








Syntax
------

.. code-block:: csharp

    public class ValueProviderFactoryContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ActionContext
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ActionContext` associated with this context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ValueProviders
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instances.
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` instances should add the appropriate
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instances to this list.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IValueProvider> ValueProviders
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ValueProviderFactoryContext(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext`\.
    
        
    
        
        :param context: The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ActionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ValueProviderFactoryContext(ActionContext context)
    

