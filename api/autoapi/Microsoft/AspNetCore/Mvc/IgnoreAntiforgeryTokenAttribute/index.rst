

IgnoreAntiforgeryTokenAttribute Class
=====================================






An filter that skips antiforgery token validation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IgnoreAntiforgeryTokenAttribute : Attribute, _Attribute, IAntiforgeryPolicy, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

