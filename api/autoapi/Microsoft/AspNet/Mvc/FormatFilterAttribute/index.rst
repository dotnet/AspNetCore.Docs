

FormatFilterAttribute Class
===========================



.. contents:: 
   :local:



Summary
-------

A filter which will use the format value in the route data or query string to set the content type on an 
:any:`Microsoft.AspNet.Mvc.ObjectResult` returned from an action.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.FormatFilterAttribute`








Syntax
------

.. code-block:: csharp

   public class FormatFilterAttribute : Attribute, _Attribute, IFilterFactory, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/FormatFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FormatFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.FormatFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.FormatFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        Creates an instance of :any:`Microsoft.AspNet.Mvc.Formatters.FormatFilter`\.
    
        
        
        
        :param serviceProvider: The .
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
        :return: An instance of <see cref="T:Microsoft.AspNet.Mvc.Formatters.FormatFilter" />.
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

