

ControllerResultFilter Class
============================






A filter implementation which delegates to the controller for result filter interfaces.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter`








Syntax
------

.. code-block:: csharp

    public class ControllerResultFilter : IAsyncResultFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerResultFilter.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

