

QueryStringValueProviderFactory Class
=====================================






A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` that creates :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instances that
read values from the request query-string.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProviderFactory`








Syntax
------

.. code-block:: csharp

    public class QueryStringValueProviderFactory : IValueProviderFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProviderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProviderFactory

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProviderFactory.CreateValueProviderAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    

