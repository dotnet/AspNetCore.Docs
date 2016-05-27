

IFilterContainer Interface
==========================






A filter that requires a reference back to the :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterFactory` that created it.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFilterContainer








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterContainer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterContainer

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterContainer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.IFilterContainer.FilterDefinition
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterFactory` that created this filter instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            IFilterMetadata FilterDefinition
            {
                get;
                set;
            }
    

