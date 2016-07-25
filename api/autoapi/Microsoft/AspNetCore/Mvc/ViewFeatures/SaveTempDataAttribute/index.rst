

SaveTempDataAttribute Class
===========================






A filter that saves the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` for a request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SaveTempDataAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.SaveTempDataAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

