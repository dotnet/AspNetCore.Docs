

ValidateAntiForgeryTokenAttribute Class
=======================================



.. contents:: 
   :local:



Summary
-------

Specifies that the class or method that this attribute is applied validates the anti-forgery token.
If the anti-forgery token is not available, or if the token is invalid, the validation will fail
and the action method will not execute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute`








Syntax
------

.. code-block:: csharp

   public class ValidateAntiForgeryTokenAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ValidateAntiForgeryTokenAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ValidateAntiForgeryTokenAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

