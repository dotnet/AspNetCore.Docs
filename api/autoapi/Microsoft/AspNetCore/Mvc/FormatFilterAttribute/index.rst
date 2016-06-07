

FormatFilterAttribute Class
===========================






A filter that will use the format value in the route data or query string to set the content type on an
:any:`Microsoft.AspNetCore.Mvc.ObjectResult` returned from an action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.FormatFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FormatFilterAttribute : Attribute, _Attribute, IFilterFactory, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.FormatFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.FormatFilter`\.
    
        
    
        
        :param serviceProvider: The :any:`System.IServiceProvider`\.
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
        :return: An instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.FormatFilter`\.
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

