

AutoValidateAntiforgeryTokenAttribute Class
===========================================






An attribute that causes validation of antiforgery tokens for all unsafe HTTP methods. An antiforgery
token is required for HTTP methods other than GET, HEAD, OPTIONS, and TRACE.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoValidateAntiforgeryTokenAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

