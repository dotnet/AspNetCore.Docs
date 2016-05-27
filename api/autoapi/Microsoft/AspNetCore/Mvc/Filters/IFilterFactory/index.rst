

IFilterFactory Interface
========================






An interface for filter metadata which can create an instance of an executable filter.


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

    public interface IFilterFactory : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.IsReusable
    
        
    
        
        Gets a value that indicates if the result of :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance(System.IServiceProvider)`
        can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsReusable
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance(System.IServiceProvider)
    
        
    
        
        Creates an instance of the executable filter.
    
        
    
        
        :param serviceProvider: The request :any:`System.IServiceProvider`\.
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An instance of the executable filter.
    
        
        .. code-block:: csharp
    
            IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

