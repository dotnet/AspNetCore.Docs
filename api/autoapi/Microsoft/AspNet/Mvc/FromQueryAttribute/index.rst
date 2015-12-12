

FromQueryAttribute Class
========================



.. contents:: 
   :local:



Summary
-------

Specifies that a parameter or property should be bound using the request query string.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.FromQueryAttribute`








Syntax
------

.. code-block:: csharp

   public class FromQueryAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/FromQueryAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FromQueryAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FromQueryAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FromQueryAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.FromQueryAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

