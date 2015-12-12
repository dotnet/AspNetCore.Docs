

ExceptionFilterAttribute Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class ExceptionFilterAttribute : Attribute, _Attribute, IAsyncExceptionFilter, IExceptionFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/ExceptionFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute.OnException(Microsoft.AspNet.Mvc.Filters.ExceptionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ExceptionContext
    
        
        .. code-block:: csharp
    
           public virtual void OnException(ExceptionContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute.OnExceptionAsync(Microsoft.AspNet.Mvc.Filters.ExceptionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnExceptionAsync(ExceptionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ExceptionFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

