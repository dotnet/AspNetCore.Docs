

FilterContext Class
===================






An abstract context for filters.


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








Syntax
------

.. code-block:: csharp

    public abstract class FilterContext : ActionContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.FilterContext.Filters
    
        
    
        
        Gets all applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public virtual IList<IFilterMetadata> Filters
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.FilterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.FilterContext.FilterContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.FilterContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public FilterContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

