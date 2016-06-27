

ValidateAntiForgeryTokenAttribute Class
=======================================






Specifies that the class or method that this attribute is applied validates the anti-forgery token.
If the anti-forgery token is not available, or if the token is invalid, the validation will fail
and the action method will not execute.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateAntiForgeryTokenAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

