

FromRouteAttribute Class
========================



.. contents:: 
   :local:



Summary
-------

Specifies that a parameter or property should be bound using route-data from the current request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.FromRouteAttribute`








Syntax
------

.. code-block:: csharp

   public class FromRouteAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/FromRouteAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FromRouteAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FromRouteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FromRouteAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.FromRouteAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

